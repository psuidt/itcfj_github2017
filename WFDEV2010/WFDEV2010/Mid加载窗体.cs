using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WFDEV2010
{
    public partial class Mid加载窗体 : Form
    {


        public Mid加载窗体()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            xtraTabbedMdiManager1.MdiParent = this;
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form2 frm = new Form2();
            frm.Text = "单病种";
            frm.MdiParent = this;
            frm.Show();
            反射插件开发 frm1 = new 反射插件开发();
            frm1.Text = "病历编辑器";
            frm1.MdiParent = this;
            frm1.Show();

        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void barEditItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }


    }
}
