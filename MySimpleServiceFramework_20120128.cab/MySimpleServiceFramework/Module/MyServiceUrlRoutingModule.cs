using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;


namespace MySimpleServiceFramework
{
	/// <summary>
	/// 实现了URL路由的Module
	/// </summary>
	internal class MyServiceUrlRoutingModule : IHttpModule
	{
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
			MyServiceHandler handler = GetHandler(app.Context);
			if( handler == null )
				return;

			// 临时保存前面获取到的处理器，这个值将在PostMapRequestHandler事件中再取出来。
			app.Context.Items[s_dataKey] = handler;

			// 进入正常的MapRequestHandler事件，随便映射到一个处理器就行了。
			app.Context.RewritePath("~/MyServiceUrlRoutingModule.axd");
		}
	
		private void app_PostMapRequestHandler(object sender, EventArgs e)
		{
			HttpApplication app = (HttpApplication)sender;

			// 取出在PostResolveRequestCache事件中获得的处理器
			MyServiceHandler handler = (MyServiceHandler)app.Context.Items[s_dataKey];
			if( handler != null ) {
				// 还原URL请求地址。注意这里和URL重写的差别。
				app.Context.RewritePath(app.Request.RawUrl);

				// 还原根据GetHandler(app.Context)调用得到的处理器。
				// 因为此时app.Context.Handler是由"~/MyServiceUrlRoutingModule.axd"映射得到的。
				app.Context.Handler = handler;
			}
		}

		internal static MyServiceHandler GetHandler(HttpContext context)
		{
			NamesPair pair = FrameworkRules.ParseNamesPair(context.Request);
			if( pair == null )
				return null;

			InvokeInfo vkInfo = ReflectionHelper.GetInvokeInfo(pair);
			if( vkInfo == null )
				ExceptionHelper.Throw404Exception(context);


			MyServiceHandler handler = MyServiceHandlerFactory.GetHandler(vkInfo);
			handler.ServiceInfo = new ServiceInfo(pair, vkInfo);
			return handler;
		}

		public void Dispose()
		{
		}
	}
}
