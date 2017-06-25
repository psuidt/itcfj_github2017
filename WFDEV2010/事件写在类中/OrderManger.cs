using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 事件写在类中
{
   public  class OrderManger
    {
        public event EventHandler Refdata;
       
        public void NewData()
        {
            if (Refdata!=null)
            {
                Refdata(this, new EventArgs());
            }
           
        }
      

    }
}
