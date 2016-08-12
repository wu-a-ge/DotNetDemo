<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript" src="jquery-1.4.2.min.js"></script>
</head>
<body>

<div>
	ServiceUrl: <br />
	<label><input type="radio" name="url" checked="checked" />http://localhost:22132/Client/AsyncHandler.ashx</label><br />
	<label><input type="radio" name="url" />http://localhost:22132/service/DemoService/CheckUserLogin</label>
	<hr />
	
	UserName: <input type="text" id="txtName" value="fish" style="width: 300px" /><br />
	Password: <input type="text" id="txtPassword" value="http://www.cnblogs.com/fish-li" style="width: 300px" /><br />
	<input type="button" id="btnCheck" value="登录验证" />
	<span id="labwait" style="display: none">正在验证，请稍后......</span>
</div>

<script type="text/javascript">

$(function() {
	$('#btnCheck').click(function() { 
		$("#btnCheck").hide();
		$("#labwait").show();
		
		$.ajax({
			type: "POST",
			url: $(":radio").filter(":checked").parent().text(),
			data: {Username: $("#txtName").val(), Password: $("#txtPassword").val() },
			complete: function(xhr, status){
				$("#btnCheck").show(); $("#labwait").hide();
			}, 
			success: function(responseText){
				alert(responseText);
			},
			error: function (xhr, textStatus, errorThrown){
				if( typeof(errorThrown) != "undefined" )
					alert("调用服务器失败。\r\n" + errorThrown);
				else{
					var error = xhr.status + "  " + xhr.statusText;
					var start = xhr.responseText.indexOf("<title>");
					var end = xhr.responseText.indexOf("</title>");
					if( start > 0 && end > start )
						error += "\r\n\r\n" + xhr.responseText.substring(start + 7, end);
					
					alert("调用服务器失败。\r\n" + error);
				}
			}
		});
	});
});

</script>
</body>
</html>