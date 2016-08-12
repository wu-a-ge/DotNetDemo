<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SessionPageStatePersister.aspx.cs" Inherits="F_Chapter6_PageStatePersister_SessionPageStatePersister" %>

<%@ Register Assembly="WebCustomControl" Namespace="WebCustomControl" TagPrefix="cc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>视图状态存储在Session中</title>
</head>
<body>
    <form id="form1" runat="server">
           
            <cc2:ControlStateControl ID="ControlStateControl1" runat="server">
            </cc2:ControlStateControl>

        <br />
        <br />
        <asp:Button ID="btnSetProperty" runat="server" OnClick="btnSetProperty_Click" Text="设置控件属性" />
        &nbsp;&nbsp; &nbsp;<asp:Button ID="btnRefresh" runat="server" Text="刷新页面" OnClick="btnRefresh_Click" />&nbsp;<br />
        <br />
            <asp:Label ID="lbDisplay" runat="server" Text="Label" Height="309px" Width="307px"></asp:Label>
    </form>
</body>
</html>
