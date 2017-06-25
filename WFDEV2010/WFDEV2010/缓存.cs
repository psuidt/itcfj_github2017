using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WFDEV2010
{
    public partial class 缓存 : Form
    {
        [StructLayout(LayoutKind.Sequential)]
        internal struct DataObjectRec
        {
            internal string key;
            internal string DataObjData { get; set; }
        }





        public 缓存()
        {
            InitializeComponent();
        }
        List<DataObjectRec> list = new List<DataObjectRec>();
        private void 缓存_Load(object sender, EventArgs e)
        {
          
            System.IO.StreamReader rs = new System.IO.StreamReader("D:\\a.txt");
            string str = rs.ReadToEnd();
            rs.Close();
            list.Add(new DataObjectRec
            {
                key = "11",
                DataObjData = str
            });

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = list.Find(P => P.key == "11").DataObjData;
        }
    }
}
