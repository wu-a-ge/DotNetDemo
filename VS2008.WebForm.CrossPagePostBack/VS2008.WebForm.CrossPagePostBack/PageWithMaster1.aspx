<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PageWithMaster1.aspx.cs" Inherits="VS2008.WebForm.CrossPagePostBack.PageWithMaster1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="HiddenField1" runat="server"  Value="我来自PageWithMaster1"/>
    <asp:Button ID="Button1" runat="server" Text="Button" 
        PostBackUrl="~/PageWithMaster2.aspx" />
</asp:Content>
