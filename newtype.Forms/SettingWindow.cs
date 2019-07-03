using System;
using System.Windows.Forms;

namespace newtype.Forms
{
    public partial class SettingWindow : Form
    {
        private object _object;

        public object Result { get { return propertyGrid.SelectedObject; } }

        public SettingWindow() { }

        public SettingWindow(object obj, string serverType)
        {
            InitializeComponent();

            _object = obj;
            comboBox1.Text = serverType;
            propertyGrid.SelectedObject = _object;

            KeyPreview = true;
        }

        private void SettingWindow_Load(object sender, EventArgs e)
        {
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            propertyGrid.SelectedObject = null;
            Close();
        }

        private void SettingWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Escape) return;
            cancelBtn_Click(sender, new EventArgs());
        }
    }
}
