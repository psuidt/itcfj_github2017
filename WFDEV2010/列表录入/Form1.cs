using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 列表录入
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            dt.Columns.Add("a");
            dt.Columns.Add("b");
            dt.Columns.Add("c");
            dt.Columns.Add("d");
            dt.Rows.Add(new object[] { "a441", "dd", "rr", "555555" });
            dt.Rows.Add(new object[] { "a441", "dd", "r444r", "5555tt55" });
            dt.Rows.Add(new object[] { "afdafd1", "dd", "rr", "555tt555" });
            dt.Rows.Add(new object[] { "afadsfdas1", "dd666", "rr", "5566r5555" });
            gridControl1.DataSource = dt;
        }

        private void gridControl1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
         SendKeys.Send("{F4}");
        }
    }
}
