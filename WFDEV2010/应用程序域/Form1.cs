using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 应用程序域
{
    public partial class Form1 : Form
    {
        System.AppDomain newDomain = System.AppDomain.CreateDomain("NewApplicationDomain",null, new AppDomainSetup { LoaderOptimization = LoaderOptimization.SingleDomain});
        public Form1()
        {
            InitializeComponent();
            XtraForm1 xtr = new XtraForm1();
            xtr.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            xtr.TopLevel = false;
            xtr.Parent = panelControl1;
            xtr.Dock = System.Windows.Forms.DockStyle.Fill;
            xtr.Show();


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
         
            // Load and execute an assembly:
          newDomain.ExecuteAssembly(@"E:\MyWork\C#AndWinform开发\DevProject\DevWinform\多线程\bin\Debug\多线程.exe");
           // newDomain1.ExecuteAssembly(@"E:\MyWork\C#AndWinform开发\DevProject\WFDEV2010\WFDEV2010\bin\Debug\WFDEV2010.exe");

            // Unload the application domain:
     
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            System.AppDomain.Unload(newDomain);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            /*
            System.Reflection.Assembly newAssembly = System.Reflection.Assembly.LoadFrom(@"E:\MyWork\C#AndWinform开发\DevProject\WFDEV2010\HelloWorldRemote\bin\Debug\HelloWorldRemote.exe");

            // Instantiate RemoteObject:
             newAssembly.CreateInstance("HelloWorldRemote.RemoteObject");
             **/

            AppDomain newdomain = AppDomain.CreateDomain("newadddomain");

            object refobject = newdomain.CreateInstanceAndUnwrap("MyClassLibrary", "MyClassLibrary.Class2");
            (refobject as Class2).PrintAppDomain();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            AppDomainSetup info = new AppDomainSetup();
            info.LoaderOptimization = LoaderOptimization.SingleDomain;

            AppDomain domain = AppDomain.CreateDomain("MyDomain", null, info);
            domain.ExecuteAssembly(@"E:\MyWork\C#AndWinform开发\DevProject\WFDEV2010\HelloWorldRemote\bin\Debug\HelloWorldRemote.exe");
            AppDomain.Unload(domain);

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            XtraForm1 xt = new XtraForm1();
            xt.ShowDialog();
        }
    }

    public class Class2 : MarshalByRefObject
    {
        int number = 0;
        public void PrintAppDomain()
        {
            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
            number += 1;
            Console.WriteLine(number);
        }
    }
}
