using System;
using System.Windows.Forms;
using newtype.Forms;
using newtype.Interface;
using newtype.Common;
using System.Collections.Generic;

namespace newtype.Actions
{
    public class Actions : IActions
    {
        private TableViewer tableViewer = null;

        private IController _controller;

        public Actions(IController controller)
        {
            _controller = controller;
        }

        public void F01_Action(object sender, EventArgs e)
        {
            if (!_controller.sqlManager.isConnected)
            {
                MessageBox.Show($"{_controller.FormBar.SVCombo.Text}との接続が開かれていません。", "Reseacher");
                return;
            }

            if (tableViewer == null || tableViewer.IsDisposed)
            {
                tableViewer = new TableViewer(_controller);
                tableViewer.Opacity = ((Form)_controller).Opacity;
                tableViewer.Show();
            }
            else
            {
                tableViewer.Activate();
            }
        }

        public void F02_Action(object sender, EventArgs e)
        {
            _controller.TabGrid.TabCollection[_controller.TabGrid.CurrentTabIndex].ShowRename();
        }

        public void F03_Action(object sender, EventArgs e)
        {
            if (_controller.TabGrid.CurrentGridView.CurrentCell == null) return;

            var F3_Search = ((ToolStripMenuItem)sender);
            var toolText = new ToolStripTextBox("toolText");
            F3_Search.DropDownItems.Add(toolText);

            _controller.TabGrid.CurrentGridView.CurrentCell = _controller.TabGrid.CurrentGridView.Rows[0].Cells[0];

            toolText.KeyDown += (object _sender, KeyEventArgs _e) =>
            {
                if (_e.KeyCode == Keys.Enter) FocusDataGridViewCell(toolText.Text);
                toolText.KeyDown += null;
            };

            F3_Search.DropDownClosed += (object _sender, EventArgs _e) =>
            {
                F3_Search.DropDownItems.Remove(F3_Search.DropDownItems["toolText"]);
            };

            F3_Search.ShowDropDown();
            toolText.Focus();
        }

        private void FocusDataGridViewCell(string keyword)
        {
            var firstSelectRowIndex = true;
            if (_controller.TabGrid.CurrentGridView.DataSource == null) return;

            var dgv = _controller.TabGrid.CurrentGridView;

            foreach (DataGridViewRow dr in dgv.Rows)
            {
                if (dgv.CurrentCell == null) return;
                if (dr.Index <= dgv.CurrentCell.RowIndex) continue;

                foreach (DataGridViewColumn dc in dgv.Columns)
                {
                    dr.Cells[dc.Name].Selected = false;
                    if (dr.Cells[dc.Name].Value == null) { continue; }
                    string data = dr.Cells[dc.Name].Value.ToString();

                    // Find
                    if (data.IndexOf(keyword) == -1) { continue; }

                    dr.Cells[dc.Name].Selected = true;

                    // First Index
                    if (firstSelectRowIndex)
                    {
                        firstSelectRowIndex = false;
                        dgv.CurrentCell = dr.Cells[dc.Name];
                        dgv.FirstDisplayedScrollingRowIndex = dr.Cells[dc.Name].RowIndex;
                    }
                }
            }
        }


        public void F04_Action(object sender, EventArgs e)
        {
            _controller.MenuBar.Visible = !_controller.MenuBar.Visible;
        }

        public void F05_Action(object sender, EventArgs e)
        {
            _controller.SetAndExecuteSql();
        }

        public void F06_Action(object sender, EventArgs e)
        {
            _controller.FormBar.SVCombo.Focus();
        }

        public void F07_Action(object sender, EventArgs e)
        {
            _controller.FormBar.DBcombo.Focus();
        }

        public void F08_Action(object sender, EventArgs e)
        {
            if (!_controller.sqlManager.isConnected)
            {
                MessageBox.Show($"{_controller.FormBar.SVCombo.Text}との接続が開かれていません。", "Reseacher");
                return;
            }

            if (_controller.sqlManager.UpdateDataToSqlServer(
                _controller.TabGrid.CurrentTabIndex.ToString(), 
                _controller.TabGrid.CurrentQuery.Text))
            {
                MessageBox.Show("データベースへの反映に成功しました。");
            }
        }

        public void F09_Action(object sender, EventArgs e)
        {
            var t = new OpacityWindow((Form)_controller);
            t.ShowDialog();
        }

        public void F10_Action(object sender, EventArgs e)
        {
            _controller.FormBar.topMost.PerformClick();
        }

        public void F11_Action(object sender, EventArgs e)
        {
            ((Form)_controller).WindowState = ((Form)_controller).WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
        }

        public void F12_Action(object sender, EventArgs e)
        {

        }
    }
}
