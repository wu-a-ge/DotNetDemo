﻿<%@ Page Language="C#" Async="true" Trace="true" AutoEventWireup="true" CodeFile="AsyncPage4.aspx.cs" Inherits="AsyncPage4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<h1>各种异步操作的混合异步页（多次异步）</h1>
    <form id="form1" runat="server">
    <div>
		<asp:Button ID="button1" runat="server" OnClick="button1_click" Text="异步调用服务" />
		<a href="<%= Request.RawUrl %>">刷新页面</a>
		<hr />
		<asp:Literal ID="labMessage" runat="server"></asp:Literal>
		<br />
		<asp:Literal ID="labMessage2" runat="server"></asp:Literal>
		<br />
		<asp:Literal ID="labMessage3" runat="server"></asp:Literal>
    </div>
    </form>
</body>
</html>
