using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPFStudy
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        [STAThread]
        public static void Main()
        {
            App ap = new App();
            SplashScreen splashScreen = new SplashScreen("9.jpg");
            splashScreen.Show(true);
            ap.InitializeComponent();
            System.Threading.Thread.Sleep(20000);
            ap.Run();

        }
        public void InitializeComponent()
        {
            this.StartupUri = new Uri("Window1.Xaml", UriKind.Relative);
        }
        protected override void OnSessionEnding(SessionEndingCancelEventArgs e)
        {
            //     base.OnSessionEnding(e);
            //e.Cancel = true;
            MessageBox.Show("ddddd");
        }
    }
}
