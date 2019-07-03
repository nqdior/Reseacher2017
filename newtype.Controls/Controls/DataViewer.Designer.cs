namespace newtype.Controls
{
    partial class DataViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataViewer));
            this.formBar = new newtype.Controls.FormBar();
            this.SuspendLayout();
            // 
            // formBar
            // 
            this.formBar.BackColor = System.Drawing.Color.Transparent;
            this.formBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.formBar.isController = false;
            this.formBar.Location = new System.Drawing.Point(6, 7);
            this.formBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.formBar.Name = "formBar";
            this.formBar.Size = new System.Drawing.Size(539, 37);
            this.formBar.TabIndex = 2;
            // 
            // DataViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(551, 307);
            this.Controls.Add(this.formBar);
            this.Font = new System.Drawing.Font("游ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DataViewer";
            this.Opacity = 0.6D;
            this.Padding = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
            this.Text = "DataViewer";
            this.Activated += new System.EventHandler(this.DataViewer_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SubWindow_FormClosing);
            this.Load += new System.EventHandler(this.DataViewer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataViewer_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.FormBar formBar;
    }
}