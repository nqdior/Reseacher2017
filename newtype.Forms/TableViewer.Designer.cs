using newtype.Controls;

namespace newtype.Forms
{
    partial class TableViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableViewer));
            this.formBar = new newtype.Controls.FormBar();
            this.tableBrowser = new newtype.Controls.SeekGridView();
            this.tableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rows = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cols = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnBrowser = new newtype.Controls.SeekGridView();
            this.columnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.boolnull = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tableBrowser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnBrowser)).BeginInit();
            this.SuspendLayout();
            // 
            // formBar
            // 
            this.formBar.BackColor = System.Drawing.Color.Transparent;
            this.formBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.formBar.isController = false;
            this.formBar.Location = new System.Drawing.Point(5, 5);
            this.formBar.Name = "formBar";
            this.formBar.Size = new System.Drawing.Size(670, 28);
            this.formBar.TabIndex = 0;
            // 
            // tableBrowser
            // 
            this.tableBrowser.AllowUserToAddRows = false;
            this.tableBrowser.AllowUserToDeleteRows = false;
            this.tableBrowser.BackgroundColor = System.Drawing.Color.Black;
            this.tableBrowser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("游ゴシック", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableBrowser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tableBrowser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableBrowser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tableName,
            this.rows,
            this.cols});
            this.tableBrowser.DefaultCellStyle = dataGridViewCellStyle1;
            this.tableBrowser.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableBrowser.EnableHeadersVisualStyles = false;
            this.tableBrowser.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.tableBrowser.Location = new System.Drawing.Point(5, 33);
            this.tableBrowser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableBrowser.Name = "tableBrowser";
            this.tableBrowser.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.tableBrowser.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tableBrowser.RowHeadersWidth = 20;
            this.tableBrowser.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Black;
            this.tableBrowser.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.tableBrowser.RowTemplate.Height = 21;
            this.tableBrowser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableBrowser.Size = new System.Drawing.Size(285, 162);
            this.tableBrowser.TabIndex = 1;
            this.tableBrowser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableBrowser_CellClick);
            this.tableBrowser.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tableBrowser_CellDoubleClick);
            // 
            // tableName
            // 
            this.tableName.FillWeight = 120F;
            this.tableName.HeaderText = "Table";
            this.tableName.Name = "tableName";
            this.tableName.ReadOnly = true;
            this.tableName.Width = 120;
            // 
            // rows
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.rows.DefaultCellStyle = dataGridViewCellStyle2;
            this.rows.FillWeight = 60F;
            this.rows.HeaderText = "Rows";
            this.rows.Name = "rows";
            this.rows.ReadOnly = true;
            this.rows.Width = 60;
            // 
            // cols
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cols.DefaultCellStyle = dataGridViewCellStyle3;
            this.cols.FillWeight = 60F;
            this.cols.HeaderText = "Column";
            this.cols.Name = "cols";
            this.cols.ReadOnly = true;
            this.cols.Width = 60;
            // 
            // columnBrowser
            // 
            this.columnBrowser.AllowUserToAddRows = false;
            this.columnBrowser.AllowUserToDeleteRows = false;
            this.columnBrowser.BackgroundColor = System.Drawing.Color.Black;
            this.columnBrowser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("游ゴシック", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.columnBrowser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.columnBrowser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.columnBrowser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnName,
            this.type,
            this.length,
            this.boolnull,
            this.pk});
            this.columnBrowser.DefaultCellStyle = dataGridViewCellStyle4;
            this.columnBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.columnBrowser.EnableHeadersVisualStyles = false;
            this.columnBrowser.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.columnBrowser.Location = new System.Drawing.Point(290, 33);
            this.columnBrowser.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.columnBrowser.Name = "columnBrowser";
            this.columnBrowser.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.columnBrowser.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.columnBrowser.RowHeadersWidth = 20;
            this.columnBrowser.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Black;
            this.columnBrowser.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.columnBrowser.RowTemplate.Height = 21;
            this.columnBrowser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.columnBrowser.Size = new System.Drawing.Size(385, 162);
            this.columnBrowser.TabIndex = 2;
            // 
            // columnName
            // 
            this.columnName.FillWeight = 120F;
            this.columnName.HeaderText = "Column";
            this.columnName.Name = "columnName";
            this.columnName.ReadOnly = true;
            this.columnName.Width = 120;
            // 
            // type
            // 
            this.type.FillWeight = 70F;
            this.type.HeaderText = "Type";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Width = 70;
            // 
            // length
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.length.DefaultCellStyle = dataGridViewCellStyle5;
            this.length.FillWeight = 70F;
            this.length.HeaderText = "Length";
            this.length.Name = "length";
            this.length.ReadOnly = true;
            this.length.Width = 70;
            // 
            // boolnull
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.boolnull.DefaultCellStyle = dataGridViewCellStyle6;
            this.boolnull.FillWeight = 40F;
            this.boolnull.HeaderText = "Null";
            this.boolnull.Name = "boolnull";
            this.boolnull.ReadOnly = true;
            this.boolnull.Width = 40;
            // 
            // pk
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.pk.DefaultCellStyle = dataGridViewCellStyle7;
            this.pk.FillWeight = 40F;
            this.pk.HeaderText = "PK";
            this.pk.Name = "pk";
            this.pk.ReadOnly = true;
            this.pk.Width = 40;
            // 
            // TableViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(680, 200);
            this.Controls.Add(this.columnBrowser);
            this.Controls.Add(this.tableBrowser);
            this.Controls.Add(this.formBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TableViewer";
            this.Opacity = 0.6D;
            this.Text = "TableViewer";
            this.Load += new System.EventHandler(this.TableViewer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TableViewer_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tableBrowser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnBrowser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FormBar formBar;
        private SeekGridView tableBrowser;
        private SeekGridView columnBrowser;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn rows;
        private System.Windows.Forms.DataGridViewTextBoxColumn cols;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn length;
        private System.Windows.Forms.DataGridViewTextBoxColumn boolnull;
        private System.Windows.Forms.DataGridViewTextBoxColumn pk;
    }
}