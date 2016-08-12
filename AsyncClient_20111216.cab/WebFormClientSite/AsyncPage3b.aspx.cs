using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySimpleServiceClient;


public partial class AsyncPage3b : System.Web.UI.Page
{
	private static readonly string ServiceUrl = "http://localhost:22132/MyService.axd?sc=DemoService&op=ExtractNumber";

	protected void Page_Load(object sender, EventArgs e)
	{
		Trace.Write("Page_Load ThreadId = " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());

		if( this.IsPostBack == false )
			textbox1.Text = Guid.NewGuid().ToString();
	}


	protected void button1_click(object sender, EventArgs e)
	{
		Trace.Write("button1_click ThreadId = " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());

		// 设置页面超时时间为4秒
		Page.AsyncTimeout = new TimeSpan(0, 0, 4);
        //让两个异步任务并行运行必须调用重载方法参数设置为true，否则就是同步执行
		// 注册第一个异步任务
		MyHttpClient<string, string> http = new MyHttpClient<string, string>();
		http.UserData = textbox1.Text;
		PageAsyncTask task = new PageAsyncTask(BeginCall, EndCall, TimeoutCall, http, true /*注意这个参数*/);
		RegisterAsyncTask(task);

		// 注册第二个异步任务
		MyHttpClient<string, string> http2 = new MyHttpClient<string, string>();
		http2.UserData = "T2_" + Guid.NewGuid().ToString();
		PageAsyncTask task2 = new PageAsyncTask(BeginCall2, EndCall2, TimeoutCall2, http2, true /*注意这个参数*/);
		RegisterAsyncTask(task2);
	}


	private IAsyncResult BeginCall(object sender, EventArgs e, AsyncCallback cb, object extraData)
	{
		Trace.Warn("BeginCall ThreadId = " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());

		MyHttpClient<string, string> http = (MyHttpClient<string, string>)extraData;

		return http.BeginSendHttpRequest(ServiceUrl, (string)http.UserData, cb, http);
	}

	private void EndCall(IAsyncResult ar)
	{
		Trace.Warn("EndCall ThreadId = " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());

		MyHttpClient<string, string> http = (MyHttpClient<string, string>)ar.AsyncState;
		string str = (string)http.UserData;

		try {
			string result = http.EndSendHttpRequest(ar);
			labMessage.Text = string.Format("{0} => {1}", str, result);
		}
		catch( Exception ex ) {
			labMessage.Text = string.Format("{0} => Error: {1}", str, ex.Message);
		}
	}


	private void TimeoutCall(IAsyncResult ar)
	{
		Trace.Warn("TimeoutCall ThreadId = " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());

		MyHttpClient<string, string> http = (MyHttpClient<string, string>)ar.AsyncState;
		string str = (string)http.UserData;

		labMessage.Text = string.Format("{0} => Timeout.", str);
	}








	private IAsyncResult BeginCall2(object sender, EventArgs e, AsyncCallback cb, object extraData)
	{
		Trace.Warn("BeginCall2 ThreadId = " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());

		MyHttpClient<string, string> http = (MyHttpClient<string, string>)extraData;

		return http.BeginSendHttpRequest(ServiceUrl, (string)http.UserData, cb, http);
	}

	private void EndCall2(IAsyncResult ar)
	{
		Trace.Warn("EndCall2 ThreadId = " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());

		MyHttpClient<string, string> http = (MyHttpClient<string, string>)ar.AsyncState;
		string str = (string)http.UserData;

		try {
			string result = http.EndSendHttpRequest(ar);
			labMessage2.Text = string.Format("{0} => {1}", str, result);
		}
		catch( Exception ex ) {
			labMessage2.Text = string.Format("{0} => Error: {1}", str, ex.Message);
		}
	}


	private void TimeoutCall2(IAsyncResult ar)
	{
		Trace.Warn("TimeoutCall2 ThreadId = " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());

		MyHttpClient<string, string> http = (MyHttpClient<string, string>)ar.AsyncState;
		string str = (string)http.UserData;

		labMessage2.Text = string.Format("{0} => Timeout.", str);
	}
}
