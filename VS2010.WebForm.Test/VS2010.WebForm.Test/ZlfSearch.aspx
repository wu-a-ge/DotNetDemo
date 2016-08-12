<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZlfSearch.aspx.cs" Inherits="VS2010.WebForm.Test.ZlfSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <%
        VS2010.WebForm.Test.ZLF.WsdlSearchable wsdl = new VS2010.WebForm.Test.ZLF.WsdlSearchable();
        var tt=  wsdl.userDataChangedNotified("", true);
        Response.Write(tt);
         %>
    </div>
    </form>
</body>
</html>
