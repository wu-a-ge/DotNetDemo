<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdRotator.aspx.cs" Inherits="VS2008.WebForm.WebControlsStudy.AdRotator" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:AdRotator ID="AdRotator1" runat="server" 
        AdvertisementFile="~/App_Data/AdRotator.ads" KeywordFilter="AD1" onadcreated="AdRotator1_AdCreated"  
      />
   

</asp:Content>
