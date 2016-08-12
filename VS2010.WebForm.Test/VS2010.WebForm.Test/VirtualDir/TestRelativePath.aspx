<%@ Page Title="" Language="C#" MasterPageFile="~/VirtualDir/Master/Site1.Master" AutoEventWireup="true" CodeBehind="TestRelativePath.aspx.cs" Inherits="VS2010.WebForm.Test.RelativePath.TestRelativePath" %>
<%@ Register src="UserControls/WebUserControl1.ascx" tagname="WebUserControl1" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc2:WebUserControl1 ID="WebUserControl12" runat="server" />
</asp:Content>
