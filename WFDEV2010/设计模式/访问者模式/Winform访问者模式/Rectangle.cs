using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform访问者模式
{
    public class Rectangle : Shap
    {
        public string  Var1 { get; set; }
        public void Draw()
        {
        }
        public void AcceptVistor(ShapVistor vis)
        {
            vis.Vistr(this);
        }
        public void 临时增加的方法()
        {
          MessageBox.Show("临时增加的方法");
        }

        internal void 临时增加的方法2()
        {
            MessageBox.Show("临时增加的方法2");
        }
    }
}
