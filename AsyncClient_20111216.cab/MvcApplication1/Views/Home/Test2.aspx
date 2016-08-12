<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Test2</title>
</head>
<body>
	<p><% =Html.ActionLink("返回首页", "Index")%>
	</p>
    <div>
		<% =ViewData["result1"] %><br />
		<% =ViewData["result2"] %><br />
		<% =ViewData["result3"] %><br />
		<% =ViewData["time"] %>
    </div>
</body>
</html>
