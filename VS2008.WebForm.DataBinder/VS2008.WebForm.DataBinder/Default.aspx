<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Demo.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body{ font-family:Arial; font-size:12px}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <table>
        <tr>
            <td style="width:20%;text-align:right">ID:</td>
            <td><asp:Label ID="ID" runat="server"></asp:Label></td>
        </tr>
         <tr>
            <td style="width:20%;text-align:right">First Name:</td>
            <td><asp:TextBox ID="FirstName" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td style="width:20%;text-align:right">Last Name:</td>
            <td><asp:TextBox ID="LastName" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td style="width:20%;text-align:right">Gender:</td>
            <td>
                <asp:RadioButtonList ID="Gender" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Male"   Value = "Male" />
                    <asp:ListItem Text="Female" Value = "Female" />
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td style="width:20%;text-align:right">Age:</td>
            <td><asp:TextBox ID="Age" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <td style="width:20%;text-align:right">Birthday:</td>
            <td><asp:TextBox ID="Birthday" runat="server" Width="313px"></asp:TextBox></td>
        </tr>
         <tr>
            <td style="width:20%;text-align:right">Is VIP:</td>
            <td><asp:CheckBox ID="IsVip" runat="server"></asp:CheckBox></td>
        </tr>
        <tr> 
            <td colspan="2" align="center">
                <asp:Button ID="ButtonBind" runat="server" Text="Bind" onclick="ButtonBind_Click" />&nbsp;&nbsp;
                <asp:Button ID="ButtonUpdate" runat="server" Text="Update" 
                    onclick="ButtonUpdate_Click"  />&nbsp;&nbsp;
                <asp:Button ID="ButtonClear" runat="server" Text="Clear" 
                    onclick="ButtonClear_Click"  />
            </td>
        </tr>
       </table>
    </div>
    </form>
</body>
</html>
