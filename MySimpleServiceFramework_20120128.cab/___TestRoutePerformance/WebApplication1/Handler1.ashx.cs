using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
	public class Handler1 : IHttpHandler
	{

		public void ProcessRequest(HttpContext context)
		{
			context.Response.ContentType = "text/plain";

			string id = context.Request.QueryString["id"] ?? "None";
			context.Response.Write("id = " + id);
		}

		public bool IsReusable
		{
			get
			{
				return false;
			}
		}
	}
}
