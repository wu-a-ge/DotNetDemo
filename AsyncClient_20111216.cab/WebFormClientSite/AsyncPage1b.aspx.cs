using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySimpleServiceClient;


public partial class AsyncPage1b : System.Web.UI.Page
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
		string str = textbox1.Text;

		// 注意：这个异步任务，我设置了2秒的超时。它应该是不能按时完成任务的。
		MyAysncClient<string, string> client = new MyAysncClient<string, string>(ServiceUrl, 2000);
		client.OnCallCompleted += new MyAysncClient<string, string>.CallCompletedEventHandler(client_OnCallCompleted);
		client.CallAysnc(str, str);		// 开始第一个异步任务

		System.Threading.Thread.Sleep(3000);

		string str2 = "T2_" + Guid.NewGuid().ToString();
		MyAysncClient<string, string> client2 = new MyAysncClient<string, string>(ServiceUrl);
		client2.OnCallCompleted += new MyAysncClient<string, string>.CallCompletedEventHandler(client2_OnCallCompleted);
		client2.CallAysnc(str2, str2);		// 开始第二个异步任务
	}	

	void client2_OnCallCompleted(object sender, MyAysncClient<string, string>.CallCompletedEventArgs e)
	{
		ShowCallResult(2, e);


		// 再来一个异步调用
		string str3 = "T3_" + Guid.NewGuid().ToString();
		MyAysncClient<string, string> client3 = new MyAysncClient<string, string>(ServiceUrl);
		client3.OnCallCompleted += new MyAysncClient<string, string>.CallCompletedEventHandler(client3_OnCallCompleted);
		client3.CallAysnc(str3, str3);		// 开始第三个异步任务
	}

	void client_OnCallCompleted(object sender, MyAysncClient<string, string>.CallCompletedEventArgs e)
	{
		ShowCallResult(1, e);
	}

	void client3_OnCallCompleted(object sender, MyAysncClient<string, string>.CallCompletedEventArgs e)
	{
		ShowCallResult(3, e);
	}

	private void ShowCallResult(int clientIndex, MyAysncClient<string, string>.CallCompletedEventArgs e)
	{
		Trace.Warn("client" + clientIndex.ToString() +
			"_OnCallCompleted ThreadId = " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());

		if( e.Error == null )
			labMessage2.Text = string.Format("{0} => {1}", e.UserState, e.Result);
		else {
			if( e.Error is TimeoutException )
				Trace.Warn("client" + clientIndex.ToString() + " Timeout. ");

			labMessage2.Text = string.Format("{0} => Error: {1}", e.UserState, e.Error.Message);
		}
	}

}
