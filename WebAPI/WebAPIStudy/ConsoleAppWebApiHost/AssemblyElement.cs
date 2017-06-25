using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWebApiHost
{
   public class AssemblyElement: ConfigurationElement
    {
        [ConfigurationProperty("assemblyName",IsRequired =true)]
        public string AssemblyName
        {
            get { return (String)this["assemblyName"]; }
            set { this["assemblyName"] = value; }


        }
    }
}
