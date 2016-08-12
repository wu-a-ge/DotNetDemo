<%@ WebHandler Language="C#" Class="Login" %>

using System;
using System.Web;

public class Login : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

		string username = context.Request.Form["name"];
		string password = context.Request.Form["password"];

		if( password == "aaaa" ) {
			System.Web.Security.FormsAuthentication.SetAuthCookie(username, false);
			context.Response.Write("OK");
		}
		else {
			context.Response.Write("用户名或密码不正确。");
		}
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}