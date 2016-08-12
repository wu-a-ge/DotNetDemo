using System;
using System.Web;

namespace VS2010.WebForm.ModuleAndHandler
{
    public class MyModule2 : IHttpModule
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
            context.PostResolveRequestCache += new EventHandler(context_PostResolveRequestCache);
            //=========================创建HttpHandler=====================================
            context.PostMapRequestHandler += new EventHandler(context_PostMapRequestHandler);
            context.AcquireRequestState += new EventHandler(context_AcquireRequestState);
            context.PreRequestHandlerExecute += new EventHandler(context_PreRequestHandlerExecute);
            //=========================执行HttpHandler=======================================
            context.PostRequestHandlerExecute += new EventHandler(context_PostRequestHandlerExecute);
            context.EndRequest += new EventHandler(context_EndRequest);
            context.PreSendRequestContent += new EventHandler(context_PreSendRequestContent);
        }


        void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            response.Write("<div>我来自自定义HttpModule2中的BeginRequest此输出放在了html前面</div>");
        }

        void context_PostResolveRequestCache(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
        }

        //========================为请求上下文创建HttpHandler=======================

        void context_PostMapRequestHandler(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            //用自定义上下文处理程序来处理请求
            context.Handler = new IISHandler1() as IHttpHandler;
        }


        void context_AcquireRequestState(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            //用自定义上下文处理程序来处理请求
            //context.Handler = new IISHandler1() as IHttpHandler;
        }
        void context_PreRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            HttpRequest request = application.Request;
            HttpResponse response = application.Response;
            //用自定义上下文处理程序来处理请求
            //context.Handler = new IISHandler1() as IHttpHandler;
        }

        //=========================执行HttpHandler=======================================

        void context_PostRequestHandlerExecute(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
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

            response.Write("<div>我来自自定义HttpModule2中的EndRequest此输出放在了html后面</div>");
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
