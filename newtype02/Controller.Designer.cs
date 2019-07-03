using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newtype
{
    partial class Controller
    {
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Controller));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuBar = new newtype.Controls.MenuBar();
            this.formBar = new newtype.Controls.FormBar();
            this.tabGrid = new newtype.Controls.TabGridControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.keyboardHook = new newtype.KeyboardHook();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            this.menuBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuBar.F01_Image = ((System.Drawing.Image)(resources.GetObject("menuBar.F01_Image")));
            this.menuBar.F02_Image = ((System.Drawing.Image)(resources.GetObject("menuBar.F02_Image")));
            this.menuBar.F03_Image = ((System.Drawing.Image)(resources.GetObject("menuBar.F03_Image")));
            this.menuBar.F04_Image = ((System.Drawing.Image)(resources.GetObject("menuBar.F04_Image")));
            this.menuBar.F05_Image = ((System.Drawing.Image)(resources.GetObject("menuBar.F05_Image")));
            this.menuBar.F06_Image = ((System.Drawing.Image)(resources.GetObject("menuBar.F06_Image")));
            this.menuBar.F07_Image = ((System.Drawing.Image)(resources.GetObject("menuBar.F07_Image")));
            this.menuBar.F08_Image = ((System.Drawing.Image)(resources.GetObject("menuBar.F08_Image")));
            this.menuBar.F09_Image = ((System.Drawing.Image)(resources.GetObject("menuBar.F09_Image")));
            this.menuBar.F10_Image = ((System.Drawing.Image)(resources.GetObject("menuBar.F10_Image")));
            this.menuBar.F11_Image = ((System.Drawing.Image)(resources.GetObject("menuBar.F11_Image")));
            this.menuBar.F12_Image = ((System.Drawing.Image)(resources.GetObject("menuBar.F12_Image")));
            this.menuBar.Location = new System.Drawing.Point(5, 33);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(614, 32);
            this.menuBar.TabIndex = 3;
            this.menuBar.F01_KeyDown += new System.EventHandler(this.menuBar_F01_KeyDown);
            this.menuBar.F02_KeyDown += new System.EventHandler(this.menuBar_F02_KeyDown);
            this.menuBar.F03_KeyDown += new System.EventHandler(this.menuBar_F03_KeyDown);
            this.menuBar.F04_KeyDown += new System.EventHandler(this.menuBar_F04_KeyDown);
            this.menuBar.F05_KeyDown += new System.EventHandler(this.menuBar_F05_KeyDown);
            this.menuBar.F06_KeyDown += new System.EventHandler(this.menuBar_F06_KeyDown);
            this.menuBar.F07_KeyDown += new System.EventHandler(this.menuBar_F07_KeyDown);
            this.menuBar.F08_KeyDown += new System.EventHandler(this.menuBar_F08_KeyDown);
            this.menuBar.F09_KeyDown += new System.EventHandler(this.menuBar_F09_KeyDown);
            this.menuBar.F10_KeyDown += new System.EventHandler(this.menuBar_F10_KeyDown);
            this.menuBar.F11_KeyDown += new System.EventHandler(this.menuBar_F11_KeyDown);
            this.menuBar.F12_KeyDown += new System.EventHandler(this.menuBar_F12_KeyDown);
            this.menuBar.F00_OpenKeyDown += new System.EventHandler(this.menuBar_F00_OpenKeyDown);
            this.menuBar.F00_SaveKeyDown += new System.EventHandler(this.menuBar_F00_SaveKeyDown);
            this.menuBar.F00_WriteKeyDown += new System.EventHandler(this.menuBar_F00_WriteKeyDown);
            this.menuBar.F00_AddComKeyDown += new System.EventHandler(this.MenuBar_F00_AddComKeyDown);
            this.menuBar.F00_DelComKeyDown += new System.EventHandler(this.MenuBar_F00_DelComKeyDown);
            // 
            // formBar
            // 
            this.formBar.BackColor = System.Drawing.Color.Transparent;
            this.formBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.formBar.isController = false;
            this.formBar.Location = new System.Drawing.Point(5, 5);
            this.formBar.Name = "formBar";
            this.formBar.Size = new System.Drawing.Size(614, 28);
            this.formBar.TabIndex = 1;
            this.formBar.DBComboIndexChanged += new System.EventHandler(this.formBar_DBComboIndexChanged);
            // 
            // tabGrid
            // 
            this.tabGrid.BackColor = System.Drawing.Color.Black;
            this.tabGrid.CurrentTabIndex = 0;
            this.tabGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGrid.Font = new System.Drawing.Font("游ゴシック Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tabGrid.GridBackGroundColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("游ゴシック Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tabGrid.GridColumnHeaderCellStyle = dataGridViewCellStyle1;
            this.tabGrid.GridDefaultCellStyle = dataGridViewCellStyle1;
            this.tabGrid.Location = new System.Drawing.Point(5, 65);
            this.tabGrid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabGrid.Name = "tabGrid";
            this.tabGrid.Size = new System.Drawing.Size(614, 272);
            this.tabGrid.TabIndex = 2;
            this.tabGrid.settingClick += new System.EventHandler(this.tabGrid_settingClick);
            this.tabGrid.disconnectClick += new System.EventHandler(this.tabGrid_disconnectClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(5, 337);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(614, 18);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("メイリオ", 9F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 18);
            this.label1.TabIndex = 0;
            // 
            // keyboardHook
            // 
            this.keyboardHook.KeyboardHooked += new newtype.KeyboardHookedEventHandler(this.keyboardHook_KeyboardHooked);
            // 
            // Controller
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Font = new System.Drawing.Font("游ゴシック Medium", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ClientSize = new System.Drawing.Size(624, 360);
            this.Controls.Add(this.tabGrid);
            this.Controls.Add(this.menuBar);
            this.Controls.Add(this.formBar);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(200, 150);
            this.Name = "Controller";
            this.Opacity = 0.6;
            this.Text = "DataReseacher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Controller_FormClosing);
            this.Load += new System.EventHandler(this.Controller_Load);
            this.SizeChanged += new System.EventHandler(this.Controller_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Controller_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        public Controls.FormBar formBar;
        public Controls.MenuBar menuBar;
        public Controls.TabGridControl tabGrid;
        private KeyboardHook keyboardHook;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}
