using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
namespace VS2010.WebForm.ModuleAndHandler
{
    /// <summary>
    /// 会话测试
    /// </summary>
    public class Handler1 : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Session[context.Session.SessionID] = "我是在会话中httphandler赋值的";
            context.Response.Write(context.Session[context.Session.SessionID]);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}