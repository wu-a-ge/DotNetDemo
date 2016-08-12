<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestUserControl.aspx.cs" Inherits="VS2008.WebForm.Test.TestUserControl" %>

<%@ Register src="WebUserControl2.ascx" tagname="WebUserControl2" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head >
    <title></title>
</head>
<body>
  
    <form id="form2">
    <div>
    
    </div>
   <uc2:WebUserControl2 ID="WebUserControl21" runat="server" />
    
    </form>
</body>
</html>
