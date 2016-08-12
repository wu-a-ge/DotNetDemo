using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text;


/// <summary>
/// 【示例代码】演示异步的HttpModule
/// 说明：这个示例一丁点意义也没有，纯粹是为了演示。
/// </summary>
public class MyAsyncHttpModule  : IHttpModule
{
	public static readonly object HttpContextItemsKey = new object();

	private static readonly string s_QueryDatabaseListScript =
		@"select dtb.name  from master.sys.databases as dtb order by 1";

	private static readonly string s_ConnectionString =
		@"server=.;Integrated Security=SSPI;Asynchronous Processing=true";


	public void Init(HttpApplication app)
	{
		// 注意异步事件
		app.AddOnBeginRequestAsync(BeginCall, EndExecuteReader, null);
	}
	
	private IAsyncResult BeginCall(object sender, EventArgs e, AsyncCallback cb, object extraData)
	{
		SqlConnection connection = new SqlConnection(s_ConnectionString);
		connection.Open();

		SqlCommand command = new SqlCommand(s_QueryDatabaseListScript, connection);

		CallbackParam cbParam = new CallbackParam {
			Command = command,
			Context = HttpContext.Current
		};

		return command.BeginExecuteReader(cb, cbParam);
	}

	private class CallbackParam
	{
		public SqlCommand Command;
		public HttpContext Context;
	}

	private void EndExecuteReader(IAsyncResult ar)
	{
		CallbackParam cbParam = (CallbackParam)ar.AsyncState;
		StringBuilder sb = new StringBuilder();

		try {
			using( SqlDataReader reader = cbParam.Command.EndExecuteReader(ar) ) {
				while( reader.Read() ) {
					sb.Append(reader.GetString(0)).Append("; ");
				}
			}
		}
		catch( Exception ex ) {
			cbParam.Context.Items[HttpContextItemsKey] = ex.Message;
		}
		finally {
			cbParam.Command.Connection.Close();
		}

		if( sb.Length > 0 )
			cbParam.Context.Items[HttpContextItemsKey] = "数据库列表：" + sb.ToString(0, sb.Length - 2);
	}

	public void Dispose()
	{
	}
}
