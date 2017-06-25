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
    public partial class Form事件 : Form
    {
        public Form事件()
        {
            InitializeComponent();
        }
        private void MyHaner(object sender, EventArgs e)
        {
        
        }
        private void Form事件_Load(object sender, EventArgs e)
        {
            事件1.MyEventHander += new EventHandler(事件1_MyEventHander);
            事件1.MyEventHanderWithArgs += new EventHandler<myEventArgs>(事件1_MyEventHanderWithArgs);

        }

        void 事件1_MyEventHanderWithArgs(object sender, myEventArgs e)
        {
            MessageBox.Show(e.PassWord+"___"+e.Name);
           //throw new NotImplementedException();
        }

        void 事件1_MyEventHander(object sender, EventArgs e)
        {
            MessageBox.Show("22");
        }
    }
}
