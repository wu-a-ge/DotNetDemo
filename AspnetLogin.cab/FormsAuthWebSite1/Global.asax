<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs
    }


	protected void Application_AuthenticateRequest(object sender, EventArgs e)
	{
		HttpApplication app = (HttpApplication)sender;
		MyFormsPrincipal<UserInfo>.TrySetUserInfo(app.Context);		
	}	
	// 也可以参考下面的方法。
	
	//protected void FormsAuthentication_OnAuthenticate(object sender, FormsAuthenticationEventArgs e)
	//{
	//    // 这种方法将不检查ticket.Expiration是否已过期。
	//    // 如果采用上面的方法，FormsAuthenticationModule将会处理ticket过期问题。
	//    // 不过这种方法可以只调用FormsAuthentication.Decrypt()一次。

	//    e.User = MyFormsPrincipal<UserInfo>.TryParsePrincipal(e.Context.Request);
	//}

	
</script>
