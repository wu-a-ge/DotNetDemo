<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestJsonToRepeater.aspx.cs" Inherits="VS2010.WebForm.Test.TestJsonToRepeater" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1">
    
    <asp:Repeater runat="server" ID="repeater1">
     <ItemTemplate>
       <label><%# Eval("[\"Name\"]") %></label>
       <label><%# Eval("[\"Price\"]")%></label>
     </ItemTemplate>

    </asp:Repeater>
<%--    <asp:GridView ID="GridView1" runat="server">
         <EmptyDataTemplate>
            <%#  Container %>
         </EmptyDataTemplate>
         <Columns>
         
         <asp:TemplateField>
        
         <EditItemTemplate>
           <%#  Container %>
         </EditItemTemplate>
         <ItemTemplate>
          <%#  Container %>
         </ItemTemplate>
         </asp:TemplateField>
         </Columns>
         </asp:GridView>--%>
    </form>
</body>

</html>
