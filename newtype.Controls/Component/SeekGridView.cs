using System.Windows.Forms;
using System.Drawing;

namespace newtype.Controls
{
    public partial class SeekGridView : DataGridView
    {
        public SeekGridView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            var dgvCellStyle = new DataGridViewCellStyle();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            SuspendLayout();
            // 
            // SeekGridView
            // 
            BackgroundColor = Color.Black;
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dgvCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyle.BackColor = Color.Black;
            dgvCellStyle.Font = new Font("游ゴシック", 8F, FontStyle.Bold, GraphicsUnit.Point, 128);
            dgvCellStyle.ForeColor = Color.White;
            dgvCellStyle.SelectionBackColor = SystemColors.Highlight;
            dgvCellStyle.SelectionForeColor = SystemColors.HighlightText;
            dgvCellStyle.WrapMode = DataGridViewTriState.True;
            ColumnHeadersDefaultCellStyle = dgvCellStyle;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DefaultCellStyle = dgvCellStyle;
            Dock = DockStyle.Fill;
            EnableHeadersVisualStyles = false;
            GridColor = SystemColors.ActiveBorder;
            Margin = new Padding(3, 4, 3, 4);
            Name = "dataGridView1";
            RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            RowHeadersDefaultCellStyle = dgvCellStyle;
            RowTemplate.DefaultCellStyle.BackColor = Color.Black;
            RowTemplate.DefaultCellStyle.ForeColor = Color.White;
            RowTemplate.Height = 21;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            ResumeLayout(false);
        }
    }
}
