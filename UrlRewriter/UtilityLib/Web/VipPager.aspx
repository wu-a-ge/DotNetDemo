<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VipPager.aspx.cs" Inherits="Web.VipPager" %>

<%@ Register assembly="UtilityLib" namespace="UtilityLib.Controls" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    <div>
        <cc1:VIPPager ID="VIPPager2" runat="server"  CloneControlID="VIPPager1"/>
        <cc1:VIPPager ID="VIPPager1" runat="server"  />
    
    </div>
    </form>
</body>
</html>
