using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 禁用容器内的所有控件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            panelControl1.Controls.Owner.Enabled = false;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            panelControl1.Controls.Owner.Enabled = true;
        }
    }
}
