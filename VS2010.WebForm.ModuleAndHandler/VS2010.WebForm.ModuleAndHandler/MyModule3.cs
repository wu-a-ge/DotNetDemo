using System;
using System.Web;

namespace VS2010.WebForm.ModuleAndHandler
{
    public class MyModule3 : IHttpModule
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
          
            context.BeginRequest += new EventHandler(context_BeginRequest);
            context.AuthenticateRequest += new EventHandler(context_AuthenticateRequest);
            //IIS7以上且集成管线且.net3.0以上
            //context.LogRequest += new EventHandler(context_LogRequest);
            context.EndRequest += new EventHandler(context_EndRequest);
            context.PreSendRequestContent += new EventHandler(context_PreSendRequestContent);
        }


        void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            response.Write("<div>我来自自定义HttpModule3中的BeginRequest此输出放在了html前面</div>");

            if (request.Path.ToLower() != "/webform2.aspx")
            {
                application.CompleteRequest();
                response.Redirect("webform2.aspx");
            }
        }
        void context_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            response.Write("<div>我来自自定义HttpModule3中的AuthenticateRequest</div>");
        }
  
        //====================IIS7以上且集成管线且.net3.0以上
        void context_LogRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            response.Write("<div>我来自自定义HttpModule3中的LogRequest</div>");
        }


        void context_EndRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;

            response.Write("<div>我来自自定义HttpModule3中的EndRequest此输出放在了html后面</div>");
        }
        void context_PreSendRequestContent(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;

        }
        #endregion

    }
}
