<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JSRepalce.aspx.cs" Inherits="VS2008.WebForm.Test.WebForm1" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script >
        function test() {
            var tip="body {background-image:url(\"../images/bg.jpg\")}";
            var reg = /(Url\S*?\(\S*?\")(\.\.)(.*?\"\))/i;
            var result = tip.replace(reg, function(str1, g1, g2, g3, srcstr) {
                
                return g1+"http://192.168.20.80:10001"+g3;
            });
            document.getElementById("t").innerHTML = result;
        }
    </script>
</head>
<body>
  
</body>
</html>
