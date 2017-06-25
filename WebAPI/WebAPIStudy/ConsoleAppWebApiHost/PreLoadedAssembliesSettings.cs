using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWebApiHost
{
   public class PreLoadedAssembliesSettings: ConfigurationSection
    {
        [ConfigurationProperty("", IsDefaultCollection = true)]
        public AssemblyELementCollection AssemblyNames {
            get { return (AssemblyELementCollection)this[""]; }
        }

        public static PreLoadedAssembliesSettings GetSection()
        {
            return ConfigurationManager.GetSection("preLoadedAssemblies")
                  as PreLoadedAssembliesSettings;

        }
    }
}
