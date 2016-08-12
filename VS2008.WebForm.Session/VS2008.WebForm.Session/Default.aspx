<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VS2008.WebForm.Session._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <iframe src="WebForm1.aspx" width="150px"></iframe>
        <iframe src="WebForm2.aspx" width="150px"></iframe>
        <iframe src="WebForm3.aspx" width="150px"></iframe>
        <h1>
            <asp:Literal ID="labResult" runat="server"></asp:Literal>
        </h1>
    </div>
    </form>
</body>
</html>
