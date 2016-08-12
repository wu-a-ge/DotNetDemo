<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="VS2008.WebForm.Test.WebForm3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" onload="GridView1_Load" 
            onprerender="GridView1_PreRender">
           <EmptyDataTemplate>
            emtpy
           </EmptyDataTemplate>
 
           <Columns>
           <asp:TemplateField>
            <HeaderTemplate>塔顶</HeaderTemplate>
            <FooterTemplate>远东地区魂牵梦萦</FooterTemplate>
           </asp:TemplateField>
           </Columns>
        </asp:GridView>
    </div>
   
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
   
    </form>
</body>
</html>
