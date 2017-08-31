using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ClassLibrary异常处理
{
    public class Class1
    {

        public static void GetJs()
        {
            try
            {
                int i = 0;
                if (10 / i == 0)
                {

                }
            }
            catch (Exception ex)
            { 
                 System.Windows.Forms.MessageBox.Show(ex.StackTrace.ToString()+"\n"+ex.TargetSite.Name);
            }




        }
    }
}
