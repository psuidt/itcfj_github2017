using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Winning.Cpoe.UI.PreviewFile
{
    public partial class FrmPreviewFile : Form
    {
        public string filepath { get; set; }
        public FrmPreviewFile()
        {
            InitializeComponent();
            this.Load += FrmPreviewFile_Load;
            this.listBoxFile.DoubleClick += listBoxFile_DoubleClick;
            this.listBoxFile.DrawItem += listBoxFile_DrawItem;
      //      this.Icon = GetFileIcon(@"D:\FrameWork\5.0\Debug\PreviewFile\新建文本文档 (2).chm");
        }

        void listBoxFile_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.Graphics.DrawString(listBoxFile.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
        }

        void listBoxFile_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxFile.SelectedIndex != -1)
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = filepath + "\\" + listBoxFile.Items[listBoxFile.SelectedIndex].ToString();
                p.Start();
            }

        }

        void FrmPreviewFile_Load(object sender, EventArgs e)
        {
            BindListBoxFile();
        }
        private void BindListBoxFile()
        {
            filepath = Environment.CurrentDirectory + "\\PreviewFile";
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(30, 30);// 设置行高 20 //分别是宽和高
            DirectoryInfo TheFolder = new DirectoryInfo(filepath);
            FileInfo[] imgs = TheFolder.GetFiles();
            for (int i = 0; i < imgs.Length; i++)
            {
                Icon ico = System.Drawing.Icon.ExtractAssociatedIcon(imgs[i].FullName);
                imgList.Images.Add(i.ToString(), ico.ToBitmap());
            }
            this.listView1.View = View.List;
            this.listView1.SmallImageList = imgList;
            for (int i = 0; i < imgs.Length; i++)
            {
                FileInfo fileInfo = imgs[i];
                ListViewItem lvi = new ListViewItem();
                lvi.Text = fileInfo.Name;
                lvi.ImageKey = i.ToString();
                this.listView1.Items.Add(lvi);
            }

        }


        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listView1.HitTest(e.X, e.Y);
            if (info.Item != null)
            {
                MessageBox.Show(info.Item.Text);
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = filepath + "\\" + info.Item.Text;
                p.Start();
            }
        }


    }


}
