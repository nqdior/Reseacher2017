using System;
using newtype.Forms;
using System.Windows.Forms;

namespace newtype
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var main = new Controller();
            Logo.ShowSplash(main);

            Application.Run(main);
        }
    }
}
