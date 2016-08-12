using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Reflection;
using System.Web.SessionState;

namespace MySimpleServiceFramework
{
	internal class MyServiceHandler : IHttpHandler
	{
		internal ServiceInfo ServiceInfo { get; set; }

		public void ProcessRequest(HttpContext context)
		{
			ServiceInfo info = this.ServiceInfo ?? GetServiceInfo(context);

			ServiceExecutor.ProcessRequest(context, info);
		}

		private static ServiceInfo GetServiceInfo(HttpContext context)
		{
			NamesPair pair = new NamesPair();
			pair.ServiceName = context.Request.QueryString["sc"];
			pair.MethodName = context.Request.QueryString["op"];

			if( string.IsNullOrEmpty(pair.ServiceName) || string.IsNullOrEmpty(pair.MethodName) )
				ExceptionHelper.Throw404Exception(context);


			InvokeInfo vkInfo = ReflectionHelper.GetInvokeInfo(pair);
			if( vkInfo == null )
				ExceptionHelper.Throw404Exception(context);

			return new ServiceInfo(pair, vkInfo);
		}

		public bool IsReusable
		{
			get { return false; }
		}
	}


	internal class RequiresSessionServiceHandler : MyServiceHandler, IRequiresSessionState 
	{
		// 不用再写任何代码。
	}

	internal class ReadOnlySessionServiceHandler : MyServiceHandler, IRequiresSessionState, IReadOnlySessionState 
	{
		// 不用再写任何代码。
	}



}
