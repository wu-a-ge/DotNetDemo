<%@ WebHandler Language="C#" Class="ShowWindowsIdentity" %>

using System;
using System.Web;
using System.Security.Principal;
using System.Threading;

public class ShowWindowsIdentity : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
		// 要观察【模拟】的影响，
		// 可以启用，禁止web.config中的设置：<identity impersonate="true"/>
		
		context.Response.ContentType = "text/plain";

		context.Response.Write(Environment.UserDomainName + "\\" + Environment.UserName + "\r\n");
		
		WindowsPrincipal winPrincipal = (WindowsPrincipal)HttpContext.Current.User;
		context.Response.Write(string.Format("HttpContext.Current.User.Identity: {0}, {1}\r\n", 
				winPrincipal.Identity.AuthenticationType, winPrincipal.Identity.Name));
		
		WindowsPrincipal winPrincipal2 = (WindowsPrincipal)Thread.CurrentPrincipal;
		context.Response.Write(string.Format("Thread.CurrentPrincipal.Identity: {0}, {1}\r\n",
				winPrincipal2.Identity.AuthenticationType, winPrincipal2.Identity.Name));

		WindowsIdentity winId = WindowsIdentity.GetCurrent();
		context.Response.Write(string.Format("WindowsIdentity.GetCurrent(): {0}, {1}",
				winId.AuthenticationType, winId.Name));
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}