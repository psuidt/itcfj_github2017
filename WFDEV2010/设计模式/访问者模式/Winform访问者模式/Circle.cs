using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform访问者模式
{
    public class Circle : Shap
    {
        public void Draw()
        {
           
        }
        public void AcceptVistor(ShapVistor vis)
        {
            vis.Vistr(this);
        }
    }
}
