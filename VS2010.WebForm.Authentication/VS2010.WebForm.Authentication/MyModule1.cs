using System;
using System.Web;

namespace VS2010.WebForm.Authentication
{
    public class MyModule1 : IHttpModule
    {
        /// <summary>
        /// 您将需要在您网站的 web.config 文件中配置此模块，
        /// 并向 IIS 注册此模块，然后才能使用。有关详细信息，
        /// 请参见下面的链接: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //此处放置清除代码。
        }

        public void Init(HttpApplication context)
        {
            // 下面是如何处理 LogRequest 事件并为其
            // 提供自定义日志记录实现的示例
            //context.LogRequest += new EventHandler(OnLogRequest);
            context.AuthenticateRequest += new EventHandler(context_AuthenticateRequest);
        }

        void context_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            VCubePrincipal<UserInfo>.TrySetUserInfo(app.Context);		
        }

        #endregion

   
    }
}
