<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VS2008.WebForm.AjaxFileUpload._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head >
<link type="text/css"  href="ajaxfileupload.css"  rel="Stylesheet"/>
    <script src="jquery-1.4.4.min.js"></script>
    <script src="ajaxfileuploadV2.1.js"></script>
    <script  type="text/javascript">

        function ajaxFileUpload() {
            $("#loading")
		.ajaxStart(function() {
		    $(this).show();
		})
		.ajaxComplete(function() {
		    $(this).hide();
		});

		$.ajaxFileUpload
		(
			{
			    url: 'Handler1.ashx',
			    secureuri: false,
			    fileElementId: 'fileToUpload',
			    dataType: 'xml',
			    success: function(data, status) {
			        if (typeof (data.error) != 'undefined') {
			            if (data.error != '') {
			                alert(data.error);
			            } else {
			                alert(data.msg);
			            }
			        }
			        else
			       alert($("p", data).text());

			    },
			    error: function(data, status, e) {
			        alert(e);
			    }
			}
		)

            return false;

        }
    </script>
    
    <title></title>
</head>
<body>
<form    id="form1"  runat="server" >
<input id="fileToUpload" type="file" size="45"  class="input"/>
<button class="button" id="buttonUpload" onclick="return ajaxFileUpload();">Upload</button>
</form>
<%--<div id="wrapper">
    <div id="content">
    	<h1>Ajax File Upload Demo</h1>
    	<p>Jquery File Upload Plugin  - upload your files with only one input field</p>
				<p>
				need any Web-based Information System?<br> Please <a href="http://www.phpletter.com/">Contact Us</a><br>
				We are specialized in <br>
				<ul>
					<li>Website Design</li>
					<li>Survey System Creation</li>
					<li>E-commerce Site Development</li>
				</ul>    	
		<img id="loading" src="loading.gif" style="display:none;">
		<form name="form"  runat="server" >
		<table cellpadding="0" cellspacing="0" class="tableForm">

		<thead>
			<tr>
				<th>Please select a file and click Upload button</th>
			</tr>
		</thead>
		<tbody>	
			<tr>
				<td><input id="fileToUpload" type="file" size="45" name="fileToUpload" class="input"></td>			</tr>

		</tbody>
			<tfoot>
				<tr>
					<td><button class="button" id="buttonUpload" onclick="return ajaxFileUpload();">Upload</button></td>
				</tr>
			</tfoot>
	
	</table>
		</form>    	
    </div>
    </div>--%>
</body>
</html>
