﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestCookie.aspx.cs" Inherits="VS2010.WebForm.Test.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="login" onclick="Button1_Click" />

        <asp:Button ID="Button2" runat="server" Text="logout" onclick="Button2_Click" />

    </div>
    <asp:Label ID="labStatus" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
