using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyWebApiContollers
{
    [RoutePrefix("api2/MyTest")]

    public class TestController : ApiController
    {
        public string PutUserName()
        {
            return "WebApiTest";
        }

        //可选参数及其默认值，可缺省参数不能定义在非缺省参数之前
        [Route("myget/{id:maxlength(10)?}")]
        [Route("~/api3/GetTest")]
        [ActionName("getTest")]
        public IEnumerable<string> Get(string id="")//应用路由特性（MapHttpAttributeRoutes）后的访问Get方法的地址为：http://127.0.0.1:8011/api2/MyTest/myget

        {
            return new string[] { "value1", "value2" };
        }


        /*  WebApi通配符
         * 
         */
        [ActionName("delUser")]
        [Route("del/user/{createDateTime:datetime}")]//路由变量约束
        [Route("del/user/{*createDateTime:datetime}")]//路由变量约束,通配符
        public void DeleteUserInfo(DateTime createDateTime)
        {


        }
        [HttpPost]
        [Route("myPost",Name ="myUpdate")]
        public void Post([FromBody]Demo value)
        {
            Thread.Sleep(10000);
            // Logger.Core.LoggerFactory.Instance.Logger_Info(value.ToString());
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [Route("~/api3/del/{id:int}")] //当我们将 RouteAttributc特 性 应用 到某个 Action方 法 上 时,如 果我们 不 希望采 用 该应用
                                       //在所在 HttpController 的 RoutePrefix特 性 设 定 的前缀, 可 以为 定义 的路 由模 板添
                                       //加前 缀 “~气
        [Route("~/api3/del/{id?}")]
        [Route("{id?}")]//可缺省路 由变量名需要添加 “?”
        public void Delete(int id=1)
        {
        }


         [Route("{id=1}")]//缺省路由变量值定义在模板中,
        public void DeleteByDefaultID(int id)
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
}
