using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySimpleServiceClient;


public partial class AsyncPage2 : System.Web.UI.Page
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

		// 准备回调数据，它将由AddOnPreRenderCompleteAsync的第三个参数被传入。
		MyHttpClient<string, string> http = new MyHttpClient<string, string>();
		http.UserData = textbox1.Text;

		// 注册一个异步任务。注意这三个参数哦。
		AddOnPreRenderCompleteAsync(BeginCall, EndCall, http);
	}

	private IAsyncResult BeginCall(object sender, EventArgs e, AsyncCallback cb, object extraData)
	{
		// 在这个方法中，
		// sender 就是 this
		// e 就是 EventArgs.Empty
		// cb 就是 EndCall
		// extraData 就是调用AddOnPreRenderCompleteAsync的第三个参数
		Trace.Warn("BeginCall ThreadId = " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());

		MyHttpClient<string, string> http = (MyHttpClient<string, string>)extraData;
		
		// 开始一个异步调用。页面线程也最终在执行这个调用后返回线程池了。
		// 中间则是等待网络的I/O的完成通知。
		// 如果网络调用完成，则会调用 cb 对应的回调委托，这个cb是一个内部的处理委托
		return http.BeginSendHttpRequest(ServiceUrl, (string)http.UserData, cb, http);
	}

	private void EndCall(IAsyncResult ar)
	{
		// 到这个方法中，表示一个任务执行完毕。
		// 参数 ar 就是BeginCall的返回值。

		Trace.Warn("EndCall ThreadId = " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());

		MyHttpClient<string, string> http = (MyHttpClient<string, string>)ar.AsyncState;
		string str = (string)http.UserData;

		try{
			// 结束异步调用，获取调用结果。如果有异常，也会在这里抛出。
			string result = http.EndSendHttpRequest(ar);
			labMessage.Text = string.Format("{0} => {1}", str, result);
		}
		catch(Exception ex){
			labMessage.Text = string.Format("{0} => Error: {1}", str, ex.Message);
		}
	}


}
