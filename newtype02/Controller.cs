using newtype.Common;
using newtype.Controls;
using newtype.Database;
using newtype.Interface;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;
using newtype.Actions;
using System.Reflection;
using System.Collections.Generic;
using newtype.Forms;
using FreeView.Sql;

namespace newtype
{
    public partial class Controller : BaseWindow, IController
    {        
        public Actions.Actions act;

        public FormBar FormBar { get { return formBar; } set { formBar = value; } }

        public MenuBar MenuBar { get { return menuBar; } set { menuBar = value; } }

        public TabGridControl TabGrid { get { return tabGrid; } set { tabGrid = value; } }

        public ISqlManager sqlManager { get { return SerialSqlManager[(ServerType)CurrentSVIndex]; } set { SerialSqlManager[(ServerType)CurrentSVIndex] = value; } }

        private Dictionary<ServerType, ISqlManager> SerialSqlManager { get; set; }

        public string RecCount { set { label1.Text = value; } }

        public int CurrentSVIndex { get { return FormBar.SVCombo.SelectedIndex; } set { FormBar.SVCombo.SelectedIndex = value; } }


        #region Start

        public Controller()
        {
            InitializeComponent();
            KeyPreview = true;

            act = new Actions.Actions(this);
            SerialSqlManager = new Dictionary<ServerType, ISqlManager>();
        }


        private void Controller_Load(object sender, EventArgs e)
        {
            // create Instance
            var xml = new XmlManager();

            formBar.isController = true;
            if (xml[new List<string> { "serialize" }, "False"].ToUpper().Equals("TRUE"))
            {
                formBar.isMultiMode = true;
            }
            Opacity = Convert.ToDouble(xml[new List<string> { "opacity" }, "0.6"]);

            ComboSetting("SQLServer", xml);
            ComboSetting("MySQL", xml);
            ComboSetting("PostgreSQL", xml);
            if (FormBar.SVCombo.Items.Count == 0)
            {
                formBar.SVCombo.Items.Add("SQLServer");
            }

            var defaultIndex = xml[new List<string> { "defaultSV" }, "0"];
            FormBar.SVCombo.SelectedIndex = Convert.ToInt32(defaultIndex);

            var sqlclass = GetSqlClass(FormBar.SVCombo.Text);      
            SerialSqlManager.Add(
                         (ServerType)CurrentSVIndex,
                         (ISqlManager)Assembly
                         .LoadFrom("newtype.Database.dll")
                         .CreateInstance($"newtype.Database.{sqlclass}"));

            if (SerialSqlManager[(ServerType)CurrentSVIndex].ConnectToServer())
            {
                UpdateDataBaseComboItems();
            }
            else
            {
                tabGrid_settingClick(sender, e);
            }

            tabGrid.TabCollection.ForEach(t => t.Text = xml[new List<string> { $"tab{t.Index}Text" }, $"tab{t.Index}"]);
            tabGrid.TabCollection.ForEach(t => tabGrid.QueryCollection[t.Index].Text = xml[new List<string> { $"tab{t.Index}Query" }, ""]);

            FormBar.SVComboIndexChanged += formBar_SVComboIndexChanged;
        }

        private void ComboSetting(string key, XmlManager xml)
        {
            if (xml[new List<string> { key }, "False"].ToUpper().Equals("TRUE"))
            {
                formBar.SVCombo.Items.Add(key);
            }
        }

        #endregion


        #region Default


        private void Controller_KeyDown(object sender, KeyEventArgs e)
        {
            if ((ModifierKeys & Keys.Control) == Keys.Control && e.KeyCode == Keys.W)
            {
                tabGrid.AwakeViewer();

                e.Handled = true;
            }

            if ((ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                var focus = tabGrid.CurrentQuery.Focused ? (Func<bool>)tabGrid.CurrentGridView.Focus : tabGrid.CurrentQuery.Focus;
                focus.Invoke();

                e.Handled = true;
            }
        }


        // Do forcibly Activate
        private void keyboardHook_KeyboardHooked(object sender, KeyboardHookedEventArgs e)
        {
            if ((ModifierKeys & Keys.Control) != Keys.Control) return;
            if (e.KeyCode != Keys.Q) return;

            WindowState = FormWindowState.Normal;
            SetForceFocus.PostMessage(new HandleRef(this, Handle), 0x400 + 1, (IntPtr)0, (IntPtr)0);
        }


        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x232)
            {
                Invalidate();
                PerformLayout();
            }
            if (m.Msg == 0x400 + 1) SetForceFocus.SetForceForegroundWindow(m.HWnd);

            base.WndProc(ref m);
        }


        private void Controller_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized) return;

            foreach (var v in tabGrid.ViewerCollection)
            {
                v.Value.WindowState = WindowState;
            }            
        }


        private void formBar_DBComboIndexChanged(object sender, EventArgs e)
        {
            SerialSqlManager[(ServerType)CurrentSVIndex].ChangeConnectingCatalog(formBar.DBcombo.Text);
        }


        public void SetAndExecuteSql(string sql = "")
        {
            if (!sqlManager.isConnected)
            {
                MessageBox.Show($"{formBar.SVCombo.Text}との接続が開かれていません。", "Reseacher");
                return;
            }

            if (sql != "") tabGrid.CurrentQuery.Text = sql;

            SqlRule rule = new SqlRule();
            SqlFormatter formatter = new SqlFormatter(rule);

            try
            {
                var xml = new XmlManager();
                if (xml[new List<string>() { "format" }, "False"].ToUpper().Equals("TRUE"))
                {
                    TabGrid.CurrentQuery.Text = formatter.Format(TabGrid.CurrentQuery.Text);
                }
            }
            catch { /* ignore */ }

            sqlManager.ExecuteSqlToServer(tabGrid.CurrentQuery.Text, tabGrid.CurrentTabIndex.ToString());
            tabGrid.CurrentGridView.DataSource = sqlManager.Tables[tabGrid.CurrentTabIndex.ToString()];

            tabGrid.CurrentQuery.SetSelection(tabGrid.CurrentQuery.Text.Length, tabGrid.CurrentQuery.Text.Length);
            RecCount = $"Rows : {TabGrid.CurrentGridView.Rows.Count} / Columns : {TabGrid.CurrentGridView.Columns.Count} ";
        }


        public void UpdateDataBaseComboItems()
        {
            if (!sqlManager.Tables.Contains("DataBase")) return;

            formBar.DBcombo.Items.Clear();
            foreach (DataRow r in sqlManager.Tables["DataBase"].Rows)
            {
                formBar.DBcombo.Items.Add(r["Name"]);
            }

            formBar.DBcombo.Text = sqlManager.Catalog;
        }


        private void formBar_SVComboIndexChanged(object sender, EventArgs e)
        {
            string sqlclass = GetSqlClass(formBar.SVCombo.Text);
            Cursor = Cursors.WaitCursor;

            try
            {
                var asm = Assembly.LoadFrom("newtype.Database.dll");
                if (!SerialSqlManager.ContainsKey((ServerType)formBar.SVCombo.SelectedIndex))
                {
                    SerialSqlManager[(ServerType)formBar.SVCombo.SelectedIndex] = (ISqlManager)asm.CreateInstance($"newtype.Database.{sqlclass}");
                }

                CurrentSVIndex = formBar.SVCombo.SelectedIndex;

                if (sqlManager.isConnected)
                {
                    UpdateDataBaseComboItems();
                    return;
                }

                if (sqlManager.ConnectToServer())
                {
                    UpdateDataBaseComboItems();
                }
                else
                {
                    FormBar.DBcombo.Items.Clear();
                    tabGrid_settingClick(sender, e);
                }
            }
            finally { Cursor = Cursors.Default; } 
        }


        private string GetSqlClass(string servarName)
        {
            switch (servarName)
            {
                case "SQLServer": return "SqlManager";
                case "MySQL": return "MySqlManager";
                case "PostgreSQL": return "PgSqlManager";
                default: return "";
            }
        }

        private void Controller_FormClosing(object sender, FormClosingEventArgs e)
        {
            sqlManager.SaveConnection();

            var xml = new XmlManager(false);

            xml[new List<string> { "defaultSV" }] = CurrentSVIndex.ToString();
            xml[new List<string> { "opacity" }] = Opacity.ToString();
            tabGrid.TabCollection.ForEach(t => xml[new List<string> { $"tab{t.Index}Text" }, $"table{t.Index + 1}"] = t.Text);
            tabGrid.TabCollection.ForEach(t => xml[new List<string> { $"tab{t.Index}Query" }] = tabGrid.QueryCollection[t.Index].Text);

            xml.Save();
            xml.Dispose();
        }

        #endregion


        #region Functions


        private void menuBar_F00_OpenKeyDown(object sender, EventArgs e)
        {
            var sql = FileManager.OpenSqlFileDialog();
            if (sql != null)
            {
                SetAndExecuteSql(sql);
            }
        }


        private void menuBar_F00_SaveKeyDown(object sender, EventArgs e)
        {
            FileManager.SaveSqlFileDialog(false, tabGrid.CurrentTabItem.Text, tabGrid.CurrentQuery.Text);
        }


        private void menuBar_F00_WriteKeyDown(object sender, EventArgs e)
        {
            FileManager.OutputCsvFile(tabGrid.CurrentGridView, tabGrid.CurrentTabItem.Text);
        }


        private void MenuBar_F00_AddComKeyDown(object sender, EventArgs e)
        {
            var select = tabGrid.CurrentQuery.GetSelectedText();
            if (select.Length.Equals(0)) return;

            var comment = select.Insert(0, "--").Replace("\r\n", "\r\n--");

            tabGrid.CurrentQuery.Text = tabGrid.CurrentQuery.Text.Replace(select, comment);
        }


        private void MenuBar_F00_DelComKeyDown(object sender, EventArgs e)
        {
            var select = tabGrid.CurrentQuery.GetSelectedText();
            if (select.Length.Equals(0)) return;

            var comment = select.Replace("\r\n--", "\r\n");
            if (comment.Substring(0, 2).Equals("--")) comment = comment.Substring(2);

            tabGrid.CurrentQuery.Text = tabGrid.CurrentQuery.Text.Replace(select, comment);
        }


        private void menuBar_F01_KeyDown(object sender, EventArgs e) { act.F01_Action(sender, e); }


        private void menuBar_F02_KeyDown(object sender, EventArgs e) { act.F02_Action(sender, e); }


        private void menuBar_F03_KeyDown(object sender, EventArgs e) { act.F03_Action(sender, e); }


        private void menuBar_F04_KeyDown(object sender, EventArgs e) { act.F04_Action(sender, e); }


        private void menuBar_F05_KeyDown(object sender, EventArgs e) { act.F05_Action(sender, e); }


        private void menuBar_F06_KeyDown(object sender, EventArgs e) { act.F06_Action(sender, e); }


        private void menuBar_F07_KeyDown(object sender, EventArgs e) { act.F07_Action(sender, e); }


        private void menuBar_F08_KeyDown(object sender, EventArgs e) { act.F08_Action(sender, e); }


        private void menuBar_F09_KeyDown(object sender, EventArgs e) { act.F09_Action(sender, e); }


        private void menuBar_F10_KeyDown(object sender, EventArgs e) { act.F10_Action(sender, e); }


        private void menuBar_F11_KeyDown(object sender, EventArgs e) { act.F11_Action(sender, e); }


        private void menuBar_F12_KeyDown(object sender, EventArgs e) { act.F12_Action(sender, e); }


        private void tabGrid_settingClick(object sender, EventArgs e)
        {
            var set = new SettingWindow(sqlManager.Server, FormBar.SVCombo.Text);
            set.ShowDialog();

            if (set.Result == null) return;
            
            sqlManager.Server = set.Result;
            if (sqlManager.ConnectToServer())
            {
                MessageBox.Show($"{formBar.SVCombo.Text}との接続に成功しました。");
                UpdateDataBaseComboItems();
            }
        }


        private void tabGrid_disconnectClick(object sender, EventArgs e)
        {
            sqlManager.DisConnect();
            MessageBox.Show($"{formBar.SVCombo.Text}の接続を終了しました。");

            formBar.DBcombo.Items.Clear();
        }

        #endregion
    }
}
