using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;


namespace MySimpleServiceFramework
{
	/// <summary>
	/// 实现了URL重写的Module
	/// </summary>
	internal class MyServiceUrlRewriteModule : IHttpModule
	{
		// 为了演示简单，直接写死地址。
		// 注意：MyService.axd 必须在web.config中注册，以保证它能成功映射。
		public static string RewriteUrlPattern = "/MyService.axd?sc={0}&op={1}";

		public void Init(HttpApplication app)
		{
			app.PostAuthorizeRequest += new EventHandler(app_PostAuthorizeRequest);
		}

		void app_PostAuthorizeRequest(object sender, EventArgs e)
		{
			HttpApplication app = (HttpApplication)sender;

			// 这里将检查URL是否为需要重写的模式，比如:
			//   http://localhost:11647/service/OrderService/QueryOrder
			NamesPair pair = FrameworkRules.ParseNamesPair(app.Request);
			if( pair == null )
				return;

			// 开始重写URL，最后将会映射到MyServiceHandler
			int p = app.Request.Path.IndexOf('?');
			if( p > 0 )
				app.Context.RewritePath(string.Format(RewriteUrlPattern, pair.ServiceName, pair.MethodName)
					+ "&" + app.Request.Path.Substring(p + 1)
					);
			else
				app.Context.RewritePath(string.Format(RewriteUrlPattern, pair.ServiceName, pair.MethodName));
		}
		

		public void Dispose()
		{
		}
	}
}
