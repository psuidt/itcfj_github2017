using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WFDEV2010
{
    public partial class Component1 : Component
    {
        public Component1()
        {
            InitializeComponent();
            System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\a.txt");
            while (true)
            {
                sw.WriteLine("aaaaaaaaaaaadd");
            }


        }

        public Component1(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
