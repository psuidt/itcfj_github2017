using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppWebApiHost
{
    public class AssemblyELementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new AssemblyElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            AssemblyElement assemblyElement = (AssemblyElement)element;
            return assemblyElement.AssemblyName;
        }
    }
}
