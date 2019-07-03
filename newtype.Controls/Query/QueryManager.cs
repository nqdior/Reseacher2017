using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Sgry.Azuki.WinForms;
using Sgry.Azuki;

namespace newtype.Controls
{
    public static class Enhance
    {
        public static AzukiControl ClearText(this AzukiControl azuki)
        {
            azuki.Text = string.Empty;

            return azuki;
        }

        public static AzukiControl RemakeText(this AzukiControl azuki, bool isUseNewline = false)
        {
            FreeView.Sql.SqlRule rule = new FreeView.Sql.SqlRule();
            rule.IndentString = isUseNewline ? "    " : "";

            FreeView.Sql.SqlFormatter formatter = new FreeView.Sql.SqlFormatter(rule);
            azuki.Text = formatter.Format(azuki.Text);

            if (!isUseNewline) { azuki.Text = azuki.Text.Replace(System.Environment.NewLine, " "); };

            return azuki;
        }
    }

    public static class QueryManager
    {
        private static List<string> SqlKeywords = new List<string>();

        public static SQLKeywordHighlighter LoadHighlighter()
        {
            SqlKeywords = new List<string>();
            LoadKeywordFile();

            SQLKeywordHighlighter hilighter = new SQLKeywordHighlighter();
            hilighter.AddKeywordSet(SqlKeywords.ToArray(), CharClass.Keyword, true);

            return hilighter;
        }

        private static List<string> LoadKeywordFile()
        {
            const string SQLKeywordFileName = "SQLKeyword.xml";

            try
            {
                if (File.Exists(Application.StartupPath + @"\Query\" + SQLKeywordFileName))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(Application.StartupPath + @"\Query\" + SQLKeywordFileName);
                    XmlNodeList nodeKeywords = doc.SelectNodes("/keywords/keyword");
                    if (nodeKeywords != null)
                    {
                        foreach (XmlNode nodeKeyword in nodeKeywords)
                        {
                            string value = string.Empty;
                            if (nodeKeyword.ChildNodes.Count > 0)
                            {
                                value = nodeKeyword.ChildNodes[0].Value;
                            }
                            if (value != string.Empty)
                            {
                                SqlKeywords.Add(value);
                            }
                        }
                    }
                }
                return SqlKeywords;
            }
            catch { return null; }
        }
    }
}
