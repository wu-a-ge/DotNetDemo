<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoServerForm.aspx.cs" Inherits="VS2008.WebForm.Test.NoServerForm" %>

<%@ Register Assembly="VS2008.WebForm.Test" Namespace="VS2008.WebForm.Test" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
</head>
<body>
    <form id="form1" method="post">
  
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <cc1:Button ID="Button1" runat="server" OnClick="button_click"   />
    </form>
</body>
</html>
