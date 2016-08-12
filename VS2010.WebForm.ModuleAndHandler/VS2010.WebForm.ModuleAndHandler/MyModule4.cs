using System;
using System.Web;

namespace VS2010.WebForm.ModuleAndHandler
{
    /// <summary>
    /// 模块会话测试
    /// </summary>
    public class MyModule4 : IHttpModule
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
            context.AcquireRequestState += new EventHandler(context_AcquireRequestState);
        }

        void context_AcquireRequestState(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            context.Session[context.Session.SessionID] = "我是在模块中赋值的";
        }

        #endregion

        
    }
}
