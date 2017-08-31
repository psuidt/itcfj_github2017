using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform访问者模式
{
    public interface  ShapVistor
    {
     void Vistr(Rectangle re);
      void Vistr(Circle re) ;
 }
}
