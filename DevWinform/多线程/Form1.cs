using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 多线程
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string str = "5岁1月23天";
            int a = str.IndexOf("岁");
            int b = str.IndexOf("月");
            int c = str.IndexOf("天");
           string d = str.Substring(0, a) + str.Substring(a + 1, b-a - 1)+str.Substring(b+1, str.Length-b-2);

            MessageBox.Show(d);

        }
    }
}
