<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JSRegex.aspx.cs" Inherits="VS2008.WebForm.Test.JSRegex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function test() {
            var url = "("+location.protocal + ")//(" + location.host + ")/(default.aspx)?";
            var reg = new RegExp(url, "i");
            var t1 = /ab/i;
            if (t1.test("ab/"))
                alert(RegExp.$1);
        }
        test();
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
