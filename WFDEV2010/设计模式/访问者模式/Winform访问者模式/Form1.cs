using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform访问者模式
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShapVistor tmp=new MyShapVistor();
            ShapVistor tmp2 = new MyShapVistor2();
            Shap rect = new Rectangle();
            rect.AcceptVistor(tmp);
            rect.AcceptVistor(tmp2);
         //   rect.Draw();
        }
    }
}
