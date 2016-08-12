<%@ WebHandler Language="C#" Class="Handler1" %>

using System;
using System.Web;

public class Handler1 : IHttpHandler {

	private Counter _counter = new Counter();

	public bool IsReusable
	{
		get {
			// 如果在配置文件中启用ReusableAshxHandlerFactory，那么这里将会被执行。
			// 可以尝试切换下面二行代码测试效果。

			//throw new Exception("这里不起作用。");
			return false;
		}
	}

	public void ProcessRequest(HttpContext context)
	{
		_counter.ShowCountAndRequestInfo(context);
	}
}