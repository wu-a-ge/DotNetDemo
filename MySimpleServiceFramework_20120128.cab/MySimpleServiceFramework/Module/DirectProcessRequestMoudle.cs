using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MySimpleServiceFramework
{
	/// <summary>
	/// 此Module示范了直接使用Module也能处理客户端的请求。
	/// 建议：除非要很好的理由，否则不建议使用这种方法。
	/// </summary>
	internal class DirectProcessRequestMoudle : IHttpModule
	{
		public void Init(HttpApplication app)
		{
			app.PostAuthorizeRequest += new EventHandler(app_PostAuthorizeRequest);
		}

		void app_PostAuthorizeRequest(object sender, EventArgs e)
		{
			HttpApplication app = (HttpApplication)sender;

			ServiceInfo info = GetServiceInfo(app.Context);
			if( info == null )
				return;

			ServiceExecutor.ProcessRequest(app.Context, info);
			app.Response.End();
		}

		private ServiceInfo GetServiceInfo(HttpContext context)
		{
			NamesPair pair = FrameworkRules.ParseNamesPair(context.Request);
			if( pair == null )
				return null;

			InvokeInfo vkInfo = ReflectionHelper.GetInvokeInfo(pair);
			if( vkInfo == null )
				return null;

			return new ServiceInfo(pair, vkInfo);
		}

		public void Dispose()
		{
		}
	}
}
