using HostSdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddInTypes
{
   public class Addin_B : IaddIn
    {
        public string DoSomeThing(int x)
        {
            return "Addin_B" + x.ToString();
        }
    }
}
