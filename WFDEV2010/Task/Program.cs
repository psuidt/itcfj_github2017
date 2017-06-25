using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyTask
{
    class Program
    {
      static   int i;
        static void MyTask()
        {    
            Console.WriteLine(String.Format("MyTask() #{0}Starting", Task.CurrentId));
            for ( i = 0; i <     10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("In MyTask() @"+Task.CurrentId+",Count  Is "+i);
            }
            Console.WriteLine("MyTask #" + Task.CurrentId + " Terminating");

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread   Starting .");
            Task tsk = new Task(MyTask);
            Task tsk2 = new Task(MyTask);
            tsk.Start();
            tsk2.Start();
            Console.WriteLine("Task ID for  Tsk is "+tsk.Id);
            Console.WriteLine("Task ID for  Tsk2 is " + tsk2.Id);

        tsk.Wait();
        tsk2.Wait();
            Console.WriteLine("Main Thread Ending.");
            Console.Read();

        }
    }
}
