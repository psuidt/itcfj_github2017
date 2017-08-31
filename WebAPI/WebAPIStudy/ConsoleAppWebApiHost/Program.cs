using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.SelfHost;

namespace ConsoleAppWebApiHost
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * cfj
            var config = new HttpSelfHostConfiguration("http://localhost:3333");
            config.Routes.MapHttpRoute("default", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            var server = new HttpSelfHostServer(config);
            server.OpenAsync().Wait();
            Console.WriteLine("Server is opened");
            */
            // Assembly.Load("ConsoleAppWebApiHost.exe");

            /*
            整个 AsΠ NET Web API的 配置都是通过 HttpConⅡ 田r扯ion来 完成的, 针对 自定义 “服务
            实例 ” 的注 册 也 不 例 外 。
              */

            
       // 
            

           HttpSelfHostConfiguration
                  webApiSelHostConfig = new HttpSelfHostConfiguration
                  ("http://127.0.0.1:8011");
            
            // 启用Web API特性路由，才能使用RoutePrefix等特性
            webApiSelHostConfig.MapHttpAttributeRoutes();
           // webApiSelHostConfig.SendTimeout;
            webApiSelHostConfig.Routes
                .MapHttpRoute("default", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            using (HttpSelfHostServer webApiSelHostServer = new HttpSelfHostServer(webApiSelHostConfig))
            {

                //如何Host定义在独立程序集中的Controller
             webApiSelHostServer.Configuration.Services.Replace(typeof(IAssembliesResolver), new ExtendedDefaultAssembliesResolver());
             webApiSelHostServer.OpenAsync().Wait();
             Console.Write("WebApiHostSerer Is Opened");
             Console.Read();
            }

        }
    }
}
