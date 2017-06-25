using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWebApiHost
{
    public class AssemblySection: ConfigurationSection
    {
        [ConfigurationProperty("add", IsDefaultCollection = false)]
        public AssemblyElement Child
        {
            get { return (AssemblyElement)base["add"]; }
            set { base["add"] = value; }
        }
    }
}
