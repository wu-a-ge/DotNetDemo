<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestMemcachedProviders.aspx.cs" Inherits="VS2010.WebForm.Test.TestMemcachedProviders" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label Text="text" runat="server"  ID="lblShowNew"/>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
    </div>
    <asp:Button Text="删除" runat="server" ID="btnDelete" onclick="btnDelete_Click"/>
    </form>
</body>
</html>
