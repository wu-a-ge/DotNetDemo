using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;


namespace MySimpleServiceFramework
{
	/// <summary>
	/// 【演示用】
	/// </summary>
	internal class MyLogModule : IHttpModule
	{
		public void Init(HttpApplication app)
		{
			app.BeginRequest += new EventHandler(app_BeginRequest);
		}

		void app_BeginRequest(object sender, EventArgs e)
		{
			HttpApplication app = (HttpApplication)sender;

			string input = string.Empty;

			if( app.Request.InputStream.Length > 0 ) {
				app.Request.InputStream.Position = 0;
				StreamReader sr = new StreamReader(app.Request.InputStream, app.Request.ContentEncoding);
				input = sr.ReadToEnd();
				app.Request.InputStream.Position = 0;
			}

			string text = string.Format("[RawUrl]\r\n\r\n{0}\r\n[Path]\r\n{1}\r\n\r\n[InputStream]\r\n{2}",
					app.Request.RawUrl, app.Request.Path, input);

			// =========================================
			System.Threading.Thread.Sleep(100);
			string path = Path.Combine(Path.GetTempPath(),
				string.Format("__fish_http_log_{0}.txt", DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_fff")));

			File.WriteAllText(path, text, System.Text.Encoding.UTF8);
		}

		public void Dispose()
		{
		}
	}
}
