using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newtype.Forms
{
    public partial class OpacityWindow : Form
    {
        Form form;

        public OpacityWindow(Form form)
        {
            InitializeComponent();

            this.form = form;
            KeyPreview = true;
            trackBar1.Value = (int)(form.Opacity * 10);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            form.Opacity = trackBar1.Value * 0.1;
        }

        private void OpacityWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
