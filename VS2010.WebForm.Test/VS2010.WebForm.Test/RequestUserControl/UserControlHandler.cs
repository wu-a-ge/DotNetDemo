using System;
using System.Web;
using System.Web.UI;

namespace VS2010.WebForm.Test.RequestUserControl
{
    public class UserControlHandler : IHttpHandler
    {
        #region IHttpHandler Members

        public bool IsReusable
        {
            // 如果无法为其他请求重用托管处理程序，则返回 false。
            // 如果按请求保留某些状态信息，则通常这将为 false。
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string result = string.Empty;
            try
            {
                UserControl control = UserControlManager.LoadControl(context.Request.AppRelativeCurrentExecutionFilePath);
                result = UserControlManager.RenderControl(control);
            }
            catch (Exception ex)
            {
                
            }
            context.Response.Write(result);
        }
        #endregion
        
    }
    
}
