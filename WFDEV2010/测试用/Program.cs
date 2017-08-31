using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 测试用
{
    class Program
    {
        static void Main(string[] args)
        {
            A(1);
            Console.Read();
        }
        //static void A(int i = 0)
        //{
        //    Console.WriteLine("ddd");
        //    A(33);

        //}

        static void A(int i, string m = "")
        {
            Console.WriteLine("1111");
        }
    }
}
