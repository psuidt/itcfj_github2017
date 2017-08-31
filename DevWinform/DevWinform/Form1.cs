using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevWinform
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        static List<int> List;
        public Form1()
        {
            InitializeComponent();
            List = new List<int>();
        }

        private void richEditControl1_Click(object sender, EventArgs e)
        {
        
        }
        private async Task<int> Await1()
        {

            await Task.Run(() => System.Threading.Thread.Sleep(30000));
            return 1;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(List.Count.ToString());
        //    try
        //    {
        //          await Task.Run(() => System.Threading.Thread.Sleep(30000));
        //        //  System.Threading.Thread.Sleep(30000);
        ////        int i = (await Await1());
        //        //MessageBox.Show(i.ToString());
        //    }
        //    catch (Exception)
        //    {
        //        // Process the exception. . . .
        //    }

        }
        public delegate void Uplatelab(string newValue);
         void ThreadProc(Object stateInfo)
        {
            // No state object was passed to QueueUserWorkItem, so
            // stateInfo is null.
            label1.BeginInvoke(new Uplatelab(UplatelabMethod), "Hello from the thread pool.");
           // label1.Text = "Hello from the thread pool.";
         //   Console.WriteLine("Hello from the thread pool.");
        }
         private void UplatelabMethod(string a)
         {
             label1.Text += a;
         }
       
        private void button2_Click(object sender, EventArgs e)
        {
            List.Add(11);
        
            /*
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc));
            label1.BeginInvoke(new Uplatelab(UplatelabMethod), "\nMain thread does some work, then sleeps");
      //      label1.Text += "\nMain thread does some work, then sleeps.";
         //   Console.WriteLine("Main thread does some work, then sleeps.");
            // If you comment out the Sleep, the main thread exits before
            // the thread pool task runs.  The thread pool uses background
            // threads, which do not keep the application running.  (This
            // is a simple example of a race condition.)
            Thread.Sleep(1000);
            label1.BeginInvoke(new Uplatelab(UplatelabMethod), "\nMain thread exits.");
      //      label1.Text += "\nMain thread exits.";
           // Console.WriteLine("Main thread exits.");

            //MessageBox.Show("22");
             * */
        }

    }
}
