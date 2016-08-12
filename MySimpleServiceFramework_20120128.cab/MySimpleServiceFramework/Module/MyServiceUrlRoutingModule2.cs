using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MySimpleServiceFramework
{
	/// <summary>
	/// 实现了URL路由的Module
	/// </summary>
	internal class MyServiceUrlRoutingModule2 : IHttpModule
	{
		public void Init(HttpApplication app)
		{
			app.PostResolveRequestCache += new EventHandler(app_PostResolveRequestCache);
		}

		private void app_PostResolveRequestCache(object sender, EventArgs e)
		{
			HttpApplication app = (HttpApplication)sender;

			// 根据HttpContext，获取合适的HttpHandler，这个过程俗称路由
			// 通常就是根据URL去主动寻找一个合适的HttpHandler

			// 查找过程仍使用上一版的方法
			MyServiceHandler handler = MyServiceUrlRoutingModule.GetHandler(app.Context);
			if( handler != null )
				// 直接设置已找到的HttpHandler
				app.Context.RemapHandler(handler);
		}

		public void Dispose()
		{
		}
	}
}
