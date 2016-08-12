<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
</head>
<body>
<%     
dim send     
set send = Server.CreateObject("IMELS.SendMail")     
    
send.From = "test@163.com"    
send.FromName = "无问"    
send.Smtp = "smtp.163.com"    
send.Username = "用户名"    
send.Password = "密码"    
send.Subject = "asp调用C#编写的DLL发送邮件测试标题"    
send.ContentType = "html"    
send.Charset = "gb2312"    
send.Body = "asp调用C#编写的DLL发送邮件测试正文"    
send.To = "to@163.com"    
send.CC = "to@163.com"    
send.BCC = "to@163.com"    
send.Send()     
Response.Write(send.Error)     
%>   
</body>
</html>
