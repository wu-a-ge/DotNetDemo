<%@ WebHandler Language="C#" Class="AsyncHandler" %>

using System;
using System.Web;
using ServiceClassLibrary;
using MySimpleServiceClient;

public class AsyncHandler : IHttpAsyncHandler {

	private static readonly string ServiceUrl = "http://localhost:22132/service/DemoService/CheckUserLogin";
	
	public void ProcessRequest(HttpContext context)
	{
		// 注意：这个方法没有必要实现。因为根本就不调用它。
		// 但要保留它，因为这个方法也是接口的一部分。
		throw new NotImplementedException();
	}
	
	public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
	{
		// 说明：
		//   参数cb是一个ASP.NET的内部委托，EndProcessRequest方法将在那个委托内部被调用。
		
		LoginInfo info = new LoginInfo();
		info.Username = context.Request.Form["Username"];
		info.Password = context.Request.Form["Password"];

		MyHttpClient<LoginInfo, string> http = new MyHttpClient<LoginInfo, string>();
		http.UserData = context;

		// ================== 开始异步调用 ============================
		// 注意：您所需要的回调委托，ASP.NET已经为您准备好了，直接用cb就好了。
		return http.BeginSendHttpRequest(ServiceUrl, info, cb, http);
		// ==============================================================
	}

	public void EndProcessRequest(IAsyncResult ar)
	{
		MyHttpClient<LoginInfo, string> http = (MyHttpClient<LoginInfo, string>)ar.AsyncState;
		HttpContext context = (HttpContext)http.UserData;
		
		context.Response.ContentType = "text/plain";
		context.Response.Write("AsyncHandler Result: ");

		try {
			// ============== 结束异步调用，并取得结果 ==================
			string result = http.EndSendHttpRequest(ar);
			// ==============================================================
			context.Response.Write(result);
		}
		catch( System.Net.WebException wex ) {
		    context.Response.StatusCode = 500;
			context.Response.Write(HttpWebRequestHelper.SimpleReadWebExceptionText(wex));
		}
		catch( Exception ex ) {
			context.Response.StatusCode = 500;
			context.Response.Write(ex.Message);
		}
	}

	public bool IsReusable
	{
		get
		{
			return false;
		}
	}
	

}