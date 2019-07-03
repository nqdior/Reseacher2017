using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System;

namespace newtype.Controls
{

    public class SeekStripMenuItem : ToolStripMenuItem
    {

        public int Index { get; private set; }


        public SeekStripMenuItem()
        {
            ForeColor = Color.White;
            Index = 99;
        }


        public SeekStripMenuItem(int index)
        {
            Index = index;
            Text = "table" + (index + 1).ToString();
            ForeColor = Color.White;

            if (index >= 10) return; // index 0 to 9 then ShortCutKey Add
            string keyNo = (index + 1) <= 9 ? (index + 1).ToString() : "0";

            ShortcutKeys = (Keys.Control | ConvertStringToKeys($"D{keyNo}"));
        }


        private Keys ConvertStringToKeys(string keys)
        {
            var converter = TypeDescriptor.GetConverter(typeof(Keys));
            return (Keys)converter.ConvertFromString(keys);
        }


        private ToolStripTextBox toolText = new ToolStripTextBox("toolText");
         

        public void ShowRename()
        {
            DropDownItems.Add(toolText);

            DropDownClosed += This_DropDownClosed;
            toolText.KeyDown += new KeyEventHandler(This_KeyDown);
            toolText.Text = Text;

            ShowDropDown();
            toolText.Focus();
        }


        private void This_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter) DropDown.Close();
        }


        private void This_DropDownClosed(object sender, EventArgs e)
        {
            Text = toolText.Text;
            DropDownItems.Remove(DropDownItems["toolText"]);
        }

    }
}