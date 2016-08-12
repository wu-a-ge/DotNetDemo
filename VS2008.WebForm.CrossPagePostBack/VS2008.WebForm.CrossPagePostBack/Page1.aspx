<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page1.aspx.cs" Inherits="VS2008.WebForm.CrossPagePostBack.Page1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <div>
        <asp:HiddenField ID="HiddenField1" runat="server"  Value="我来自Page1"/>
    </div>
    <asp:Button ID="Button1" runat="server" Text="Button" 
        PostBackUrl="~/Default.aspx" />
          </asp:Panel>
    </form>
  

</body>
</html>
