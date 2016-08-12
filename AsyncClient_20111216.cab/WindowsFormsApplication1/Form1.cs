using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using System.Runtime.Remoting.Messaging;
using System.Data.SqlClient;
using MySimpleServiceClient;

namespace WindowsFormsApplication1
{
	public partial class Form1 : Form
	{
		private SynchronizationContext _syncContext;

		private static readonly string ServiceUrl = "http://localhost:22132/MyService.axd?sc=DemoService&op=ExtractNumber";
		//private static readonly string ServiceUrl = "http://localhost:22132/service/DemoService/ExtractNumber";

		public Form1()
		{
			InitializeComponent();
			_syncContext = SynchronizationContext.Current;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			linkLabel1_Click(null, null);

			linkLabel2_Click(null, null);
		}

		private void linkLabel1_Click(object sender, EventArgs e)
		{
			txtInput.Text = Guid.NewGuid().ToString();
		}

		private void linkLabel2_Click(object sender, EventArgs e)
		{
			txtOutput.Text = "ServiceUrl: " + ServiceUrl + "\r\n要调用的服务代码：" +
@"
//--------------------------------------------------------
public static string ExtractNumber(string str)
{
	// 延迟3秒，模拟一个长时间的调用操作，便于客户演示异步的效果。
	System.Threading.Thread.Sleep(3000);
	//.................................
}
//--------------------------------------------------------";
		}


		private void btnCall_Click(object sender, EventArgs e)
		{
			string str = txtInput.Text.Trim();
			if( str.Length == 0 ) {
				MessageBox.Show("没有要处理的字符串。",
									this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				txtInput.Focus();
				return;
			}

			string method = (
					from c in this.groupBox1.Controls.OfType<RadioButton>()
					where c.Checked
					select c.Tag.ToString()
				).First();
			
			this.GetType().InvokeMember(method,
				BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.NonPublic,
				null, this, new object[] { str });
		}

		

		/// <summary>
		/// 显示结果
		/// </summary>
		/// <param name="line"></param>
		private void ShowResult(string line)
		{
			// 可以在这个方法中设置断点观察这些变量的状态（在使用前取消注释）。
			// 注意要对比各种调用方式的差别。
			//bool isBackground = System.Threading.Thread.CurrentThread.IsBackground;
			//bool isThreadPoolThread = System.Threading.Thread.CurrentThread.IsThreadPoolThread;

			if( txtOutput.InvokeRequired )
				// 采用同步上下文的方式切换线程调用。
				_syncContext.Post(x => txtOutput.Text += "\r\n" + line, null /*直接使用闭包参数*/);
			else
				txtOutput.Text += "\r\n" + line;
		}



		/// <summary>
		/// 同步调用服务，此时界面应该会【卡住】。
		/// </summary>
		/// <param name="str"></param>
		private void SyncCallService(string str)
		{
			try {
				string result = HttpWebRequestHelper.SendHttpRequest(ServiceUrl, str);
				ShowResult(string.Format("{0} => {1}", str, result));
			}
			catch( Exception ex ) {
				ShowResult(string.Format("{0} => Error: {1}", str, ex.Message));
			}
		}



		/// <summary>
		/// 委托异步调用
		/// </summary>
		/// <param name="str"></param>
		private void CallViaDelegate(string str)
		{
			Func<string, string, string> func = HttpWebRequestHelper.SendHttpRequest;

			func.BeginInvoke(ServiceUrl, str, CallViaDelegateCallback, str);
		}

		private void CallViaDelegateCallback(IAsyncResult ar)
		{
			string str = (string)ar.AsyncState;
			Func<string, string, string> func 
						= (ar as AsyncResult).AsyncDelegate as Func<string, string, string>;
			try {
				// 如果有异常，会在这里被重新抛出。
				string result = func.EndInvoke(ar);
				ShowResult(string.Format("{0} => {1}", str, result));
			}
			catch( Exception ex ) {
				ShowResult(string.Format("{0} => Error: {1}", str, ex.Message));
			}
		}

		private void CallViaDelegate_X2(string str)
		{
			Func<string, string, string> func = HttpWebRequestHelper.SendHttpRequest;

			IAsyncResult ar = func.BeginInvoke(ServiceUrl, str, null, null);

			//-----------------------------------------------
			// 可在此执行【其它计算操作】，
			// 也可以在此再发起另一个异步调用。
			//-----------------------------------------------

			// 这里有可能会引起阻塞，
			// 具体情况要看【其它计算操作】的执行时间是否超过异步调用的时间
			string result = func.EndInvoke(ar);
			//...处理结果
			ShowResult(string.Format("{0} => {1}", str, result));
		}






		/// <summary>
		/// 使用IAsyncResult接口实现异步调用
		/// </summary>
		/// <param name="str"></param>
		private void CallViaIAsyncResult(string str)
		{
			HttpWebRequestHelper.SendHttpRequestAsync(ServiceUrl, str, CallViaIAsyncResultCallback, null);
		}

		private void CallViaIAsyncResultCallback(string str, string result, Exception ex, object state)
		{
			if( ex == null )
				ShowResult(string.Format("{0} => {1}", str, result));
			else
				ShowResult(string.Format("{0} => Error: {1}", str, ex.Message));
		}






		/// <summary>
		/// 基于事件的异步模式
		/// </summary>
		/// <param name="str"></param>
		private void CallViaEvent(string str)
		{
			MyAysncClient<string, string> client = new MyAysncClient<string, string>(ServiceUrl);
			client.OnCallCompleted += new MyAysncClient<string, string>.CallCompletedEventHandler(client_OnCallCompleted);
			client.CallAysnc(str, str);
		}

		void client_OnCallCompleted(object sender, MyAysncClient<string, string>.CallCompletedEventArgs e)
		{
			//bool flag = txtOutput.InvokeRequired;	// 注意：这里flag的值是false，也就是说可以直接操作UI界面
			if( e.Error == null ) 
				ShowResult(string.Format("{0} => {1}", e.UserState, e.Result));
			else
				ShowResult(string.Format("{0} => Error: {1}", e.UserState, e.Error.Message));		
		}





		
		/// <summary>
		/// 创建新线程的异步方式
		/// </summary>
		/// <param name="str"></param>
		private void CreateThread(string str)
		{
			Thread thread = new Thread(ThreadProc);
			thread.IsBackground = true;
			thread.Start(str);
		}

	
		private void ThreadProc(object obj)
		{
			string str = (string)obj;

			try {
				// 由于是在后台线程中，这里就直接调用同步方法。
				SyncCallService(str);
			}
			catch( Exception ex ) {
				ShowResult(string.Format("{0} => Error: {1}", str, ex.Message));
			}
		}


		/// <summary>
		/// 直接使用线程池的异步方式
		/// </summary>
		/// <param name="str"></param>
		private void UseThreadPool(string str)
		{
			ThreadPool.QueueUserWorkItem(ThreadProc, str);
		}



		/// <summary>
		/// 使用BackgroundWorker实现异步调用
		/// </summary>
		/// <param name="str"></param>
		private void UseBackgroundWorker(string str)
		{
			BackgroundWorker worker = new BackgroundWorker();
			worker.DoWork += new DoWorkEventHandler(worker_DoWork);
			worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
			worker.RunWorkerAsync(str);
		}
		void worker_DoWork(object sender, DoWorkEventArgs e)
		{
			//bool isThreadPoolThread = System.Threading.Thread.CurrentThread.IsThreadPoolThread;
			string str = (string)e.Argument;
			string result = HttpWebRequestHelper.SendHttpRequest(ServiceUrl, str);

			// 这个结果将在RunWorkerCompleted事件中使用
			e.Result = string.Format("{0} => {1}", str, result);
		}
		void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			//bool isThreadPoolThread = System.Threading.Thread.CurrentThread.IsThreadPoolThread;
			// 此时可以直接使用UI控件。
			if( e.Error != null )
				txtOutput.Text += "\r\n" + string.Format("Error: {0}", e.Error.Message);
			else 
				txtOutput.Text += "\r\n" + (string)e.Result;
		}






		/// <summary>
		/// 使用自已包装的IAsyncResult接口
		/// </summary>
		/// <param name="str"></param>
		private void CallViaIAsyncResult2(string str)
		{
			MyHttpClient<string, string> http = new MyHttpClient<string, string>();
			http.UserData = str;

			http.BeginSendHttpRequest(ServiceUrl, str, CallViaIAsyncResultCallback2, http);
		}

		private void CallViaIAsyncResultCallback2(IAsyncResult ar)
		{
			MyHttpClient<string, string> http = (MyHttpClient<string, string>)ar.AsyncState;
			string str = (string)http.UserData;

			try {
				string result = http.EndSendHttpRequest(ar);
				ShowResult(string.Format("{0} => {1}", str, result));
			}
			catch( Exception ex ) {
				ShowResult(string.Format("{0} => Error: {1}", str, ex.Message));
			}
		}



        private void CallViaIAsyncResult2X(string str)
        {
            MyHttpClient<string, string> http = new MyHttpClient<string, string>();

            IAsyncResult ar = http.BeginSendHttpRequest(ServiceUrl, str, null, null);

            //while( ar.IsCompleted == false )
            //    Thread.SpinWait(1);
            //一个基本的场景，异步调用没有结束，阻塞，等待接收信号
            //WaitHandle waitHandle = ar.AsyncWaitHandle;
            //if (waitHandle != null)
            //    waitHandle.WaitOne();

            try
            {
                //一个场景，异步调用没有结束，同样会被阻塞，等待异步结束
                string result = http.EndSendHttpRequest(ar);
                ShowResult(string.Format("{0} => {1}", str, result));
            }
            catch (Exception ex)
            {
                ShowResult(string.Format("{0} => Error: {1}", str, ex.Message));
            }
        }









		/// <summary>
		/// 获取数据库中所有由用户创建的数据库的查询语句。注意我特意延迟了3秒。
		/// </summary>
		private static readonly string s_QueryDatabaseListScript =
			@"  WAITFOR DELAY '00:00:03';
				SELECT dtb.name AS [Database_Name] FROM master.sys.databases AS dtb 
				WHERE (CAST(case when dtb.name in ('master','model','msdb','tempdb') then 1 else dtb.is_distributor end AS bit)=0 
				and CAST(isnull(dtb.source_database_id, 0) AS bit)=0) 
				ORDER BY [Database_Name] ASC";

		private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Action action = BeginExecuteReader;
			// 采用委托的异步调用防止在打开连接时界面停止响应。
			// 这里并不需要回调。相当于 OneWay 的操作。
			action.BeginInvoke(null, null);
		}

		private void BeginExecuteReader()
		{
			string connectionString = @"server=localhost\sqlexpress;Integrated Security=SSPI;Asynchronous Processing=true";
			SqlConnection connection = new SqlConnection(connectionString);
			try {
				// 注意：这里是同步调用，第一次连接或者连接字符串无效时会让界面停止响应。
				connection.Open();
			}
			catch( Exception ex ) {
				ShowResult(ex.Message + "\r\n当前连接字符串：" + connectionString);
				return;
			}

			SqlCommand command = new SqlCommand(s_QueryDatabaseListScript, connection);
			command.BeginExecuteReader(EndExecuteReader, command);
		}

		private void EndExecuteReader(IAsyncResult ar)
		{
			SqlCommand command = (SqlCommand)ar.AsyncState;
			StringBuilder sb = new StringBuilder();

			try {
				// 如果SQL语句有错误，会在这里抛出。
				using( SqlDataReader reader = command.EndExecuteReader(ar) ) {
					while( reader.Read() ) {
						sb.Append(reader.GetString(0)).Append("; ");
					}
				}
			}
			catch( Exception ex ) {
				ShowResult(ex.Message);
			}
			finally {
				command.Connection.Close();
			}

			if( sb.Length > 0 )
				ShowResult("可用数据库列表：" + sb.ToString(0, sb.Length - 2));
		}

	}
}
