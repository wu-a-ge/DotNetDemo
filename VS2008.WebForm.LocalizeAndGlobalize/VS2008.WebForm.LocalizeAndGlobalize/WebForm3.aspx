<%@ Page   Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="VS2008.WebForm.LocalizeAndGlobalize.WebForm3" meta:resourcekey="PageResource1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1"  runat="server">
    <title>Sample Page</title>
</head>
<body>

    
    <div>
        <!--只能在当前项目的App_GlobalResources文件夹中进行查找。-->
       <%-- <asp:Label ID="Label1" runat="server" 
         Text='<%$ Resources:CurrentResource, CurrentPrivacy %>'   >
         </asp:Label><br />--%>
        <br />
        <!--下面应用的本地化资源文件绑定-->
        <input id="TextBox1" type="text" runat="server"  meta:resourcekey="TextBox1Resource1"/>
        <br />
        <asp:Label ID="Label2" runat="server" ></asp:Label>
          <asp:Label ID="Label3" runat="server" ></asp:Label>
        <form id="form2"  runat="server" >     
        <asp:Button ID="Button1" runat="server" Text="Button" 
            onclick="Button1_Click1" />
    </div>
    </form>
</body>
</html>
