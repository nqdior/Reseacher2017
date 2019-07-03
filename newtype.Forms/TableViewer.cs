using newtype.Common;
using newtype.Controls;
using newtype.Database;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using newtype.Interface;

namespace newtype.Forms
{
    public partial class TableViewer : BaseWindow
    {
        private ISqlManager _sqlManager;

        private IController _controller;

        public TableViewer()
        {
            InitializeComponent();
        }


        public TableViewer(IController controller)
        {
            InitializeComponent();
            KeyPreview = true;

            _controller = controller;
            _sqlManager = _controller.sqlManager;
        }


        private void TableViewer_Load(object sender, EventArgs e)
        {
            if (!_sqlManager.GetTables() || !_sqlManager.GetColumns()) return;
            foreach (var dt in _sqlManager.Tables["Tables"].AsEnumerable())
            {
                tableBrowser.Rows.Add(dt["Name"], dt["Rows"], dt["Columns"]);
            }
            formBar.title.Text += $" - {_sqlManager.Catalog}";
        }


        private void TableViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) Close();
            if (tableBrowser.CurrentCell == null) return; 

            // Open Table
            var ex = new DataGridViewCellEventArgs(tableBrowser.CurrentCell.ColumnIndex, tableBrowser.CurrentCell.RowIndex);
            if (e.KeyData == Keys.Enter || e.KeyCode == Keys.Enter && e.Control == true)
            {
                tableBrowser_CellClick(sender, ex);
                tableBrowser_CellDoubleClick(sender, ex);

                e.Handled = true;
            }

            // ShowColumns
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
            {
                tableBrowser_CellClick(sender, ex);

                e.Handled = true;
            }

            // Jump TableNames
            if (e.KeyData.ToString().Length == 1 && StringManager.IsUpperLatin(e.KeyData.ToString()[0]))
            {
                foreach(DataGridViewRow r in tableBrowser.Rows)
                {
                    if (r.Index <= tableBrowser.CurrentRow.Index) continue;
                    if (r.Cells[0].Value.ToString().ToUpper().Substring(0, 1).Equals(e.KeyData.ToString().Substring(0, 1)))
                    {
                        tableBrowser.FirstDisplayedScrollingRowIndex = r.Index;
                        tableBrowser.CurrentCell = r.Cells[0];
                        break;
                    }
                }
                e.Handled = true;
            }
        }


        private void tableBrowser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            columnBrowser.Rows.Clear();
            if (e.RowIndex < 0) return; 

            var tableName = tableBrowser[0, e.RowIndex].Value.ToString();
            var columns = _sqlManager.Tables["Columns"].AsEnumerable().Where(row => row.Field<string>("tableName").Equals(tableName)).ToList();

            columns.ForEach(row => columnBrowser.Rows.Add(
                                    row?["columnName"],
                                    row?["type"],
                                    row?["length"],
                                    row?["boolnull"],
                                    row?["PK"]));
        }


        private void tableBrowser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string tableName = tableBrowser[0, e.RowIndex].Value.ToString();
            string sql = CreateSqlCommand(tableName);

            _controller.SetAndExecuteSql(sql);
        }


        private string CreateSqlCommand(string tableName)
        {
            string sql = string.Empty;

            if (ModifierKeys == Keys.Control)
            {
                sql = "SELECT ";
                foreach (DataGridViewRow dr in columnBrowser.Rows)
                {
                    sql += $"{dr.Cells[0].Value.ToString()}, ";
                }
                sql = sql.Substring(0, sql.Length - 2);
                sql += $" FROM {tableName}";
            }
            else
            {
                sql = $"SELECT * FROM {tableName}";
            }
            return sql;
        }
    }
}
