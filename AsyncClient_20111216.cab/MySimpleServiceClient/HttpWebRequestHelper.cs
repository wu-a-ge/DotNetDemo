using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Web.Script.Serialization;

namespace MySimpleServiceClient
{
	/// <summary>
	/// 【调用我的服务框架的工具类】
	/// 专用于发送HTTP请求的工具类的【简化版本】，只能处理输入和输出都是字符串的场景。
	/// 说明：如果需要 自定义HTTP消息头或者提供对Cookie的支持，请处理事件OnCreateHttpWebRequest
	/// </summary>
	public static class HttpWebRequestHelper
	{
		/// <summary>
		/// 【同步方式】简单地调用一个服务方法，此服务方法的输入输出都是字符串
		/// </summary>
		/// <param name="url"></param>
		/// <param name="input"></param>
		/// <returns></returns>
		public static string SendHttpRequest(string url, string input)
		{
			//bool isThreadPoolThread = System.Threading.Thread.CurrentThread.IsThreadPoolThread;
			return HttpWebRequestHelper<string, string>.SendHttpRequest(url, input);
		}

		/// <summary>
		/// 【异步方式】简单地调用一个服务方法，此服务方法的输入输出都是字符串
		/// </summary>
		/// <param name="url"></param>
		/// <param name="input"></param>
		/// <param name="callback"></param>
		/// <param name="state"></param>
		public static void SendHttpRequestAsync(string url, string input, Action<string, string, Exception, object> callback, object state)
		{
			HttpWebRequestHelper<string, string>.SendHttpRequestAsync(url, input, callback, state);
		}

		/// <summary>
		/// 使用指定的URL，创建一个HttpWebRequest对象。
		/// </summary>
		/// <param name="url"></param>
		/// <returns></returns>
		public static HttpWebRequest CreateHttpWebRequest(string url)
		{
			return CreateHttpWebRequest(url, null);
		}

		/// <summary>
		/// 在调用CreateHttpWebRequest即将结束时引发的事件，用于自定义HTTP消息头或者提供对Cookie的支持。
		/// </summary>
		public static event CreateHttpWebRequestHandler OnCreateHttpWebRequest;

		/// <summary>
		/// 使用指定的URL以及数据的序列化格式，创建一个HttpWebRequest对象。
		/// </summary>
		/// <param name="url"></param>
		/// <param name="serializerFormat">序列化格式消息头。可以传入null 表示不使用序列化。</param>
		/// <returns></returns>
		public static HttpWebRequest CreateHttpWebRequest(string url, string serializerFormat)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = "POST";
			request.UserAgent = "Fish's C# Client";

			if( HttpWebRequestHelperOption.IsUseDefaultCredentials )
				request.Credentials = CredentialCache.DefaultCredentials;
			
			if( string.IsNullOrEmpty(serializerFormat) )
				request.ContentType = "application/x-www-form-urlencoded";
			else
				request.Headers["Serializer-Format"] = serializerFormat;


			CreateHttpWebRequestHandler handler = OnCreateHttpWebRequest;
			if( handler != null )
				handler(request);

			return request;
		}

		/// <summary>
		/// 读取响应内容。
		/// </summary>
		/// <param name="response"></param>
		/// <returns></returns>
		public static string ReadResponse(HttpWebResponse response)
		{
			Stream strem = null;
			if( response.Headers["Content-Encoding"] == "gzip" )
				strem = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
			else
				strem = response.GetResponseStream();

			using( StreamReader reader = new StreamReader(strem) ) {
				return reader.ReadToEnd();
			}
		}

		/// <summary>
		/// 读取异常中的服务器响应内容。方法仅仅简单地读取内容，不做其它处理。
		/// </summary>
		/// <param name="wex"></param>
		/// <returns></returns>
		public static string SimpleReadWebExceptionText(WebException wex)
		{
			if( wex == null )
				throw new ArgumentNullException("wex");

			if( wex.Response == null )
				return wex.Message;

			using( StreamReader reader = new StreamReader(wex.Response.GetResponseStream()) ) {
				return reader.ReadToEnd();
			}
		}



		// 加二个简单的HTTP方法，有时确实需要

		/// <summary>
		/// 发送一个HTTP GET请求。【就是简单地发送请求，模拟浏览器行为】
		/// </summary>
		/// <param name="url"></param>
		/// <returns></returns>
		public static string HttpGet(string url)
		{
			HttpWebRequest request = CreateHttpWebRequest(url);
			request.Method = "GET";

			using( HttpWebResponse response = (HttpWebResponse)request.GetResponse() ) {
				return HttpWebRequestHelper.ReadResponse(response);
			}
		}

		/// <summary>
		/// 发送一个HTTP POST请求。【就是简单地发送请求，模拟浏览器行为】
		/// </summary>
		/// <param name="url"></param>
		/// <param name="postData"></param>
		/// <returns></returns>
		public static string HttpPost(string url, string postData)
		{
			if( string.IsNullOrEmpty(postData) )
				return HttpGet(url);

			HttpWebRequest request = CreateHttpWebRequest(url);

			// 发送请求数据
			using( BinaryWriter bw = new BinaryWriter(request.GetRequestStream()) ) {
				bw.Write(HttpWebRequestHelperOption.DefaultEncoding.GetBytes(postData));
			}

			using( HttpWebResponse response = (HttpWebResponse)request.GetResponse() ) {
				return HttpWebRequestHelper.ReadResponse(response);
			}
		}
	}

	/// <summary>
	/// 创建HttpWebRequest之后的事件处理器。
	/// </summary>
	/// <param name="request"></param>
	public delegate void CreateHttpWebRequestHandler(HttpWebRequest request);

	/// <summary>
	/// 一些与HttpWebRequest相关的参数，它对整个类库有效。
	/// </summary>
	public static class HttpWebRequestHelperOption
	{
		/// <summary>
		/// 默认的字符编码方式
		/// </summary>
		public static readonly Encoding DefaultEncoding = System.Text.Encoding.UTF8;

		/// <summary>
		/// 每次发送HTTP请求时，是否要使用当前的登录信息。
		/// 注意：这个参数与线程相关，只对设置过它的线程有效。
		/// </summary>
		[ThreadStatic]
		public static bool IsUseDefaultCredentials;		
	}


	/// <summary>
	/// 【调用我的服务框架的工具类】
	/// 工具提供二个方法用于发起同步请求和异步请求：SendHttpRequest， SendHttpRequestAsync
	/// 考虑到参数较少，调用简单，我将此类实现为静态类，不提供任何public数据成员。
	/// </summary>
	/// <typeparam name="TIn"></typeparam>
	/// <typeparam name="TOut"></typeparam>
	public static class HttpWebRequestHelper<TIn, TOut>
	{
		/// <summary>
		/// 同步调用服务
		/// </summary>
		/// <param name="url"></param>
		/// <param name="input"></param>
		/// <returns></returns>
		public static TOut SendHttpRequest(string url, TIn input)
		{
			if( string.IsNullOrEmpty(url) )
				throw new ArgumentNullException("url");
			if( input == null )
				throw new ArgumentNullException("input");

			// 为了简单，这里仅使用JSON序列化方式
			JavaScriptSerializer jss = new JavaScriptSerializer();
			string jsonData = jss.Serialize(input);

			// 创建请求对象
			HttpWebRequest request = HttpWebRequestHelper.CreateHttpWebRequest(url, "json");

			// 发送请求数据
			using( BinaryWriter bw = new BinaryWriter(request.GetRequestStream()) ) {
				bw.Write(HttpWebRequestHelperOption.DefaultEncoding.GetBytes(jsonData));
			}

			// 获取响应对象，并读取响应内容
			using( HttpWebResponse response = (HttpWebResponse)request.GetResponse() ) {
				string responseText = HttpWebRequestHelper.ReadResponse(response);
				return jss.Deserialize<TOut>(responseText);
			}
		}


		/// <summary>
		/// 用于所有回调状态的数据类
		/// </summary>
		private class MyCallbackParam
		{
			public TIn InputData;
			public Action<TIn, TOut, Exception, object> Callback;
			public object State;
			public HttpWebRequest Request;
			public JavaScriptSerializer Jss;
		}

		/// <summary>
		/// 异步调用服务
		/// </summary>
		/// <param name="url"></param>
		/// <param name="input"></param>
		/// <param name="callback">服务调用完成后的回调委托，用于处理调用结果</param>
		/// <param name="state"></param>
		public static void SendHttpRequestAsync(string url, TIn input, 
						Action<TIn, TOut, Exception, object> callback, object state)
		{
			if( string.IsNullOrEmpty(url) )
				throw new ArgumentNullException("url");
			if( input == null )
				throw new ArgumentNullException("input");
			if( callback == null )
				throw new ArgumentNullException("callback");

			// 创建请求对象
			HttpWebRequest request = HttpWebRequestHelper.CreateHttpWebRequest(url, "json");

			// 记录必要的回调参数
			MyCallbackParam cp = new MyCallbackParam {
				Callback = callback,
				InputData = input,
				State = state,
				Request = request,
			};

			// 开始异步写入请求数据
			request.BeginGetRequestStream(AsyncWriteRequestStream, cp);

			// 虽然BeginGetRequestStream()可以返回一个IAsyncResult对象，
			// 但我却不想返回这个对象，因为整个过程需要二次异步。
		}

		private static void AsyncWriteRequestStream(IAsyncResult ar)
		{
			// 取出回调前的状态参数
			MyCallbackParam cp = (MyCallbackParam)ar.AsyncState;

			try {
				// 为了简单，这里仅使用JSON序列化方式
				JavaScriptSerializer jss = new JavaScriptSerializer();
				string jsonData = jss.Serialize(cp.InputData);
				cp.Jss = jss;

				// 结束写入数据的操作
				using( BinaryWriter bw = new BinaryWriter(cp.Request.EndGetRequestStream(ar)) ) {
					bw.Write(HttpWebRequestHelperOption.DefaultEncoding.GetBytes(jsonData));
				}

				// 开始异步向服务器发起请求
				cp.Request.BeginGetResponse(GetResponseCallback, cp);
			}
			catch( Exception ex ) {
				cp.Callback(cp.InputData, default(TOut), ex, cp.State);
			}
		}

		private static void GetResponseCallback(IAsyncResult ar)
		{
			// 取出回调前的状态参数
			MyCallbackParam cp = (MyCallbackParam)ar.AsyncState;

			try {
				// 读取服务器的响应
				using( HttpWebResponse response = (HttpWebResponse)cp.Request.EndGetResponse(ar) ) {
					string responseText = HttpWebRequestHelper.ReadResponse(response);
					TOut result = cp.Jss.Deserialize<TOut>(responseText);

					// 返回结果，通过回调用户的回调方法来完成。
					cp.Callback(cp.InputData, result, null, cp.State);
				}
			}
			catch( Exception ex ) {
				cp.Callback(cp.InputData, default(TOut), ex, cp.State);
			}
		}
	}
}
