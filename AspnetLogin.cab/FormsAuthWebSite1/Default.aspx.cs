using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using FishDemoCodeLib;

public partial class _Default : System.Web.UI.Page 
{
	[SubmitMethod(AutoRedirect = true)]
	public void Logon()
	{
		FormsAuthentication.SignOut();
	}

	[SubmitMethod(AutoRedirect = true)]
	public void NormalLogin()
	{
		// -----------------------------------------------------------------
		// 注意：演示代码为了简单，这里不检查用户名与密码是否正确。
		// -----------------------------------------------------------------

		string loginName = Request.Form["loginName"];
		if( string.IsNullOrEmpty(loginName) )
			return;
		
		FormsAuthentication.SetAuthCookie(loginName, true);

		TryRedirect();
	}

	[SubmitMethod(AutoRedirect = true)]
	public void CustomizeLogin()
	{
		// -----------------------------------------------------------------
		// 注意：演示代码为了简单，这里不检查用户名与密码是否正确。
		// -----------------------------------------------------------------

		string loginName = Request.Form["loginName"];
		if( string.IsNullOrEmpty(loginName) )
			return;


		UserInfo userinfo = new UserInfo();
		int.TryParse(Request.Form["UserId"], out userinfo.UserId);
		int.TryParse(Request.Form["GroupId"], out userinfo.GroupId);
		userinfo.UserName = Request.Form["UserName"];

		// 登录状态100分钟内有效
		MyFormsPrincipal<UserInfo>.SignIn(loginName, userinfo, 100);

		TryRedirect();
	}


	private void TryRedirect()
	{
		string returnUrl = Request.QueryString["ReturnUrl"];
		if( string.IsNullOrEmpty(returnUrl) == false )
			Response.Redirect(returnUrl);
	}
}
