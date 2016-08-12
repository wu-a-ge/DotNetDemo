<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="BulletedList.aspx.cs" Inherits="VS2008.WebForm.WebControlsStudy.BulletedList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:BulletedList ID="BulletedList1" runat="server" DisplayMode="LinkButton" 
        EnableViewState="False" onclick="BulletedList1_Click" 
        ontextchanged="BulletedList1_TextChanged">
        <asp:ListItem>asdf</asp:ListItem>
        <asp:ListItem>asdf</asp:ListItem>
        <asp:ListItem>asdf</asp:ListItem>
        <asp:ListItem>asdf</asp:ListItem>
        <asp:ListItem>asdf</asp:ListItem>
    </asp:BulletedList>
</asp:Content>
