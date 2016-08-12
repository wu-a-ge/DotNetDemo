using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace VS2010.WebForm.Test
{
    /// <summary>
    /// WebServiceWithSoapHeader 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceWithSoapHeader : System.Web.Services.WebService
    {
        public MySoapHeader myHeader = new MySoapHeader();

        [System.Web.Services.Protocols.SoapHeader("myHeader")]
        [WebMethod]
        public string HelloWorld()
        {
            //可以通过存储在数据库中的用户与密码来验证
            if (myHeader.UserName.Equals("houlei") & myHeader.PassWord.Equals("houlei"))
            {
                return "调用服务成功！";
            }
            else
            {
                return "对不起，您没有权限调用此服务！";
            }
        }
    }
}
