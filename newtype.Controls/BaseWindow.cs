using System.ComponentModel;
using System.Windows.Forms;

namespace newtype.Controls
{
    public partial class BaseWindow : Form
    {
        private bool movable = true;
        private bool resizeble = true;
        private Proc resize;
        private delegate void Proc(ref Message m, Form f);

        [Category("Form")]
        public bool Movable
        {
            get { return movable; }
            set
            {
                movable = value;

                if (movable)
                {
                    MouseDown += BaseForm_MouseDown;
                }
                else
                {
                    MouseDown -= BaseForm_MouseDown;
                }
            } 
        }

        [Category("Form")]
        public bool Resizeble
        {
            get
            {
                return resizeble;
            }
            set
            {
                resizeble = value;

                if (resizeble)
                {
                    resize = WindowManager.ConvertMessagePoint;
                }
                else
                {
                    resize = null;
                }
            }
        }

        public BaseWindow()
        {
            InitializeComponent();
            resize = WindowManager.ConvertMessagePoint;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            resize?.Invoke(ref m, this);
        }

        private void BaseForm_MouseDown(object sender, MouseEventArgs e)
        {
            WindowManager.ConvertMessageMove(e, Handle);
        }
    }
}
