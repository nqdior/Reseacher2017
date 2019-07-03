using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newtype
{
    public partial class SettingWindow : Form
    {
        private object _object;

        public SettingWindow() { }

        public SettingWindow(object obj)
        {
            InitializeComponent();

            _object = obj;
            propertyGrid.SelectedObject = _object;
        }

        public new object Show()
        {
            ShowDialog();

            return propertyGrid == null
                ? _object
                : propertyGrid.SelectedObject; 
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            propertyGrid = null;
            throw new Exception();
        }

        private void SettingWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            cancelBtn_Click(sender, new EventArgs());
        }
    }
}
