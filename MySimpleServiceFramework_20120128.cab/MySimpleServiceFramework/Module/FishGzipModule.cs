using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO.Compression;

namespace MySimpleServiceFramework
{
	/// <summary>
	/// 【演示用】让Aspx页的请求支持gzip压缩输出
	/// </summary>
	internal class FishGzipModule : IHttpModule
	{
		public void Init(HttpApplication app)
		{
			app.BeginRequest += new EventHandler(app_BeginRequest);
		}

		void app_BeginRequest(object sender, EventArgs e)
		{
			HttpApplication app = (HttpApplication)sender;

			// 这里做个简单的演示，只处理aspx页面的输出压缩。
			// 当然了，IIS也提供压缩功能，这里也仅当演示用，或许可适用于一些特殊场合。
			if( app.Request.AppRelativeCurrentExecutionFilePath.EndsWith(
								"aspx", StringComparison.OrdinalIgnoreCase) == false )
				// 注意：先判断是不是要处理的请求，如果不是，直接退出。
				//        而不是：先执行了后面的判断，再发现不是aspx时才退出。
				return;


			string flag = app.Request.Headers["Accept-Encoding"];
			if( string.IsNullOrEmpty(flag) == false && flag.ToLower().IndexOf("gzip") >= 0 ) {
				app.Response.Filter = new GZipStream(app.Response.Filter, CompressionMode.Compress);
				app.Response.AppendHeader("Content-Encoding", "gzip");
			}
		}


		public void Dispose()
		{
		}
	}
}
