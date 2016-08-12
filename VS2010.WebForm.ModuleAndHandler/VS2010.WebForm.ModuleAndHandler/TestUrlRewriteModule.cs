using System;
using System.Web;

namespace VS2010.WebForm.ModuleAndHandler
{
    public class TestUrlRewriteModule : IHttpModule
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

     
        public static string RewriteUrlPattern = "/MyService.axd?sc={0}&op={1}";
        public void Init(HttpApplication app)
        {
            app.PostResolveRequestCache += new EventHandler(app_PostResolveRequestCache);
        }

        private void app_PostResolveRequestCache(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            // 开始重写URL，最后将会映射到
            int p = app.Request.Path.IndexOf('?');
            if (p > 0)
                app.Context.RewritePath(string.Format(RewriteUrlPattern, "c1", "post")
                    + "&" + app.Request.Path.Substring(p + 1)
                    );
            else
                app.Context.RewritePath(string.Format(RewriteUrlPattern, "c2","get"));
        }

      
    }
}
