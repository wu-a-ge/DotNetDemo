<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VS2008.WebForm.WebControlsStudy._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head  >
    <title></title>
    

</head>
<body>
    <form id="form1" >
    <div>
        <asp:AdRotator ID="AdRotator1" runat="server" 
            AdvertisementFile="~/App_Data/AdRotator.ads"  />
       
       
        <asp:Image ID="Image1" runat="server"  />
         
        <asp:ImageMap ID="ImageMap1" runat="server">
        
        </asp:ImageMap>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        
        <asp:HyperLink ID="HyperLink1" runat="server"   >HyperLink</asp:HyperLink>
        <asp:Panel ID="Panel1" runat="server"  Enabled="false"   >
        </asp:Panel>
          <asp:PlaceHolder ID="PlaceHolder1" runat="server" >
          PlaceHolder
          </asp:PlaceHolder>
        <asp:Table ID="Table1" runat="server">
        </asp:Table>
 
        <asp:Xml ID="Xml1" runat="server" ></asp:Xml>
       
        <input id="Submit1" type="submit" value="submit" />
    </div>
    </form>
</body>
</html>
