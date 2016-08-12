<%@ WebHandler Language="C#" Class="TestFormsAuthenticationDecrypt" %>

using System;
using System.Collections.Generic;
using System.Web;
using System.Security.Principal;
using System.Web.Security;
using System.Diagnostics;
using System.Web.Script.Serialization;

// 测试FormsAuthentication.Encrypt的性能。

public class TestFormsAuthenticationDecrypt : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

		UserInfo userinfo = new UserInfo { UserName = "Fish Li", GroupId = 1, UserId = 1 };
		string json = (new JavaScriptSerializer()).Serialize(userinfo);

		FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
			2, "fish-li", DateTime.Now, DateTime.Now.AddDays(1), true, json);

		string encryptedTicket = FormsAuthentication.Encrypt(ticket);
		FormsAuthenticationTicket ticket2 = null;

		Stopwatch watch = Stopwatch.StartNew();
		for( int i = 0; i < 100000; i++ )
			ticket2 = FormsAuthentication.Decrypt(encryptedTicket);
		watch.Stop();
		
        context.Response.Write(watch.Elapsed.ToString());
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}