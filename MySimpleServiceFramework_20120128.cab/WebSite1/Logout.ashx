<%@ WebHandler Language="C#" Class="Logout" %>

using System;
using System.Web;

public class Logout : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

		System.Web.Security.FormsAuthentication.SignOut();
        context.Response.Write("Hello World");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}