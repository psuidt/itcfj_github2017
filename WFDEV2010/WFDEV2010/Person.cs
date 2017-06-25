using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WFDEV2010
{
    public class Person
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }

    }
}
