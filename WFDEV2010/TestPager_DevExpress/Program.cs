using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WHC.Pager.WinControl;
using System.Configuration;

namespace WHC.OrderWater.UI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            InitDataConfig();

            DevExpress.UserSkins.OfficeSkins.Register();
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmCustomer());
        }

        private static void InitDataConfig()
        {
            string connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}Database1.mdb;User ID=Admin;Jet OLEDB:Database Password=;",
                System.AppDomain.CurrentDomain.BaseDirectory);
            AppConfig config = new AppConfig();
            config.SetConnectionString("DataAccess", connectionString);

            //更新配置文件，以便起效
            ConfigurationManager.RefreshSection("dataConfiguration");
            ConfigurationManager.RefreshSection("connectionStrings");
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
