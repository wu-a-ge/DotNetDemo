using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MySimpleServiceClient;
using System.Threading;


/// <summary>
///WebService1 的摘要说明
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
//若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。 
// [System.Web.Script.Services.ScriptService]
public class WebService1 : System.Web.Services.WebService
{

	public WebService1()
	{
		//如果使用设计的组件，请取消注释以下行 
		//InitializeComponent(); 
	}

	private static readonly string ServiceUrl = "http://localhost:22132/MyService.axd?sc=DemoService&op=ExtractNumber";


	//[WebMethod]
	//public string ExtractNumber(string str)
	//{
	//    //return ........
	//}
	

	[WebMethod]
	public IAsyncResult BeginExtractNumber(string str, AsyncCallback cb, object state)
	{
		MyHttpClient<string, string> http = new MyHttpClient<string, string>();
		http.UserData = "Begin ThreadId: " + Thread.CurrentThread.ManagedThreadId.ToString();

		return http.BeginSendHttpRequest(ServiceUrl, str, cb, http);
	}

	[WebMethod]
	public string EndExtractNumber(IAsyncResult ar)
	{
		MyHttpClient<string, string> http = (MyHttpClient<string, string>)ar.AsyncState;
		try{
			return http.EndSendHttpRequest(ar) +
				", " + http.UserData.ToString() +
				", End ThreadId: " + Thread.CurrentThread.ManagedThreadId.ToString();
		}
		catch(Exception ex){
			return ex.ToString();
		}
	}

}

