using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WFDEV2010
{


    public partial class 事件 : UserControl
    {
        public  event EventHandler MyEventHander;
        public event EventHandler<myEventArgs> MyEventHanderWithArgs;
        public 事件()
        {
            InitializeComponent();
           
        }


        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (MyEventHander!=null)
            {
                MyEventHander(this, e);
            }
             
        }

        private void 事件_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (MyEventHanderWithArgs!=null)
            {
                MyEventHanderWithArgs(this, new myEventArgs("abc", "123"));
                
            }
        }
    }
    public class myEventArgs : EventArgs
    {
        public string Name { get; set; }
        public string PassWord { get; set; }
        public myEventArgs()
        {

        }
        public myEventArgs(string name,string passWord)
        {
            this.Name = name;
            this.PassWord = passWord;
        }
    }
}
