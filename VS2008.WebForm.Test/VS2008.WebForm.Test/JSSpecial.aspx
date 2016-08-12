<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JSSpecial.aspx.cs" Inherits="VS2008.WebForm.Test.JSSpecial" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
    <script >
        function test() {
            document.getElementById("show").innerHTML = "\0";
           
          
        }
    </script>
</head>
<body>
    <form id="form1">
    <div>
        <input id="btnTest" type="button" value="button"  onclick="test();"/>
        <label id="show"></label>
    </div>
    </form>
</body>
</html>
