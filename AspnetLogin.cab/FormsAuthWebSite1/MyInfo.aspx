﻿<%@ Page Language="C#" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>查看登录人信息  - http://www.cnblogs.com/fish-li/</title>
</head>
<body>
<%--可以在 web.config 设置禁止未登录用户访问本页。--%>

<h3>这是一个【已登录】用户才能查看的页面</h3>

当前用户登录名：<span><%= Context.User.Identity.Name.HtmlEncode()%></span> <br />
IsAuthenticated: <%= Request.IsAuthenticated %> <br />
<%= Context.User.GetType().ToString() %> <br />
<%= Context.User.Identity.GetType().ToString() %> <br />


<% var user = Context.User as MyFormsPrincipal<UserInfo>;  %>
<% if( user != null ) { %>
	<%= user.UserData.ToString().HtmlEncode()%>
<% } %>



</body>
</html>
