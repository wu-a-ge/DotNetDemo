<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestTreeView.aspx.cs" Inherits="VS2010.WebForm.Test.TestTreeView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script language="javascript" type="text/javascript">
// <![CDATA[

        function Button1_onclick()
        {

        }

// ]]>
    </script>
</head>
<body>
    
    <form id="form1" runat=server >
    <div>
    <asp:TreeView ID="TreeView1" runat="server" DataSourceID="XmlDataSource1">
    
    </asp:TreeView>

     <asp:XmlDataSource ID="XmlDataSource1" runat="server" 
            DataFile="~/VCubeClasses.xml"></asp:XmlDataSource>

    </div>
    </form>
</body>
</html>
