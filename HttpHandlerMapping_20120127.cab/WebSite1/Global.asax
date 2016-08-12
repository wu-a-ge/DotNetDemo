<%@ Application Language="C#" %>

<script runat="server">

	//protected void Application_PostResolveRequestCache(object sender, EventArgs e)
	//{
	//    HttpApplication app = (HttpApplication)sender;
	//    if( app.Request.FilePath.EndsWith(".ashx", StringComparison.OrdinalIgnoreCase) )
	//        app.Context.RemapHandler(new MyTestHandler());
	//}
	
	// 或者是下面这样

	protected void Application_PostResolveRequestCache(object sender, EventArgs e)
	{
		HttpApplication app = (HttpApplication)sender;
		if( app.Request.FilePath.EndsWith("/TestRemapHandler.ashx", StringComparison.OrdinalIgnoreCase) )
			app.Context.RemapHandler(new MyTestHandler());
	}
	
</script>
