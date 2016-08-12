<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormField.aspx.cs" Inherits="VS2008.WebForm.Test._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head >
    <title ></title>
</head>
<body>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Image ID="Image1" runat="server" />
    <form id="form1"  method="post" >
    <table style="width: 100%;" runat="server" id="table1">
     
    </table>
    
    <a href="" runat="server" id="href1">fasdf</a>
    <div id="div1" runat="server">
    </div>
    <select  id="Select1" runat="server" multiple="true"   >
        <option>t1</option>
        <option>t2</option>
        <option>t3</option>
    </select>
    <img alt="" src="" runat="server" id="img1"/>
    <textarea id="tarea1" cols="20" rows="2" runat="server">
    </textarea>
    <input id="hfld1" type="hidden" runat="server"/>
    <input id="rad1" name="Radio1" type="radio" runat="server"/>
    <input id="chk1" type="checkbox" runat="server"/>
    <input id="pwd1" type="password" runat="server"/>
    <input id="txt1" type="text" runat="server"/>
    <input runat="server" id="ibtn1" type="button"  value="button1" />
    <button  id="btn1"  >button</button>
        <input id="Submit1" name="submit1" type="submit" value="submit" />
    </form>

</body>
</html>
