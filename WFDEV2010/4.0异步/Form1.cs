using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4._0异步
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Action<object> act = (object obj) =>
        {

            MessageBox.Show(string.Format("Task={0}, obj={1}, Thread={2}",
                Task.CurrentId, obj.ToString(),
                Thread.CurrentThread.ManagedThreadId));
        };
        public  int GetInt()
        {
             int i=0;
              while (true)
             { i++; }
            return i;
        }

        async Task<int> TaskOfT_MethodAsync()
{
    await Task.Delay(2000);
    // The body of the method is expected to contain an awaited asynchronous
    // call.
    // Task.FromResult is a placeholder for actual work that returns a string.
    var today = await Task.FromResult<string>(DateTime.Now.DayOfWeek.ToString());

    // The method then can process the result in some way.
    int leisureHours;
    if (today.First() == 'S')
        leisureHours = 16;
    else
        leisureHours = 5;

    // Because the return statement specifies an operand of type int, the
    // method must have a return type of Task<int>.
    return leisureHours;
}
        private async void button1_Click(object sender, EventArgs e)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak("Hello, 伍哥! 欢迎 www.vkesoft.com！");
            int result1 = await TaskOfT_MethodAsync();
            MessageBox.Show(result1.ToString());
            string aa = "ddfadfasf";
            Task t2 = Task.Factory.StartNew(act, aa);
         //   act("dd", "ddddd");

           //  await Task.FromResult<string>(DateTime.Now.DayOfWeek.ToString());
            /*
            Task t1 = new Task(act,"aa","dd");
       Task t2=     Task.Factory.StartNew(act, "bb");
       Task t3 = t2.ContinueWith(task => { MessageBox.Show("dd"); });

       while (true)
       { }
       MessageBox.Show("dd");

            // Launch t1 
          // t1.Start();
         //   t1.Wait();
           */
           
        }
    }
}
