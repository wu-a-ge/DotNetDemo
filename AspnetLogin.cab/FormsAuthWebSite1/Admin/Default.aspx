<%@ Page Language="C#" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>管理员页面  - http://www.cnblogs.com/fish-li/</title>
</head>
<body>
<%--可以在 web.config 设置禁止非管理员用户访问本页。--%>

<h3>这是一个【管理员】用户才能查看的页面</h3>

IsAuthenticated: <%= Request.IsAuthenticated %> <br />
IsAdmin: <%= Context.User.IsInRole("Admin") %>

</body>
</html>
