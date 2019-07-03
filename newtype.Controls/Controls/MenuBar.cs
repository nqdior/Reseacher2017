using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace newtype.Controls
{
    public partial class MenuBar : UserControl
    {

        public MenuBar()
        {
            InitializeComponent();
        }

        public event EventHandler F01_KeyDown;

        public event EventHandler F02_KeyDown;

        public event EventHandler F03_KeyDown;

        public event EventHandler F04_KeyDown;

        public event EventHandler F05_KeyDown;

        public event EventHandler F06_KeyDown;

        public event EventHandler F07_KeyDown;

        public event EventHandler F08_KeyDown;

        public event EventHandler F09_KeyDown;

        public event EventHandler F10_KeyDown;

        public event EventHandler F11_KeyDown;

        public event EventHandler F12_KeyDown;

        public event EventHandler F00_OpenKeyDown;

        public event EventHandler F00_SaveKeyDown;

        public event EventHandler F00_WriteKeyDown;

        public event EventHandler F00_AddComKeyDown;

        public event EventHandler F00_DelComKeyDown;


        [Category("Image")]
        public Image F01_Image { get { return F01.Image; } set { F01.Image = value; } }

        [Category("Image")]
        public Image F02_Image { get { return F02.Image; } set { F02.Image = value; } }

        [Category("Image")]
        public Image F03_Image { get { return F03.Image; } set { F03.Image = value; } }

        [Category("Image")]
        public Image F04_Image { get { return F04.Image; } set { F04.Image = value; } }

        [Category("Image")]
        public Image F05_Image { get { return F05.Image; } set { F05.Image = value; } }

        [Category("Image")]
        public Image F06_Image { get { return F06.Image; } set { F06.Image = value; } }

        [Category("Image")]
        public Image F07_Image { get { return F07.Image; } set { F07.Image = value; } }

        [Category("Image")]
        public Image F08_Image { get { return F08.Image; } set { F08.Image = value; } }

        [Category("Image")]
        public Image F09_Image { get { return F09.Image; } set { F09.Image = value; } }

        [Category("Image")]
        public Image F10_Image { get { return F10.Image; } set { F10.Image = value; } }

        [Category("Image")]
        public Image F11_Image { get { return F11.Image; } set { F11.Image = value; } }

        [Category("Image")]
        public Image F12_Image { get { return F12.Image; } set { F12.Image = value; } }


        private void F1_Tables_Click(object sender, EventArgs e)
        {
            F01_KeyDown?.Invoke(sender, e);
        }


        private void F2_Rename_Click(object sender, EventArgs e)
        {
            F02_KeyDown?.Invoke(sender, e);
        }


        private void F3_Search_Click(object sender, EventArgs e)
        {
            F03_KeyDown?.Invoke(sender, e);
        }


        private void F4_BarVisible_Click(object sender, EventArgs e)
        {
            F04_KeyDown?.Invoke(sender, e);
        }


        private void F5_Execute_Click(object sender, EventArgs e)
        {
            F05_KeyDown?.Invoke(sender, e);
        }


        private void F6_MoveFocus_Click(object sender, EventArgs e)
        {
            F06_KeyDown?.Invoke(sender, e);
        }


        private void F7_Combo_Click(object sender, EventArgs e)
        {
            F07_KeyDown?.Invoke(sender, e);
        }


        private void F8_Update_Click(object sender, EventArgs e)
        {
            F08_KeyDown?.Invoke(sender, e);
        }


        private void F9_Opacity_Click(object sender, EventArgs e)
        {
            F09_KeyDown?.Invoke(sender, e);
        }


        private void F10_TopMost_Click(object sender, EventArgs e)
        {
            F10_KeyDown?.Invoke(sender, e);
        }


        private void F11_FullScreen_Click(object sender, EventArgs e)
        {
            F11_KeyDown?.Invoke(sender, e);
        }


        private void F12_Setting_Click(object sender, EventArgs e)
        {
            F12_KeyDown?.Invoke(sender, e);
        }


        private void F00Open_Click(object sender, EventArgs e)
        {
            F00_OpenKeyDown?.Invoke(sender, e);
        }


        private void F00Save_Click(object sender, EventArgs e)
        {
            F00_SaveKeyDown?.Invoke(sender, e);
        }


        private void F00OWrite_Click(object sender, EventArgs e)
        {
            F00_WriteKeyDown?.Invoke(sender, e);
        }


        private void F00AdCom_Click(object sender, EventArgs e)
        {
            F00_AddComKeyDown?.Invoke(sender, e);
        }


        private void F00UnCom_Click(object sender, EventArgs e)
        {
            F00_DelComKeyDown?.Invoke(sender, e);
        }

    }
}
