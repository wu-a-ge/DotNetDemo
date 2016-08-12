<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompressPageState.aspx.cs" Inherits="F_Chapter6_PageStatePersister_SessionPageStatePersister" %>

<%@ Register Assembly="KingControls" Namespace="KingControls" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>视图状态存储在Session中</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>        
        <cc1:ControlStateControl ID="ControlStateControl1" runat="server" Text_NoViewState="" Text_ViewState="">
            <FaceStyle OK="False" BackColor="White" />            
        </cc1:ControlStateControl>
        <br />
        <br />
        <asp:Button ID="btnSetProperty" runat="server" OnClick="btnSetProperty_Click" Text="设置控件属性" />
        &nbsp;&nbsp; &nbsp;<asp:Button ID="btnRefresh" runat="server" Text="刷新页面" OnClick="btnRefresh_Click" />&nbsp;<br />
        <br />
        <asp:Label ID="lbDisplay" runat="server" Height="309px" Width="307px"></asp:Label></div>      
    </form>
</body>
</html>
