using System;
using System.Web;

namespace VS2010.WebForm.ModuleAndHandler
{
    public class TestUrlRoutingModule : IHttpModule
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



        #endregion

        private static readonly object s_dataKey = new object();

        public void Init(HttpApplication app)
        {
            app.PostResolveRequestCache += new EventHandler(app_PostResolveRequestCache);
            app.PostMapRequestHandler += new EventHandler(app_PostMapRequestHandler);
        }

        private void app_PostResolveRequestCache(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;

            // 获取合适的处理器，注意这是与URL重写的根本差别。
            // 即：根据当前请求【主动】寻找一个处理器，而不是使用RewritePath让Asp.net替我们去找。
            TestUrlRewrite handler = new TestUrlRewrite();
            if (handler == null)
                return;

            // 临时保存前面获取到的处理器，这个值将在PostMapRequestHandler事件中再取出来。
            app.Context.Items[s_dataKey] = handler;

            // 进入正常的MapRequestHandler事件，随便映射到一个处理器就行了
            //这个重写的意义不大吧？？？
            //app.Context.RewritePath("~/MyServiceUrlRoutingModule.axd");
        }

        private void app_PostMapRequestHandler(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;

            // 取出在PostResolveRequestCache事件中获得的处理器
            TestUrlRewrite handler = (TestUrlRewrite)app.Context.Items[s_dataKey];
            if (handler != null)
            {
                // 还原URL请求地址。注意这里和URL重写的差别。
                //如果没有在app_PostResolveRequestCache处理函数中进行重写路径这里我觉得就没有必要
                //还原URL请求地址
                //app.Context.RewritePath(app.Request.RawUrl);

                // 还原根据GetHandler(app.Context)调用得到的处理器。
                // 因为此时app.Context.Handler是由"~/MyServiceUrlRoutingModule.axd"映射得到的。
                app.Context.Handler = handler;
            }
        }
    }
}
