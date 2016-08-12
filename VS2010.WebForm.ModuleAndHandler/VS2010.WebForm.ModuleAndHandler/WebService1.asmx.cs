using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
namespace VS2010.WebForm.ModuleAndHandler
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet=true)]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public string Post()
        {
            return "Post";
        }
        [WebMethod]
        public string JSON()
        {
            return "{'a':'bb'}";
        }
    }
}
