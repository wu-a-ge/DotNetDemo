<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Index</title>
</head>
<body>
    <p>
		<% =Html.ActionLink("一次异步任务", "Test1") %>
    </p>
    <p>
		<% =Html.ActionLink("多次异步任务", "Test2") %>
    </p>
</body>
</html>
