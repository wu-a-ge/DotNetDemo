<%@ WebHandler Language="C#" Class="MyService" %>

using System;
using System.Web;
using MySimpleServiceFramework;

public class MyService : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
		NamesPair pair = new NamesPair();
		pair.ServiceName = context.Request.QueryString["sc"];
		pair.MethodName = context.Request.QueryString["op"];

		ServiceExecutor.ProcessRequest(context, pair);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }
}