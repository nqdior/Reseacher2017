using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace newtype.Common
{
    public static class FileManager
    {
        static string fileAddress = string.Empty;

        public static string OpenSqlFileDialog()
        {
            var dialog = new OpenFileDialog();
            dialog.Title = "クエリを開く";
            dialog.Filter = "クエリファイル(*.sql;*.txt)|*.sql;*.txt|すべてのファイル(*.*)|*.*";
            dialog.InitialDirectory = Application.StartupPath;

            try
            {
                if (dialog.ShowDialog().Equals(DialogResult.OK) && !string.IsNullOrEmpty(dialog.FileName))
                {
                    Cursor.Current = Cursors.WaitCursor;

                    fileAddress = dialog.FileName;
                    var sr = new StreamReader(dialog.FileName, Encoding.GetEncoding("Shift_JIS"));

                    return sr.ReadToEnd();
                }
                return "";
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            finally { Cursor.Current = Cursors.Default; }
        }


        public static string OpenCsvFileDialog(string defFileName)
        {
            var dialog = new SaveFileDialog();
            dialog.Title = "データを出力する";
            dialog.Filter = "CSVファイル(*.csv;)|*.csv;|すべてのファイル(*.*)|*.*";
            dialog.FileName = defFileName;
            dialog.InitialDirectory = Application.StartupPath;

            try
            {
                if (dialog.ShowDialog().Equals(DialogResult.OK) && !string.IsNullOrEmpty(dialog.FileName))
                {
                    return fileAddress = dialog.FileName;
                }
                return "";
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }


        public static void SaveSqlFileDialog(bool overwrite, string defFileName, string data)
        {
            try
            {
                if (overwrite.Equals(false) || string.IsNullOrEmpty(fileAddress))
                {
                    var dialog = new SaveFileDialog();
                    dialog.Title = "クエリを保存する";
                    dialog.Filter = "クエリファイル(*.sql;)|*.sql;|すべてのファイル(*.*)|*.*";
                    dialog.FileName = defFileName;
                    dialog.InitialDirectory = Application.StartupPath;

                    if (dialog.ShowDialog().Equals(DialogResult.OK))
                    {
                        fileAddress = dialog.FileName;
                    }
                    else if (string.IsNullOrEmpty(dialog.FileName))
                    {
                        return;
                    }
                }
                Cursor.Current = Cursors.WaitCursor;
                System.Threading.Thread.Sleep(200);

                var sw = new StreamWriter(fileAddress, false, Encoding.GetEncoding("Shift_JIS"));
                sw.Write(data);
                sw.Close();
            }
            catch { /* Nothing */ }
            finally { Cursor.Current = Cursors.Default; }
        }

        public static void OutputCsvFile(DataGridView Dgv, string defFileName)
        {
            try
            {
                var fileName = OpenCsvFileDialog(defFileName);
                if (string.IsNullOrEmpty(fileName)) { return; }

                Cursor.Current = Cursors.WaitCursor;
                System.Threading.Thread.Sleep(200);

                using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.GetEncoding("shift_jis")))
                {
                    int rowCount = Dgv.Rows.Count;
                    if (Dgv.AllowUserToAddRows == true)
                    {
                        rowCount = rowCount - 1;
                    }

                    for (int i = 0; i < rowCount; i++)
                    {
                        List<string> strList = new List<string>();

                        for (int j = 0; j < Dgv.Columns.Count; j++)
                        {
                            strList.Add(Dgv[j, i].Value.ToString());
                        }
                        string[] strArray = strList.ToArray();
                        string strCsvData = string.Join(",", strArray);

                        writer.WriteLine(strCsvData);
                    }
                }
            }
            catch { /* Nothing */ }
            finally { Cursor.Current = Cursors.Default; }
        }
    }
}
