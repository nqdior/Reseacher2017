using newtype.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newtype.Controls
{

    public partial class DataViewer : BaseWindow
    {

        private int Index;

        private TabGridControl _tabGridControl;

        private SeekGridView _seekGridView;


        public DataViewer()
        {
            InitializeComponent();
        }


        internal void FocusSeekGridView()
        {
            _seekGridView.Focus();
        }


        internal DataViewer(SeekGridView seekGridView, TabGridControl tabGridControl)
        {
            Controls.Add(seekGridView);
            InitializeComponent();

            _tabGridControl = tabGridControl;
            _seekGridView = seekGridView;
            Index = tabGridControl.CurrentTabIndex;
        }


        private void DataViewer_Activated(object sender, EventArgs e)
        {
            _tabGridControl.TabActivate(Index);
        }


        private void DataViewer_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            formBar.title.Text += $" - {_tabGridControl.CurrentTabItem.Text}";
        }


        private void SubWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            // back to parent
            _tabGridControl.ReturnSeekGridView(_seekGridView, Index);
        }

        private void DataViewer_KeyDown(object sender, KeyEventArgs e)
        {
            if ((ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                _tabGridControl.CurrentQuery.Focus();
                e.Handled = true;
            }
        }
    }
}
