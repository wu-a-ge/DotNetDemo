<%@ Page Language="C#" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>FormsAuthentication DEMO  - http://www.cnblogs.com/fish-li/</title>
    <link type="text/css" rel="Stylesheet" href="css/StyleSheet.css" />
</head>
<body>
    <fieldset><legend>普通登录</legend><form action="<%= Request.RawUrl %>" method="post">
		登录名：<input type="text" name="loginName" style="width: 200px" value="Fish" />
		<input type="submit" name="NormalLogin" value="登录" />
	</form></fieldset>
     
    <fieldset><legend>包含【用户信息】的自定义登录</legend>	<form action="<%= Request.RawUrl %>" method="post">
		<table border="0">
		<tr><td>登录名：</td>
			<td><input type="text" name="loginName" style="width: 200px" value="Fish" /></td></tr>
		<tr><td>UserId：</td>
			<td><input type="text" name="UserId" style="width: 200px" value="78" /></td></tr>
		<tr><td>GroupId：</td>
			<td><input type="text" name="GroupId" style="width: 200px" />
			1表示管理员用户
			</td></tr>
		<tr><td>用户全名：</td>
			<td><input type="text" name="UserName" style="width: 200px" value="Fish Li" /></td></tr>
		</table>	
		<input type="submit" name="CustomizeLogin" value="登录" />
	</form></fieldset>
    
    <fieldset><legend>用户状态</legend><form action="<%= Request.RawUrl %>" method="post">
		<% if( Request.IsAuthenticated ) { %>
			当前用户已登录，登录名：<%= Context.User.Identity.Name.HtmlEncode() %> <br />
			
			<% var user = Context.User as MyFormsPrincipal<UserInfo>;  %>
			<% if( user != null ) { %>
				<%= user.UserData.ToString().HtmlEncode() %>
			<% } %>
			
			<input type="submit" name="Logon" value="退出" />
		<% } else { %>
			<b>当前用户还未登录。</b>
		<% } %>			
	</form></fieldset>
	
	<fieldset><legend>查看其它页面</legend>
		<p><a href="MyInfo.aspx" target="_blank">MyInfo.aspx  （用于【已登录】用户浏览）</a>	</p>
		<p><a href="Admin/Default.aspx" target="_blank">Admin/Default.aspx  （用于【管理员】用户浏览）</a></p>			
	</fieldset>
	
    <p id="hideText"><i>不应该显示的文字</i></p>
    <script type="text/javascript" src="js/JScript.js"></script>
</body>
</html>
