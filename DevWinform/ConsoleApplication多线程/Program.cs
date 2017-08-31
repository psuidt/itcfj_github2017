using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication多线程
{
    class Person : ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public object Clone()
        {
       return    this.MemberwiseClone();
        }
    }



    class Pet
    {
        public string Name { get; set; }
        public Person Owner { get; set; }
    }
    class Program
    {
        public  static void LeftOuterJoinExample()
        {
            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };



            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet bluemoon = new Pet { Name = "Blue Moon", Owner = terry };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };



            // Create two lists.
            List<Person> people = new List<Person> { magnus, terry, charlotte, arlene };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };

            var f = people.Where(P => P.FirstName == "Magnus").Select(P => P.LastName).FirstOrDefault();

            //var query = from person in people
            //            join pet in pets on person equals pet.Owner into gj
            //            from subpet in gj.DefaultIfEmpty()
            //            select new
            //            {

            //                person.FirstName,

            //                PetName = (subpet == null ? String.Empty : subpet.Name)

            //            };
            ////此时subpet为引用类型，所以此时这里是需要进行null检查的。

            //foreach (var v in query)
            //{
            //    Console.WriteLine("{0,-15}{1}", v.FirstName + ":", v.PetName);
            //}
        }




        
        private static Mutex mut = new Mutex();
        private const int numIterations = 1;
        private const int numThreads = 3;

        static void Main(string[] args)
        {
            //for (int i = 0; i < numThreads; i++)
            //{
            //    Thread myThread = new Thread(new ThreadStart(MyThreadProc));
            //    myThread.Name = String.Format("Thread{0}", i + 1);
            //    myThread.Start();
            //}
          //  LeftOuterJoinExample();
            DataTable dt2 = new DataTable();
            DataTable dt = new DataTable();
            dt.Columns.Add("a");
            dt.Columns.Add("b");
            dt.Rows.Add(new object[] { "a", "b" });
            dt.Rows.Add(new object[] { "arr", "brr" });
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("a");
            dt1.Columns.Add("b");
            dt1.Rows.Add(new object[] { "a11111", "2222222b" });
            dt1.Rows.Add(new object[] { "44444arr", "brrrrrr" });
            dt2.Merge(dt);
            dt2.Merge(dt1);
            DataTable dt22 = dt2;

            LeftOuterJoinExample();
            Console.Read();
        }
        private static void MyThreadProc()
        {
            for (int i = 0; i < numIterations; i++)
            {
                UseResource();
            }
        }

        // This method represents a resource that must be synchronized
        // so that only one thread at a time can enter.
        private static void UseResource()
        {
            // Wait until it is safe to enter.
           // mut.WaitOne();
            Console.WriteLine("{0} has entered the protected area",
                Thread.CurrentThread.Name);

            // Place code to access non-reentrant resources here.

            // Simulate some work.
            Thread.Sleep(500);

            Console.WriteLine("{0} is leaving the protected area\r\n",
                Thread.CurrentThread.Name);

            // Release the Mutex.
       //     mut.ReleaseMutex();
        }

    }
}
