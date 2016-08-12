<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web._Default" %>

<%@ Register Assembly="UtilityLib.CustomControl" Namespace="UtilityLib.CustomControl"
    TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:CheckBox ID="CheckBox5" runat="server" AutoPostBack="True" />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="RequiredFieldValidator" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>--%>
        
        <input id="Submit1" type="submit" value="submit"  name="Submit1"/>
        <%--<cc1:CCheckBox ID="CCheckBox1" runat="server"  AutoPostBack="true" 
            oncheckedchanged="CCheckBox1_CheckedChanged" CausesValidation="True"/>--%>
    </div>
    </form>
</body>
</html>
