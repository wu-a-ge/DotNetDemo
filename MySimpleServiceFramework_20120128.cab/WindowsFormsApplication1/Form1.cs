using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO.Compression;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Web.Script.Serialization;
using ClassLibrary1;

namespace WindowsFormsApplication1
{
	public partial class Form1 : Form
	{
		private static readonly Encoding DefaultEncoding = System.Text.Encoding.UTF8;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			(from m in this.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
			 let a = (MyTestMethodAttribute[])m.GetCustomAttributes(typeof(MyTestMethodAttribute), false)
			 where a.Length > 0
			 select new MyTestMethodItem { Url = a[0].Url, MethodInfo = m }
			 ).ToList().ForEach(x => cboUrl.Items.Add(x));

			if( cboUrl.Items.Count > 0 )
				cboUrl.SelectedIndex = 0;
			else
				btnCall.Enabled = false;
		}


		private string GetMethodUrl()
		{
			StackTrace stack = new StackTrace();
			MyTestMethodAttribute[] attrs = (MyTestMethodAttribute[])stack.GetFrame(1).GetMethod().GetCustomAttributes(typeof(MyTestMethodAttribute), false);
			return attrs[0].Url;				
		}

		private void QueryOrder(string url, string serializerFormat)
		{
			try {
				QueryOrderCondition qoc = DataFactory.CreateQueryOrderCondition();

				string input = null;
				JavaScriptSerializer jss = new JavaScriptSerializer();

				if( serializerFormat == "json" ) 					
					input = jss.Serialize(qoc);
				else
					input = FishWebLib.FishSerializerHelper.XmlSerialize(qoc, Encoding.UTF8);

				string output = null;
				if( chkEnableGzip.Checked )
					output = SendHttpRequestWithGzip(url, input, serializerFormat);
				else
					output = SendHttpRequest(url, input, serializerFormat);

				List<Order> list = null;

				try {
					if( serializerFormat == "json" )
						list = jss.Deserialize<List<Order>>(output);
					else
						list = FishWebLib.FishSerializerHelper.XmlDeserialize<List<Order>>(output, Encoding.UTF8);
				}
				catch( Exception ex ) {
					throw new InvalidDataException(
						string.Concat(@"反序列化数据失败，原数据：
==================================================================================
", output, @"
==================================================================================
"						), ex);
				}

				// 为了能看得更清楚，程序以XML的方式显示结果
				textBox2.Text = FishWebLib.FishSerializerHelper.XmlSerializeObject(list, DefaultEncoding);
			}
			catch( Exception ex ) {
				textBox2.Text = ex.ToString();
			}
		}


		[MyTestMethod("http://localhost:11647/QueryOrderService.ashx")]
		private void Test_QueryOrder1()
		{
			QueryOrder(GetMethodUrl(), "json");
		}


		[MyTestMethod("http://localhost:11647/MyService.axd?sc=OrderService&op=QueryOrder")]
		private void Test_QueryOrder2()
		{
			QueryOrder(GetMethodUrl(), "json");
		}


		[MyTestMethod("http://localhost:11647/service/OrderService/QueryOrder")]
		private void Test_QueryOrder3()
		{
			QueryOrder(GetMethodUrl(), "xml");
		}

		[MyTestMethod("http://localhost:11647/MyService.ashx?sc=OrderService&op=QueryOrder")]
		private void Test_QueryOrder4()
		{
			QueryOrder(GetMethodUrl(), "xml");
		}


		private bool SimpleCallService(string url, string data, string serializerFormat)
		{
			try {
				string result = SendHttpRequest(url, data, serializerFormat);
				textBox2.Text = result;
				return true;
			}
			catch( Exception ex ) {
				MessageBox.Show(ex.GetBaseException().Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return false;
			}
		}


		[MyTestMethod("http://localhost:11647/service/OrderService/Hello")]
		private void Test_Hello()
		{
			SimpleCallService(GetMethodUrl(), "\"fish-li\"", "json");
		}

		[MyTestMethod("http://localhost:11647/service/OrderService/HiddenMethod")]
		private void Test_HiddenMethod()
		{
			SimpleCallService(GetMethodUrl(), "\"aaaaaa\"", "json");
		}

		[MyTestMethod("http://localhost:11647/service/FormDemoService/ShowOrderDetail")]
		private void Test_ShowOrderDetail()
		{
			string data = "OrderID=3&Quantity=5&ProductID=2&ProductName=aaaaaaa&Unit=bb&UnitPrice=123.45";
			SimpleCallService(GetMethodUrl(), data, null);
		}

		Random _rand = new Random();
		private int _counter = 0;

		[MyTestMethod("http://localhost:11647/service/SessionDemoService/Add")]
		private void Test_Add()
		{
			int n = _rand.Next(1, 20);
			MessageBox.Show(string.Format("当前累加数：{0}", n.ToString()));

			bool ok = SimpleCallService(GetMethodUrl(), n.ToString(), "json");

			int currentVal = 0;
			int.TryParse(textBox2.Text, out currentVal);

			if( ok && currentVal != _counter + n )
				MessageBox.Show("服务端计算错了。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

			_counter = currentVal;
		}

		[MyTestMethod("http://localhost:11647/service/LimitService/CalcPassword")]
		private void Test_CalcPassword()
		{
			SimpleCallService(GetMethodUrl(), "\"fish\"", "json");
		}

		[MyTestMethod("http://localhost:11647/service/LimitService/CalcBase64")]
		private void Test_CalcBase64()
		{
			SimpleCallService(GetMethodUrl(), "\"李奇峰\"", "json");
		}

		[MyTestMethod("http://localhost:11647/service/FormDemoService/ShowUrlInfo")]
		private void Test_ShowUrlInfo()
		{
			SimpleCallService(GetMethodUrl(), "", null);
		}


		private void button1_Click(object sender, EventArgs e)
		{
			MyTestMethodItem item = (MyTestMethodItem)cboUrl.SelectedItem;
			if( item == null )
				return;

			item.MethodInfo.Invoke(this, null);
		}



		private CookieContainer _cookieContainer = new CookieContainer();

		private HttpWebRequest CreateHttpWebRequest(string url, string serializerFormat)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.Method = "POST";
			request.UserAgent = "Fish's C# Client";
			request.CookieContainer = _cookieContainer;

			if( string.IsNullOrEmpty(serializerFormat) )
				request.ContentType = "application/x-www-form-urlencoded";
			else
				request.Headers["Serializer-Format"] = serializerFormat;

			return request;
		}


		private string SendHttpRequest(string url, string data, string serializerFormat)
		{
			HttpWebRequest request = CreateHttpWebRequest(url, serializerFormat);

			using( BinaryWriter bw = new BinaryWriter(request.GetRequestStream()) ) {
				bw.Write(DefaultEncoding.GetBytes(data));
			}

			return GetResponse(request);
		}


		private string SendHttpRequestWithGzip(string url, string data, string serializerFormat)
		{
			HttpWebRequest request = CreateHttpWebRequest(url, serializerFormat);
			request.Headers.Add("Content-Encoding", "gzip");

			using( GZipStream gzip = new GZipStream(request.GetRequestStream(), CompressionMode.Compress) ) {
				using( BinaryWriter bw = new BinaryWriter(gzip) ) {
					bw.Write(DefaultEncoding.GetBytes(data));
				}
			}

			return GetResponse(request);
		}


		private string GetResponse(HttpWebRequest request)
		{
			string error = null;
			WebResponse response = null;
			try {
				response = request.GetResponse();
			}
			catch( WebException ex ) {
				response = ex.Response;
				if( response == null )
					return ex.GetBaseException().Message;

				HttpWebResponse httpResponse = (HttpWebResponse)response;
				error = string.Format("({0}) {1}\r\n\r\n", httpResponse.StatusCode.ToString("D"), httpResponse.StatusDescription);
			}

			if( response != null ) {
				Stream strem = null;
				if( response.Headers["Content-Encoding"] == "gzip" )
					strem = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
				else
					strem = response.GetResponseStream();
				
				using( StreamReader reader = new StreamReader(strem) ) {
					return error + reader.ReadToEnd();
				}
			}

			return string.Empty;
		}


		private void btnLogin_Click(object sender, EventArgs e)
		{
			this.contextMenuStrip1.Show(Cursor.Position);
		}
		
		private void UserLogin(object sender, EventArgs e)
		{
			string url = "http://localhost:11647/Login.ashx";
			string data = string.Format("name={0}&password=aaaa", (sender as ToolStripItem).Text);
			string result = SendHttpRequest(url, data, null);
			MessageBox.Show(result, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnLogout_Click(object sender, EventArgs e)
		{
			string url = "http://localhost:11647/Logout.ashx";
			string result = SendHttpRequest(url, string.Empty, null);
			MessageBox.Show(result, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}





	}
}
