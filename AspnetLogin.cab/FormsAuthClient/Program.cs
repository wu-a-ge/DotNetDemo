using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using FishDemoCodeLib;

namespace FormsAuthClient
{
	class Program
	{
		private static readonly string LoginUrl = "http://localhost:51855/default.aspx";
		private static readonly string MyInfoPageUrl = "http://localhost:51855/MyInfo.aspx";

		static void Main(string[] args)
		{
			// 创建一个CookieContainer实例，供多次请求之间共享Cookie
			CookieContainer cookieContainer = new CookieContainer();

			// 首先去登录页面登录
			MyHttpClient.HttpPost(LoginUrl, "NormalLogin=aa&loginName=Fish", cookieContainer);

			// 此时cookieContainer已经包含了服务端生成的登录Cookie

			// 再去访问要请求的页面。
			string html = MyHttpClient.HttpGet(MyInfoPageUrl, cookieContainer);

			if( html.IndexOf("<span>Fish</span>") > 0 )
				Console.WriteLine("调用成功。");
			else
				Console.WriteLine("页面结果不符合预期。");

			// 如果还要访问其它的受限页面，可以继续调用。
		}

		//static void Main(string[] args)
		//{
		//    // 这个调用得到的结果其实是default.aspx页面的输出，并非MyInfo.aspx
		//    HttpWebRequest request = MyHttpClient.CreateHttpWebRequest(MyInfoPageUrl);
		//    string html = MyHttpClient.GetResponseText(request);

		//    if( html.IndexOf("<span>Fish</span>") > 0 )
		//        Console.WriteLine("调用成功。");
		//    else
		//        Console.WriteLine("页面结果不符合预期。");
		//}




	}
}
