using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySimpleServiceClient;

namespace MvcApplication1.Controllers
{
	[HandleError]
	public class HomeController : AsyncController
	{
		private static readonly string ServiceUrl = "http://localhost:22132/MyService.axd?sc=DemoService&op=ExtractNumber";

		public ActionResult Index()
		{
			return View();
		}

		//public ActionResult Test1()
		//{
		//    return View();
		//}


		// 实际可处理的Action名称为 Test1 ，注意名称后要加上 Async
		public void Test1Async()
		{
			// 告诉ASP.NET MVC，要开始一个异步操作了。
			AsyncManager.OutstandingOperations.Increment();

			string str = Guid.NewGuid().ToString();
			MyAysncClient<string, string> client = new MyAysncClient<string, string>(ServiceUrl);
			client.OnCallCompleted += new MyAysncClient<string, string>.CallCompletedEventHandler(client_OnCallCompleted);
			client.CallAysnc(str, str);		// 开始异步调用

		}

		void client_OnCallCompleted(object sender, MyAysncClient<string, string>.CallCompletedEventArgs e)
		{
			// 告诉ASP.NET MVC，一个异步操作结束了。
			AsyncManager.OutstandingOperations.Decrement();

			if( e.Error == null )
				AsyncManager.Parameters["result"] = string.Format("{0} => {1}", e.UserState, e.Result);
			else
				AsyncManager.Parameters["result"] = string.Format("{0} => Error: {1}", e.UserState, e.Error.Message);

			// AsyncManager.Parameters["result"] 用于写输出结果。
			// 这里仍然采用类似ViewData的设计。
			// 注意：key 的名称要和Test1Completed的参数名匹配。
		}

		// 注意名称后要加上 Completed ，且其余部分与Test1Async的前缀对应。
		public ActionResult Test1Completed(string result)
		{
			ViewData["result"] = result;
			return View();
		}

		private System.Diagnostics.Stopwatch _watch;

		public void Test2Async()
		{
			// 表示要开启3个异步操作。
			// 如果把这个数字设为2，极有可能会产生的错误的结果。不信你可以试一下。
			AsyncManager.OutstandingOperations.Increment(3);
			_watch = System.Diagnostics.Stopwatch.StartNew();

			string str = Guid.NewGuid().ToString();
			MyAysncClient<string, string> client = new MyAysncClient<string, string>(ServiceUrl);
			client.UserData = "result1";
			client.OnCallCompleted += new MyAysncClient<string, string>.CallCompletedEventHandler(client2_OnCallCompleted);
			client.CallAysnc(str, str);		// 开始第一个异步任务

			string str2 = "T2_" + Guid.NewGuid().ToString();
			MyAysncClient<string, string> client2 = new MyAysncClient<string, string>(ServiceUrl);
			client2.UserData = "result2";
			client2.OnCallCompleted += new MyAysncClient<string, string>.CallCompletedEventHandler(client2_OnCallCompleted);
			client2.CallAysnc(str2, str2);		// 开始第二个异步任务

			string str3 = "T3_" + Guid.NewGuid().ToString();
			MyAysncClient<string, string> client3 = new MyAysncClient<string, string>(ServiceUrl);
			client3.UserData = "result3";
			client3.OnCallCompleted += new MyAysncClient<string, string>.CallCompletedEventHandler(client2_OnCallCompleted);
			client3.CallAysnc(str3, str3);		// 开始第三个异步任务
		}

		void client2_OnCallCompleted(object sender, MyAysncClient<string, string>.CallCompletedEventArgs e)
		{
			// 递减内部的异步任务累加器。有点类似AspNetSynchronizationContext的设计。
			AsyncManager.OutstandingOperations.Decrement();

			MyAysncClient<string, string> client = (MyAysncClient<string, string>)sender;
			string key = client.UserData.ToString();

			if( e.Error == null )
				AsyncManager.Parameters[key] = string.Format("{0} => {1}", e.UserState, e.Result);
			else
				AsyncManager.Parameters[key] = string.Format("{0} => Error: {1}", e.UserState, e.Error.Message);
		}

		public ActionResult Test2Completed(string result1, string result2, string result3)
		{
			_watch.Stop();
			ViewData["time"] = _watch.Elapsed.ToString();

			ViewData["result1"] = result1;
			ViewData["result2"] = result2;
			ViewData["result3"] = result3;
			return View();
		}
	}
}
