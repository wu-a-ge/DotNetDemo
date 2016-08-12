<%@ WebHandler Language="C#" Class="QueryOrderService" %>

using System;
using System.Web;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.IO;
using System.IO.Compression;
using ClassLibrary1;


public class QueryOrderService : IHttpHandler
{

	// 这是上一篇博客【我心目中的Asp.net核心对象】留下来的示例代码。
	// http://www.cnblogs.com/fish-li/archive/2011/08/21/2148640.html

	// 注意：已经删除了调用GZIP相关的代码，因为现在已经在web.config中使用了DuplexGzipModule

	public void ProcessRequest(HttpContext context)
	{
		context.Response.ContentType = "application/json";
		
		JavaScriptSerializer jss = new JavaScriptSerializer();

		StreamReader sr = new StreamReader(context.Request.InputStream);
		string input = sr.ReadToEnd();

		QueryOrderCondition query = jss.Deserialize<QueryOrderCondition>(input);

		// 模拟查询过程，这里就直接返回一个列表。		
		List<Order> list = new List<Order>();
		for( int i = 0; i < 10; i++ )
			list.Add(DataFactory.CreateRandomOrder());

		string json = jss.Serialize(list);

		context.Response.Write(json);
	}
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}