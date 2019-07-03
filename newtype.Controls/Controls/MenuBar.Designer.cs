namespace newtype.Controls
{
    partial class MenuBar
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuBar));
            this.menuBarBase = new System.Windows.Forms.MenuStrip();
            this.F00Open = new System.Windows.Forms.ToolStripMenuItem();
            this.F00Save = new System.Windows.Forms.ToolStripMenuItem();
            this.F00OWrite = new System.Windows.Forms.ToolStripMenuItem();
            this.sep = new System.Windows.Forms.ToolStripSeparator();
            this.F00AdCom = new System.Windows.Forms.ToolStripMenuItem();
            this.F00UnCom = new System.Windows.Forms.ToolStripMenuItem();
            this.sep2 = new System.Windows.Forms.ToolStripSeparator();
            this.F01 = new System.Windows.Forms.ToolStripMenuItem();
            this.F02 = new System.Windows.Forms.ToolStripMenuItem();
            this.F03 = new System.Windows.Forms.ToolStripMenuItem();
            this.F04 = new System.Windows.Forms.ToolStripMenuItem();
            this.sep3 = new System.Windows.Forms.ToolStripSeparator();
            this.F05 = new System.Windows.Forms.ToolStripMenuItem();
            this.F06 = new System.Windows.Forms.ToolStripMenuItem();
            this.F07 = new System.Windows.Forms.ToolStripMenuItem();
            this.F08 = new System.Windows.Forms.ToolStripMenuItem();
            this.sep4 = new System.Windows.Forms.ToolStripSeparator();
            this.F09 = new System.Windows.Forms.ToolStripMenuItem();
            this.F10 = new System.Windows.Forms.ToolStripMenuItem();
            this.F11 = new System.Windows.Forms.ToolStripMenuItem();
            this.F12 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBarBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuBarBase
            // 
            this.menuBarBase.BackColor = System.Drawing.Color.Black;
            this.menuBarBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuBarBase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.menuBarBase.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.F00Open,
            this.F00Save,
            this.F00OWrite,
            this.sep,
            this.F00AdCom,
            this.F00UnCom,
            this.sep2,
            this.F01,
            this.F02,
            this.F03,
            this.F04,
            this.sep3,
            this.F05,
            this.F06,
            this.F07,
            this.F08,
            this.sep4,
            this.F09,
            this.F10,
            this.F11,
            this.F12});
            this.menuBarBase.Location = new System.Drawing.Point(0, 0);
            this.menuBarBase.Name = "menuBarBase";
            this.menuBarBase.Size = new System.Drawing.Size(518, 32);
            this.menuBarBase.TabIndex = 5;
            this.menuBarBase.Text = "menuStrip1";
            // 
            // F00Open
            // 
            this.F00Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.F00Open.Image = ((System.Drawing.Image)(resources.GetObject("F00Open.Image")));
            this.F00Open.Name = "F00Open";
            this.F00Open.Size = new System.Drawing.Size(28, 28);
            this.F00Open.Text = "n";
            this.F00Open.Click += new System.EventHandler(this.F00Open_Click);
            // 
            // F00Save
            // 
            this.F00Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.F00Save.Image = ((System.Drawing.Image)(resources.GetObject("F00Save.Image")));
            this.F00Save.Name = "F00Save";
            this.F00Save.Size = new System.Drawing.Size(28, 28);
            this.F00Save.Text = "o";
            this.F00Save.Click += new System.EventHandler(this.F00Save_Click);
            // 
            // F00OWrite
            // 
            this.F00OWrite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.F00OWrite.Image = ((System.Drawing.Image)(resources.GetObject("F00OWrite.Image")));
            this.F00OWrite.Name = "F00OWrite";
            this.F00OWrite.Size = new System.Drawing.Size(28, 28);
            this.F00OWrite.Text = "s";
            this.F00OWrite.Click += new System.EventHandler(this.F00OWrite_Click);
            // 
            // sep
            // 
            this.sep.Name = "sep";
            this.sep.Size = new System.Drawing.Size(6, 28);
            // 
            // F00AdCom
            // 
            this.F00AdCom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.F00AdCom.Image = ((System.Drawing.Image)(resources.GetObject("F00AdCom.Image")));
            this.F00AdCom.Name = "F00AdCom";
            this.F00AdCom.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.F00AdCom.Size = new System.Drawing.Size(28, 28);
            this.F00AdCom.Text = "a";
            this.F00AdCom.Click += new System.EventHandler(this.F00AdCom_Click);
            // 
            // F00UnCom
            // 
            this.F00UnCom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.F00UnCom.Image = ((System.Drawing.Image)(resources.GetObject("F00UnCom.Image")));
            this.F00UnCom.Name = "F00UnCom";
            this.F00UnCom.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.F00UnCom.Size = new System.Drawing.Size(28, 28);
            this.F00UnCom.Text = "u";
            this.F00UnCom.Click += new System.EventHandler(this.F00UnCom_Click);
            // 
            // sep2
            // 
            this.sep2.Name = "sep2";
            this.sep2.Size = new System.Drawing.Size(6, 28);
            // 
            // F01
            // 
            this.F01.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.F01.Image = ((System.Drawing.Image)(resources.GetObject("F01.Image")));
            this.F01.Name = "F01";
            this.F01.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.F01.Size = new System.Drawing.Size(28, 28);
            this.F01.Text = "F1";
            this.F01.Click += new System.EventHandler(this.F1_Tables_Click);
            // 
            // F02
            // 
            this.F02.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.F02.Image = ((System.Drawing.Image)(resources.GetObject("F02.Image")));
            this.F02.Name = "F02";
            this.F02.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.F02.Size = new System.Drawing.Size(28, 28);
            this.F02.Text = "F2";
            this.F02.Click += new System.EventHandler(this.F2_Rename_Click);
            // 
            // F03
            // 
            this.F03.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.F03.Image = ((System.Drawing.Image)(resources.GetObject("F03.Image")));
            this.F03.Name = "F03";
            this.F03.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.F03.Size = new System.Drawing.Size(28, 28);
            this.F03.Text = "F3";
            this.F03.Click += new System.EventHandler(this.F3_Search_Click);
            // 
            // F04
            // 
            this.F04.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.F04.Image = ((System.Drawing.Image)(resources.GetObject("F04.Image")));
            this.F04.Name = "F04";
            this.F04.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.F04.Size = new System.Drawing.Size(28, 28);
            this.F04.Text = "F4";
            this.F04.Click += new System.EventHandler(this.F4_BarVisible_Click);
            // 
            // sep3
            // 
            this.sep3.Name = "sep3";
            this.sep3.Size = new System.Drawing.Size(6, 28);
            // 
            // F05
            // 
            this.F05.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.F05.Image = ((System.Drawing.Image)(resources.GetObject("F05.Image")));
            this.F05.Name = "F05";
            this.F05.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.F05.Size = new System.Drawing.Size(28, 28);
            this.F05.Text = "F5";
            this.F05.Click += new System.EventHandler(this.F5_Execute_Click);
            // 
            // F06
            // 
            this.F06.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.F06.Image = ((System.Drawing.Image)(resources.GetObject("F06.Image")));
            this.F06.Name = "F06";
            this.F06.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.F06.Size = new System.Drawing.Size(28, 28);
            this.F06.Text = "F6";
            this.F06.Click += new System.EventHandler(this.F6_MoveFocus_Click);
            // 
            // F07
            // 
            this.F07.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.F07.Image = ((System.Drawing.Image)(resources.GetObject("F07.Image")));
            this.F07.Name = "F07";
            this.F07.ShortcutKeys = System.Windows.Forms.Keys.F7;
            this.F07.Size = new System.Drawing.Size(28, 28);
            this.F07.Text = "F7";
            this.F07.Click += new System.EventHandler(this.F7_Combo_Click);
            // 
            // F08
            // 
            this.F08.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.F08.Image = ((System.Drawing.Image)(resources.GetObject("F08.Image")));
            this.F08.Name = "F08";
            this.F08.ShortcutKeys = System.Windows.Forms.Keys.F8;
            this.F08.Size = new System.Drawing.Size(28, 28);
            this.F08.Text = "F8";
            this.F08.Click += new System.EventHandler(this.F8_Update_Click);
            // 
            // sep4
            // 
            this.sep4.Name = "sep4";
            this.sep4.Size = new System.Drawing.Size(6, 28);
            // 
            // F09
            // 
            this.F09.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.F09.Image = ((System.Drawing.Image)(resources.GetObject("F09.Image")));
            this.F09.Name = "F09";
            this.F09.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.F09.Size = new System.Drawing.Size(28, 28);
            this.F09.Text = "F9";
            this.F09.Click += new System.EventHandler(this.F9_Opacity_Click);
            // 
            // F10
            // 
            this.F10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.F10.Image = ((System.Drawing.Image)(resources.GetObject("F10.Image")));
            this.F10.Name = "F10";
            this.F10.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.F10.Size = new System.Drawing.Size(28, 28);
            this.F10.Text = "F10";
            this.F10.Click += new System.EventHandler(this.F10_TopMost_Click);
            // 
            // F11
            // 
            this.F11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.F11.Image = ((System.Drawing.Image)(resources.GetObject("F11.Image")));
            this.F11.Name = "F11";
            this.F11.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.F11.Size = new System.Drawing.Size(28, 28);
            this.F11.Text = "F11";
            this.F11.Click += new System.EventHandler(this.F11_FullScreen_Click);
            // 
            // F12
            // 
            this.F12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.F12.Image = ((System.Drawing.Image)(resources.GetObject("F12.Image")));
            this.F12.Name = "F12";
            this.F12.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.F12.Size = new System.Drawing.Size(28, 28);
            this.F12.Text = "F12";
            this.F12.Click += new System.EventHandler(this.F12_Setting_Click);
            // 
            // MenuBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuBarBase);
            this.Name = "MenuBar";
            this.Size = new System.Drawing.Size(518, 32);
            this.menuBarBase.ResumeLayout(false);
            this.menuBarBase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuBarBase;
        private System.Windows.Forms.ToolStripMenuItem F01;
        private System.Windows.Forms.ToolStripMenuItem F02;
        private System.Windows.Forms.ToolStripMenuItem F03;
        private System.Windows.Forms.ToolStripMenuItem F04;
        private System.Windows.Forms.ToolStripSeparator sep3;
        private System.Windows.Forms.ToolStripMenuItem F05;
        private System.Windows.Forms.ToolStripMenuItem F06;
        private System.Windows.Forms.ToolStripMenuItem F07;
        private System.Windows.Forms.ToolStripMenuItem F08;
        private System.Windows.Forms.ToolStripSeparator sep4;
        private System.Windows.Forms.ToolStripMenuItem F09;
        private System.Windows.Forms.ToolStripMenuItem F10;
        private System.Windows.Forms.ToolStripMenuItem F11;
        private System.Windows.Forms.ToolStripMenuItem F12;
        private System.Windows.Forms.ToolStripMenuItem F00Open;
        private System.Windows.Forms.ToolStripMenuItem F00Save;
        private System.Windows.Forms.ToolStripMenuItem F00OWrite;
        private System.Windows.Forms.ToolStripSeparator sep;
        private System.Windows.Forms.ToolStripMenuItem F00AdCom;
        private System.Windows.Forms.ToolStripMenuItem F00UnCom;
        private System.Windows.Forms.ToolStripSeparator sep2;
    }
}
