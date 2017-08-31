using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevWinfrom
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Application.EnableVisualStyles();
            //   Application.SetCompatibleTextRenderingDefault(false);
            BonusSkins.Register();
            OfficeSkins.Register();
            SkinManager.EnableFormSkins();
            //  DevExpress.Skins.SkinManager.Default.RegisterAssembly(typeof(DevExpress.UserSkins.SkinProjectTest).Assembly); //Regi
         //   System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");
         //   Application.EnableVisualStyles();
         //   Application.SetCompatibleTextRenderingDefault(false);
          //  Application.EnableVisualStyles();
        //    Application.Run(new ItemRadioGroup1多列标题());
           Application.Run(new Form1());
        }
    }
}
