using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibraryRef;

namespace ClassLibraryRefC
{
    public partial class Form1 : Form, DrgEdit
    {
        public Form1()
        {
            InitializeComponent();
        }

        public bool SaveData()
        {
            MessageBox.Show("保存成功！");
            return true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("加载成功！");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
