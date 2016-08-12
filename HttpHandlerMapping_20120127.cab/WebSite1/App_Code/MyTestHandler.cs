using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class MyTestHandler : IHttpHandler
{
	private Counter _counter = new Counter();

	public bool IsReusable
	{
		get { return true; }
		//get { return false; }
	}

	public void ProcessRequest(HttpContext context)
	{
		_counter.ShowCountAndRequestInfo(context);
	}
}
