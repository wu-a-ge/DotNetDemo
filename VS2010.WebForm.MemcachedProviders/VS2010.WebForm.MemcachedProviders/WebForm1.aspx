<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="VS2010.WebForm.MemcachedProviders.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>--%>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="设置" onclick="Button1_Click" />
    </div>
    <p>
        <asp:Label Text="" runat="server"  ID="lblShowValue"/>
        <asp:Label Text="" runat="server"  id="lblSessionId"/>
        <asp:Button ID="Button2" runat="server" Text="获取" 
            style="height: 21px" onclick="Button2_Click" />

    </p>
    <p>
        <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="删除" />

    </p>
    </form>
</body>
</html>
