<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <p><a href="AjaxPage.aspx" target="_blank">AjaxPage.aspx</a></p>
    <p><a href="abc.test?id=1" target="_blank">abc.test</a></p>
    <p><a href="TestRemapHandler.ashx" target="_blank">TestRemapHandler.ashx</a></p>
    
    <p><a href="Handler1.ashx?id=2" target="_blank">Handler1.ashx  [IsReusable is false]</a></p>
    <p><a href="Handler2.ashx?id=3" target="_blank">Handler2.ashx  [IsReusable is true]</a></p>
    <p><a href="TestRuntimeConfig.aspx" target="_blank">TestRuntimeConfig.aspx</a></p>
    <p><a href="TestRuntimeConfig.aspx?useAppConfig=1" target="_blank">TestRuntimeConfig.aspx?useAppConfig=1</a></p>
</body>
</html>
