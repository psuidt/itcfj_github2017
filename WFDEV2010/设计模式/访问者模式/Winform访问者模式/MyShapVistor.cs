using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform访问者模式
{
   public class MyShapVistor:ShapVistor
    {
        public  void Vistr(Rectangle re)
        {
            re.临时增加的方法();
          //  throw new NotImplementedException();
        }

        public  void Vistr(Circle re)
        {
            //throw new NotImplementedException();
        }
    }
}
