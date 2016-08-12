<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default"  %>


<%@ Register Assembly="WebCustomControl" Namespace="WebCustomControl" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    <%--    <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1" 
            onitemcommand="Repeater1_ItemCommand">
        
        <ItemTemplate>
        <%# Eval("UserGroupName")%>
        </ItemTemplate>
        </asp:Repeater>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:tydataConnectionString %>" 
            SelectCommand="SELECT [UserGroupID], [UserGroupName], [DefaultGroupFlag], [ParentUserGroupID] FROM [UserGroupInfo]">
        </asp:SqlDataSource>--%>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBox1" 
        EnableClientScript="False"></asp:RequiredFieldValidator>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <cc1:ViewStateControl ID="ViewStateControl1" runat="server">
    <FaceStyle OK="true"  BackColor="White"/>
    </cc1:ViewStateControl>
  
        <br />
        <br />
        <asp:Button ID="btnSetProperty" runat="server" OnClick="btnSetProperty_Click" Text="设置控件属性" />
        &nbsp;&nbsp; &nbsp;<asp:Button ID="btnRefresh" runat="server" Text="刷新页面" OnClick="btnRefresh_Click" />&nbsp;
        <asp:Button ID="Button2" runat="server" 
        Text="Button" onclick="Button2_Click" UseSubmitBehavior="False" 
        onprerender="Button2_PreRender" />
    <br />
        <br />
        <asp:Label ID="lbDisplay" runat="server" Height="309px" Width="307px"></asp:Label></div>       
    <asp:TextBox  runat="server"></asp:TextBox>
     <asp:TextBox  runat="server"></asp:TextBox>
      <asp:TextBox  runat="server"></asp:TextBox>
       <asp:TextBox  runat="server"></asp:TextBox>
    <asp:Label   runat="server" Text="Label"></asp:Label>
    <asp:RadioButton   runat="server" />
    </form>
    
</body>
</html>
