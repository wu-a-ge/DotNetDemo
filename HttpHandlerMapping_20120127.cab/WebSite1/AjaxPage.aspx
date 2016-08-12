<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>http://www.cnblogs.com/fish-li/</title>
    <script type="text/javascript" src="js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="js/AjaxPage.js"></script>
</head>
<body>
    <p>
		请输入要计算MD5的字符串：<br />
		<input type="text" style="width: 200px" id="txtInput" value="Fish Li" />
		<input type="button" value="计算" id="btnSubmit" />
    </p>
    <hr />
    <p id="md5Result"></p>
</body>
</html>
