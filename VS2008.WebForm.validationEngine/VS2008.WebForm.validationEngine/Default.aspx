<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VS2008.WebForm.validationEngine._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<link rel="Stylesheet" type="text/css" href='validationEngine.jquery.css' />
<script  src="jquery-1.4.4.js" type="text/javascript"></script>
<script src="jquery.validationEngine-cn.js" type="text/javascript"></script>
<script src="jquery.validationEngine.v2.0.注释版.min.js" type="text/javascript"></script>
<script type="text/javascript">
    function test() {
       
       $("#form1").validationEngine('validate',false,"g1");
     
    }
    
    
 
</script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <br />
    <br />
    <br />
        <asp:TextBox ID="TextBox1"  groupName="g1"  runat="server" CssClass="validate[required]"></asp:TextBox>
        <asp:TextBox ID="TextBox2"  CssClass="validate[required]" runat="server"></asp:TextBox>
        <input id="Checkbox1" type="checkbox" groupname="g1"  class="validate[required]"/>
        <input id="Radio1" type="radio" />
        <input id="Checkbox2" type="checkbox"  groupName="g1" class="validate[required]"/>
        <input id="Button1" type="button" value="button" onclick="return test();" />
    </div>
    </form>
</body>
</html>
