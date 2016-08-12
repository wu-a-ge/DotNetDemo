<%@ Page   Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VS2008.WebForm.CustomExpressionBuilder._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1">
    <div>
    <a href="<%$Xml:test,test1 %>" runat="server">配置链接</a>
            <asp:Label ID="Label1" runat="server" Text="<%$Xml:test,test1 %>"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="<%$Xml:test,test2 %>"></asp:Label>
        <br />
    </div>
    </form>
</body>
</html>
