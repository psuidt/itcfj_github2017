using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Program
    {
        static void ParamsTest(int j, int m = 0)
        {

        }
        static void Main(string[] args)
        {
            int? i = null;
            int m = 0;
            if (i.HasValue)
            {

            }
            int j = i ?? 2;
            //int n = m ?? 33;
            ParamsTest(j: 33);
        }
    }
}
