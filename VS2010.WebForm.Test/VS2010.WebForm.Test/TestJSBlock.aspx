<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestJSBlock.aspx.cs" Inherits="VS2010.WebForm.Test.TestJSBlock" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript">
        alert(location.search);
//        location.href = "/test/test.aspx";
        if (location.hash) {
            alert(location.hash);
        }
    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
  <div>
        <ul>
            <li>blogjavaspan style="color: #800000;"></li>
           <li>CSDNspan style="color: #800000;"></li>
            <li>博客园span style="color: #800000;"></li>
           <li>ABCspan style="color: #800000;"></li>
            <li>AAAspan style="color: #800000;"></li>
        </ul>    
    <span style="color: #800000;">
    <script type="text/javascript">
        // 循环5秒钟
//        var n = Number(new Date());
//    var n2 = Number(new Date());
//   while((n2 - n)<(6*1000)){
//       n2 = Number(new Date());
//     }
   </script>
   </span>
   
  <div>
        <ul>
            <li>MSNspan style="color: #800000;"></li>
            <li>GOOGLEspan style="color: #800000;"></li>
            <li>YAHOOspan style="color: #800000;"></li>
        <ul>    
    <span style="color: #800000;"></span></div></div>
    </div>
    </form>
</body>
</html>
