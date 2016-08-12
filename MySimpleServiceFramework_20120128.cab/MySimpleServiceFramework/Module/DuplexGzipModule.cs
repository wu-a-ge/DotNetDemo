using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO.Compression;


namespace MySimpleServiceFramework
{
	/// <summary>
	/// 能支持双向GZIP压缩的Module，它会根据客户端是否启用GZIP来自动处理。
	/// 对于服务来说，不用关心GZIP处理，服务只要处理输入输出就可以了。
	/// </summary>
	internal class DuplexGzipModule : IHttpModule
	{
		public void Init(HttpApplication app)
		{
			app.BeginRequest += new EventHandler(app_BeginRequest);
		}

		void app_BeginRequest(object sender, EventArgs e)
		{
			HttpApplication app = (HttpApplication)sender;

			// 注意：这里不能使用"Accept-Encoding"这个头，二者的意义完全不同。
			if( app.Request.Headers["Content-Encoding"] == "gzip" ) {
				app.Request.Filter = new GZipStream(app.Request.Filter, CompressionMode.Decompress);

				app.Response.Filter = new GZipStream(app.Response.Filter, CompressionMode.Compress);
				app.Response.AppendHeader("Content-Encoding", "gzip");
			}
		}


		public void Dispose()
		{
		}
	}
}
