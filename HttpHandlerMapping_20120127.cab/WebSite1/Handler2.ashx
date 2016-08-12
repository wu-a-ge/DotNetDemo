<%@ WebHandler Language="C#" Class="Handler2" %>

using System;
using System.Web;

public class Handler2 : IHttpHandler {

	private Counter _counter = new Counter();

	public bool IsReusable
	{
		get { return true; }
	}

	public void ProcessRequest(HttpContext context)
	{
		_counter.ShowCountAndRequestInfo(context);
	}
}