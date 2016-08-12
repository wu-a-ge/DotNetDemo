using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySimpleServiceClient;


public partial class AsyncPage3 : System.Web.UI.Page
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

		// 准备回调数据，它将由PageAsyncTask构造函数的第四个参数被传入。
		MyHttpClient<string, string> http = new MyHttpClient<string, string>();
		http.UserData = textbox1.Text;

		// 创建异步任务
		PageAsyncTask task = new PageAsyncTask(BeginCall, EndCall, TimeoutCall, http);
		// 注册异步任务
		RegisterAsyncTask(task);
	}

	private IAsyncResult BeginCall(object sender, EventArgs e, AsyncCallback cb, object extraData)
	{
		// 在这个方法中，
		// sender 就是 this
		// e 就是 EventArgs.Empty
		// cb 是ASP.NET定义的一个委托，我们只管在异步调用它时把它用作回调委托就行了。
		// extraData 就是PageAsyncTask构造函数的第四个参数
		Trace.Warn("BeginCall ThreadId = " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());

		MyHttpClient<string, string> http = (MyHttpClient<string, string>)extraData;

		// 开始一个异步调用。
		return http.BeginSendHttpRequest(ServiceUrl, (string)http.UserData, cb, http);
	}

	private void EndCall(IAsyncResult ar)
	{
		// 到这个方法中，表示一个任务执行完毕。
		// 参数 ar 就是BeginCall的返回值。
		Trace.Warn("EndCall ThreadId = " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());

		MyHttpClient<string, string> http = (MyHttpClient<string, string>)ar.AsyncState;
		string str = (string)http.UserData;

		try {
			// 结束异步调用，获取调用结果。如果有异常，也会在这里抛出。
			string result = http.EndSendHttpRequest(ar);
			labMessage.Text = string.Format("{0} => {1}", str, result);
		}
		catch( Exception ex ) {
			labMessage.Text = string.Format("{0} => Error: {1}", str, ex.Message);
		}
	}

	private void TimeoutCall(IAsyncResult ar)
	{
		// 到这个方法，就表示任务执行超时了。
		Trace.Warn("TimeoutCall ThreadId = " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());

		MyHttpClient<string, string> http = (MyHttpClient<string, string>)ar.AsyncState;
		string str = (string)http.UserData;

		labMessage.Text = string.Format("{0} => Timeout.", str);
	}
}
