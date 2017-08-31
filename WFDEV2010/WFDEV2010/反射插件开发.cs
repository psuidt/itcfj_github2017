
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using ClassLibraryRef;

namespace WFDEV2010
{
    public partial class 反射插件开发 : Form
    {
        public 反射插件开发()
        {
            InitializeComponent();
        }

        private void 插件开发_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Assembly AssemblyName = Assembly.LoadFrom(@"E:\MyWork\C#AndWinform开发\DevProject\WFDEV2010\ClassLibrar反射\bin\Debug\ClassLibrar反射.dll");
            Istart edit = (Istart)AssemblyName.CreateInstance("ClassLibraryRefC.Start");
            edit.Run(panel1);
        }
    }
}
