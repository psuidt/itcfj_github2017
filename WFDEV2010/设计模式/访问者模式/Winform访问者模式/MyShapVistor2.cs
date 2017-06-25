using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform访问者模式
{
  public  class MyShapVistor2:ShapVistor
    {
        public  void Vistr(Rectangle re)
        {
            re.Var1 = "22";
            
            re.临时增加的方法2();
        }

        public  void Vistr(Circle re)
        {
            throw new NotImplementedException();
        }
    }
}
