using System;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;


namespace VS2010.WebForm.ModuleAndHandler
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
            context.Error += new EventHandler(context_Error);
            context.BeginRequest += new EventHandler(context_BeginRequest);
            context.AuthenticateRequest += new EventHandler(context_AuthenticateRequest);
            context.AuthorizeRequest += new EventHandler(context_AuthorizeRequest);
            context.ResolveRequestCache += new EventHandler(context_ResolveRequestCache);
            context.PostMapRequestHandler += new EventHandler(context_PostMapRequestHandler);
            context.AcquireRequestState += new EventHandler(context_AcquireRequestState);
            context.PreRequestHandlerExecute += new EventHandler(context_PreRequestHandlerExecute);
            context.PostRequestHandlerExecute += new EventHandler(context_PostRequestHandlerExecute);
            context.ReleaseRequestState += new EventHandler(context_ReleaseRequestState);
            context.UpdateRequestCache += new EventHandler(context_UpdateRequestCache);
            context.PostUpdateRequestCache += new EventHandler(context_PostUpdateRequestCache);
            //IIS7以上且集成管线且.net3.0以上
            //context.LogRequest += new EventHandler(OnLogRequest);
            context.EndRequest += new EventHandler(context_EndRequest);
            context.PreSendRequestContent += new EventHandler(context_PreSendRequestContent);
            context.PreSendRequestHeaders += new EventHandler(context_PreSendRequestHeaders);
            
        }


        void context_Error(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
        }
        void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            //装配过滤器
            //response.Filter = new SiteFilter(response.Filter);
            response.Filter = new SiteFilter(response.Filter);
            response.Write("<div>我来自自定义HttpModule1中的BeginRequest此输出放在了html前面</div>");
        }

        void context_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;

        }
        void context_AuthorizeRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;

        }

        void context_ResolveRequestCache(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
        }

        void context_PostMapRequestHandler(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
        }

        void context_AcquireRequestState(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
        }
        void context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
 
        }

        void context_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;

        }

        void context_ReleaseRequestState(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
        }

        void context_UpdateRequestCache(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
        }

        void context_PostUpdateRequestCache(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
        }

        //PostUpdateRequestCache事件处理方法执行之后所有响应筛选器都将对输出进行筛选，即Response.Filter指定的筛选器！

        public void OnLogRequest(Object source, EventArgs e)
        {
            //可以在此放置自定义日志记录逻辑
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
        }
        void context_EndRequest(object sender, EventArgs e)
        {

            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            response.Write("<div>我来自自定义HttpModule1中的EndRequest此输出放在了html后面</div>");

        }
        void context_PreSendRequestHeaders(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
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
