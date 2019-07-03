using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace newtype.Controls
{
    [Serializable]
    public partial class TabGridControl : UserControl
    {
        public int CurrentTabIndex
        {
            get
            {
                return currentTabIndex;
            }
            set
            {
                currentTabIndex = value;
                TabActivate(currentTabIndex);
            }
        }

        public int currentTabIndex = 0;

        public List<SeekGridView> GridCollection = new List<SeekGridView>();

        public List<SeekStripMenuItem> TabCollection { get { return tabCollection; } }

        private List<SeekStripMenuItem> tabCollection
        {
            get { return tabBar.Items.Cast<SeekStripMenuItem>().Where(t => t.Index != 99).ToList(); }
            set { tabBar.Items.AddRange(value.ToArray()); }
        }

        public List<QueryControl> QueryCollection = new List<QueryControl>();

        public Dictionary<int, DataViewer> ViewerCollection = new Dictionary<int, DataViewer>();

        public QueryControl CurrentQuery { get { return QueryCollection[CurrentTabIndex]; } }

        public ToolStripMenuItem CurrentTabItem { get { return tabCollection[CurrentTabIndex]; } }

        public SeekGridView CurrentGridView { get { return GridCollection[CurrentTabIndex]; } }

        public Color GridBackGroundColor
        {
            get { return GridCollection[0].BackgroundColor; }
            set { GridCollection.ForEach((g) => g.BackgroundColor = value); }
        }

        public DataGridViewCellStyle GridDefaultCellStyle
        {
            get { return GridCollection[0].DefaultCellStyle; }
            set { GridCollection.ForEach((g) => g.DefaultCellStyle = value); }
        }

        public DataGridViewCellStyle GridColumnHeaderCellStyle
        {
            get { return GridCollection[0].ColumnHeadersDefaultCellStyle; }
            set { GridCollection.ForEach((g) => g.ColumnHeadersDefaultCellStyle = value); }
        }
        
        public TabGridControl()
        {
            InitializeComponent();

            GridCollection = Enumerable.Range(0, 9).Select(i => new SeekGridView()).ToList();
            tabCollection = Enumerable.Range(0, 9).Select(i => new SeekStripMenuItem(i)).ToList();
            QueryCollection = Enumerable.Range(0, 9).Select(i => new QueryControl()).ToList();
            AddSettingItem();
        }


        private void TabGridControl_Load(object sender, EventArgs e)
        {
            GridCollection.ForEach(g => 
            {
                g.Parent = mainPanel;
                g.BackgroundColor = GridBackGroundColor;
                g.DataError += G_DataError;
            });

            tabCollection.ForEach(t => 
            {
                    t.Click += toolStripMenuItems_Click;
                    t.MouseDown += toolStripMenuItems_MouseDown;
            });

            QueryCollection.ForEach(q =>
            {
                q.Parent = splitContainer.Panel2;
                q.AllowDrop = true;
                q.DragDrop += Q_DragDrop;
                q.DragEnter += Q_DragEnter;
            });

            toolStripMenuItems_Click(tabCollection[0], e);
        }


        private void Q_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop)
                             ? e.Effect = DragDropEffects.Copy
                             : e.Effect = DragDropEffects.None;
        }


        private void G_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            /* ignore */
        }


        public void AwakeViewer()
        {
            if (ViewerCollection.Keys.Contains(CurrentTabIndex))
            {
                ViewerCollection[CurrentTabIndex].Close();
            }
            else
            {
                ViewerCollection.Add(CurrentTabIndex, new DataViewer(CurrentGridView, this));

                ViewerCollection[CurrentTabIndex].Opacity = ((Form)Parent).Opacity;
                ViewerCollection[CurrentTabIndex].Location = ((Form)Parent).Location;
                ViewerCollection[CurrentTabIndex].BackColor = ((Form)Parent).BackColor;
                ViewerCollection[CurrentTabIndex].Font = ((Form)Parent).Font;

                ViewerCollection[CurrentTabIndex].Show();
            }
        }


        private void toolStripMenuItems_MouseDown(object sender, MouseEventArgs e)
        {
            ((ToolStripMenuItem)sender).PerformClick();

            if (e.Button != MouseButtons.Right) return;
            AwakeViewer();
        }


        private void toolStripMenuItems_Click(object sender, EventArgs e)
        {
            // selection Item
            CurrentTabIndex = ((SeekStripMenuItem)sender).Index;
            QueryCollection[CurrentTabIndex].Focus();
        }


        public void TabActivate(int index)
        {
            // All unvisible
            tabCollection.ForEach(t => t.BackColor = Color.Black);
            QueryCollection.ForEach(q => q.Visible = false);
            GridCollection.Where(g => g.Parent == mainPanel).ToList()
                                                            .ForEach(g => g.Visible = false);
            GridCollection[index].Visible = true;
            QueryCollection[index].Visible = true;
            tabCollection[index].BackColor = SystemColors.MenuHighlight;
        }


        // control Readd
        public void ReturnSeekGridView(SeekGridView seekGridView, int index)
        {
            mainPanel.Controls.Add(seekGridView);
            seekGridView.Parent = mainPanel;

            ViewerCollection.Remove(index);
        }


        private void Q_DragDrop(object sender, DragEventArgs e)
        {
            var savePass = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if (File.Exists(savePass[0]) == true)
            {
                var sr = new StreamReader(savePass[0], Encoding.GetEncoding("Shift_JIS"));

                CurrentQuery.Text = sr.ReadToEnd();
                sr.Close();
            }
        }


        public event EventHandler settingClick;

        public event EventHandler disconnectClick;

        private void serverSetting_Click(object sender, EventArgs e)
        {
            settingClick?.Invoke(sender, e);
        }

        private void disConnect_Click(object sender, EventArgs e)
        {
            disconnectClick?.Invoke(sender, e);
        }

        private SeekStripMenuItem disConnect = new SeekStripMenuItem();
        private SeekStripMenuItem serverSetting = new SeekStripMenuItem();
        private void AddSettingItem()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(TabGridControl));
            // 
            // serverSetting
            // 
            serverSetting.Alignment = ToolStripItemAlignment.Right;
            serverSetting.ForeColor = Color.White;
            serverSetting.Image = ((Image)(resources.GetObject("serverSetting.Image")));
            serverSetting.Name = "serverSetting";
            serverSetting.Click += new EventHandler(serverSetting_Click);
            serverSetting.ShortcutKeys = (Keys.Control | Keys.Insert);
            serverSetting.ToolTipText = "Connection Setting";
            // 
            // disConnect
            // 
            disConnect.Alignment = ToolStripItemAlignment.Right;
            disConnect.ForeColor = Color.White;
            disConnect.Image = ((Image)(resources.GetObject("disConnect.Image")));
            disConnect.Name = "disConnect";
            disConnect.Click += new EventHandler(disConnect_Click);
            disConnect.ShortcutKeys = (Keys.Control | Keys.Delete);
            disConnect.ToolTipText = "DisConnect Server";

            tabBar.Items.AddRange(new ToolStripItem[] {
            disConnect,
            serverSetting});
        }
    }
}
