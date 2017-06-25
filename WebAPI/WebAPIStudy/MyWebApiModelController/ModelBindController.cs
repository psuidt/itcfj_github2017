using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyWebApiModelController
{
    [RoutePrefix("api2/modelBind")]
  public  class ModelBindController:ApiController
    {

        [AcceptVerbs("Get","Post")]
       // [HttpGet]
        [Route("setModelData/{UserName}/{PassWord}")]
        public DemoModel SetModelData(DemoModel demoModel)
        {
            Console.WriteLine(demoModel.UserName);
            Console.WriteLine(demoModel.PassWord);
            return demoModel;

        }
    }
}
