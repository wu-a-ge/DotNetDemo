using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySimpleServiceClient;


public partial class AsyncPage1 : System.Web.UI.Page
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

		CallViaEvent(str);
	}


	private void CallViaEvent(string str)
	{
		MyAysncClient<string, string> client = new MyAysncClient<string, string>(ServiceUrl);
		client.OnCallCompleted += new MyAysncClient<string, string>.CallCompletedEventHandler(client_OnCallCompleted);
		client.CallAysnc(str, str);
	}

	void client_OnCallCompleted(object sender, MyAysncClient<string, string>.CallCompletedEventArgs e)
	{
		Trace.Warn("client_OnCallCompleted ThreadId = " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());

		if( e.Error == null )
			labMessage.Text = string.Format("{0} => {1}", e.UserState, e.Result);
		else
			labMessage.Text = string.Format("{0} => Error: {1}", e.UserState, e.Error.Message);
	}

	//void client_OnCallCompleted(object sender, MyAysncClient<string, string>.CallCompletedEventArgs e)
	//{
	//    try {
	//        labMessage.Text = string.Format("{0} => {1}", e.UserState, e.Result);
	//    }
	//    catch( Exception ex ) {
	//        labMessage.Text = string.Format("{0} => Error: {1}", e.UserState, ex.Message);
	//    }
	//}

}
