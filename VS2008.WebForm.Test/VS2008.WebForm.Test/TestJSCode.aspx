<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestJSCode.aspx.cs" Inherits="VS2008.WebForm.Test.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script >
//        function SSOUtil() { };
        //        alert(typeof (SSOUtil));
        function Book() {

        }
//        Book.constructor = Book;
        var b = new Book();
        alert(Book.prototype.constructor);
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
