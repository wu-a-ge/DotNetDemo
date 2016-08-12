using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySimpleServiceClient;


public partial class AsyncPage4 : System.Web.UI.Page
{
	//private static readonly string ServiceUrl = "http://localhost:22132/MyService.axd?sc=DemoService&op=ExtractNumber";
	private static readonly string ServiceUrl = "http://localhost:22132/service/DemoService/ExtractNumber";

	//private readonly bool _showStackTrace = true;
	private readonly bool _showStackTrace = false;

	private void ShowThreadInfo(string message)
	{
		Trace.Warn(message
			+ " , ThreadId = " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString()
			+ " , Time: " + DateTime.Now.ToString("HH:mm:ss:fff"));

		if( _showStackTrace == false )
			return;

		Trace.Write("---------------------------------------------------------------------");
		DebugUtils.GetStackTrace(1).ForEach(x => Trace.Write(x));
		Trace.Write(" ");
	}


	protected void Page_Load(object sender, EventArgs e)
	{
		ShowThreadInfo("Page_Load");
	}


	


	protected void button1_click(object sender, EventArgs e)
	{		
		ShowThreadInfo("button1_click");

		// 为PageAsyncTask设置超时时间
		Page.AsyncTimeout = new TimeSpan(0, 0, 7);

		// 开启4个PageAsyncTask，其中第1，4个任务不接受并行执行，2，3则允许并行执行
		Async_RegisterAsyncTask("RegisterAsyncTask_1", false);
		Async_RegisterAsyncTask("RegisterAsyncTask_2", true);
		Async_RegisterAsyncTask("RegisterAsyncTask_3", true);
		Async_RegisterAsyncTask("RegisterAsyncTask_4", false);

		// 开启3个AddOnPreRenderCompleteAsync的任务
		Async_AddOnPreRenderCompleteAsync("AddOnPreRenderCompleteAsync_1");
		Async_AddOnPreRenderCompleteAsync("AddOnPreRenderCompleteAsync_2");
		Async_AddOnPreRenderCompleteAsync("AddOnPreRenderCompleteAsync_3");

		// 最后开启3个基于事件通知的异步任务，其中第2个任务由于设置了超时，将不能成功完成。
		Async_Event("MyAysncClient_1", 0);
		Async_Event("MyAysncClient_2", 2000);
		Async_Event("MyAysncClient_3", 0);

		Async_Event("MyAysncClient_4", 0);
		Async_Event("MyAysncClient_5", 0);
		Async_Event("MyAysncClient_6", 0);
		Async_Event("MyAysncClient_7", 0);
		Async_Event("MyAysncClient_8", 0);
	}

	private void Async_RegisterAsyncTask(string taskName, bool executeInParallel)
	{
		MyHttpClient<string, string> http = new MyHttpClient<string, string>();
		http.UserData = taskName;
		PageAsyncTask task = new PageAsyncTask(BeginCall_Task, EndCall_Task, TimeoutCall_Task, http, executeInParallel);
		RegisterAsyncTask(task);
	}
	private void Async_AddOnPreRenderCompleteAsync(string taskName)
	{
		MyHttpClient<string, string> http = new MyHttpClient<string, string>();
		http.UserData = taskName;
		AddOnPreRenderCompleteAsync(BeginCall, EndCall, http);
	}
	private void Async_Event(string taskName, int timeoutMilliseconds)
	{
		MyAysncClient<string, string> client = new MyAysncClient<string, string>(ServiceUrl, timeoutMilliseconds);
		client.OnCallCompleted += new MyAysncClient<string, string>.CallCompletedEventHandler(client_OnCallCompleted);
		client.CallAysnc(taskName, taskName);
	}


	void client_OnCallCompleted(object sender, MyAysncClient<string, string>.CallCompletedEventArgs e)
	{
		ShowThreadInfo("client_OnCallCompleted " + e.UserState);

		if( e.Error == null )
			labMessage.Text += ", " + string.Format("{0} => {1}", e.UserState, e.Result);
		else {
			if( e.Error is TimeoutException )
				Trace.Warn("client_" + e.UserState.ToString() + " Timeout. ");

			labMessage.Text += ", " + string.Format("{0} => Error: {1}", e.UserState, e.Error.Message);
		}
	}




	private IAsyncResult BeginCall_Task(object sender, EventArgs e, AsyncCallback cb, object extraData)
	{
		MyHttpClient<string, string> http = (MyHttpClient<string, string>)extraData;
		string str = (string)http.UserData;

		ShowThreadInfo("BeginCall " + str);

		return http.BeginSendHttpRequest(ServiceUrl, (string)http.UserData, cb, http);
	}

	private void EndCall_Task(IAsyncResult ar)
	{
		MyHttpClient<string, string> http = (MyHttpClient<string, string>)ar.AsyncState;
		string str = (string)http.UserData;

		ShowThreadInfo("EndCall " + str);

		try {
			string result = http.EndSendHttpRequest(ar);
			labMessage2.Text += ", " + string.Format("{0} => {1}", str, result);
		}
		catch( Exception ex ) {
			labMessage2.Text += ", " + string.Format("{0} => Error: {1}", str, ex.Message);
		}
	}


	private void TimeoutCall_Task(IAsyncResult ar)
	{
		MyHttpClient<string, string> http = (MyHttpClient<string, string>)ar.AsyncState;
		string str = (string)http.UserData;

		ShowThreadInfo("TimeoutCall " + str);

		labMessage2.Text += ", " + string.Format("{0} => Timeout.", str);
	}


	


	private IAsyncResult BeginCall(object sender, EventArgs e, AsyncCallback cb, object extraData)
	{
		MyHttpClient<string, string> http = (MyHttpClient<string, string>)extraData;
		string str = (string)http.UserData;

		ShowThreadInfo("BeginCall " + str);

		return http.BeginSendHttpRequest(ServiceUrl, (string)http.UserData, cb, http);
	}

	private void EndCall(IAsyncResult ar)
	{
		MyHttpClient<string, string> http = (MyHttpClient<string, string>)ar.AsyncState;
		string str = (string)http.UserData;

		ShowThreadInfo("EndCall " + str);

		try {
			string result = http.EndSendHttpRequest(ar);
			labMessage3.Text += ", " + string.Format("{0} => {1}", str, result);
		}
		catch( Exception ex ) {
			labMessage3.Text += ", " + string.Format("{0} => Error: {1}", str, ex.Message);
		}
	}








	//// 将指定的 System.Web.HttpApplication.AcquireRequestState 事件
	//// 添加到当前请求的异步 System.Web.HttpApplication.AcquireRequestState事件处理程序的集合。
    //public void AddOnAcquireRequestStateAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);

	//// 将指定的 System.Web.HttpApplication.AuthenticateRequest 事件
	//// 添加到当前请求的异步 System.Web.HttpApplication.AuthenticateRequest事件处理程序的集合。
	//public void AddOnAuthenticateRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);

	//// 将指定的 System.Web.HttpApplication.AuthorizeRequest 事件
	//// 添加到当前请求的异步 System.Web.HttpApplication.AuthorizeRequest事件处理程序的集合。
	//public void AddOnAuthorizeRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);

	//// 将指定的 System.Web.HttpApplication.BeginRequest 事件
	//// 添加到当前请求的异步 System.Web.HttpApplication.BeginRequest事件处理程序的集合。
	//public void AddOnBeginRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);

	//// 将指定的 System.Web.HttpApplication.EndRequest 事件
	//// 添加到当前请求的异步 System.Web.HttpApplication.EndRequest事件处理程序的集合。
	//public void AddOnEndRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);

	//public void AddOnLogRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);

	//public void AddOnMapRequestHandlerAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);

	//// 将指定的 System.Web.HttpApplication.PostAcquireRequestState 事件
	//// 添加到当前请求的异步 System.Web.HttpApplication.PostAcquireRequestState事件处理程序的集合。
	//public void AddOnPostAcquireRequestStateAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);

	//// 将指定的 System.Web.HttpApplication.PostAuthenticateRequest 事件
	//// 添加到当前请求的异步 System.Web.HttpApplication.PostAuthenticateRequest事件处理程序的集合。
	//public void AddOnPostAuthenticateRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);

	//// 将指定的 System.Web.HttpApplication.PostAuthorizeRequest 事件
	//// 添加到当前请求的异步 System.Web.HttpApplication.PostAuthorizeRequest事件处理程序的集合。
	//public void AddOnPostAuthorizeRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);

	//public void AddOnPostLogRequestAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);

	//// 将指定的 System.Web.HttpApplication.PostMapRequestHandler 事件
	//// 添加到当前请求的异步 System.Web.HttpApplication.PostMapRequestHandler事件处理程序的集合。
	//public void AddOnPostMapRequestHandlerAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);

	//// 将指定的 System.Web.HttpApplication.PostReleaseRequestState 事件
	//// 添加到当前请求的异步 System.Web.HttpApplication.PostReleaseRequestState事件处理程序的集合。
	//public void AddOnPostReleaseRequestStateAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);

	//// 将指定的 System.Web.HttpApplication.PostRequestHandlerExecute 事件
	//// 添加到当前请求的异步 System.Web.HttpApplication.PostRequestHandlerExecute事件处理程序的集合。
	//public void AddOnPostRequestHandlerExecuteAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);

	//// 将指定的 System.Web.HttpApplication.PostResolveRequestCache 事件
	//// 添加到当前请求的异步 System.Web.HttpApplication.PostResolveRequestCache事件处理程序的集合。
	//public void AddOnPostResolveRequestCacheAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);

	//// 将指定的 System.Web.HttpApplication.PostUpdateRequestCache 事件
	//// 添加到当前请求的异步 System.Web.HttpApplication.PostUpdateRequestCache事件处理程序的集合。
	//public void AddOnPostUpdateRequestCacheAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);

	//// 将指定的 System.Web.HttpApplication.PreRequestHandlerExecute 事件
	//// 添加到当前请求的异步 System.Web.HttpApplication.PreRequestHandlerExecute事件处理程序的集合。
	//public void AddOnPreRequestHandlerExecuteAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);

	//// 将指定的 System.Web.HttpApplication.ReleaseRequestState 事件
	//// 添加到当前请求的异步 System.Web.HttpApplication.ReleaseRequestState事件处理程序的集合。
	//public void AddOnReleaseRequestStateAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);

	//// 将指定的 System.Web.HttpApplication.ResolveRequestCache 事件处理程序
	//// 添加到当前请求的异步 System.Web.HttpApplication.ResolveRequestCache事件处理程序的集合。
	//public void AddOnResolveRequestCacheAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);

	//// 将指定的 System.Web.HttpApplication.UpdateRequestCache 事件
	//// 添加到当前请求的异步 System.Web.HttpApplication.UpdateRequestCache事件处理程序的集合。
	//public void AddOnUpdateRequestCacheAsync(BeginEventHandler beginHandler, EndEventHandler endHandler, object state);





}
