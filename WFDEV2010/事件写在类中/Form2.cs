using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 事件写在类中
{
    public partial class Form2 : Form
    {
        OrderManger or;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(OrderManger or)
        {
            InitializeComponent();
            this.or = or;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
          
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            or.NewData();
        }
    }
}
