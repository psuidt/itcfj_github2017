using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace MyWebApiModelController
{
    [ModelBinder]
    [DataContract]
    public class DemoModel
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string PassWord { get; set; }
    }
}
