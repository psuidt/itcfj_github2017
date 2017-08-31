using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ConsoleAppWebApiHost
{

    /*
    [RoutePrefix("api2/MyTest")]
    
    public class TestController: ApiController
    {
    
  
        public string PutUserName()
        {
            return "WebApiTest";
        }

        [Route("myget")]
        public IEnumerable<string> Get()//应用路由特性（MapHttpAttributeRoutes）后的访问Get方法的地址为：http://127.0.0.1:8011/api2/MyTest/myget

        {
            return new string[] { "value1", "value2" };
        }
        public void Post([FromBody]Demo value)
        {
            Thread.Sleep(10000);
           // Logger.Core.LoggerFactory.Instance.Logger_Info(value.ToString());
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }

    public class Demo
    {

        public string appName { get; set; }
        public string url { get; set; }
        public override string ToString()
        {
            return string.Format("appName:{0},url:{1},datetime:{2}", this.appName, this.url, DateTime.Now);
        }
    }
    */
}
