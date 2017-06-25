using ClassLibraryRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryRefC
{
    public class Start : Istart
    {
        public DrgEdit Run(System.Windows.Forms.Control SelfPanel)
        {
            Form1 sl = new Form1();
            sl.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            sl.TopLevel = false;
            sl.Parent = SelfPanel;
            sl.Dock = System.Windows.Forms.DockStyle.Fill;
            sl.Show();
            return sl;
        }
    }
}
