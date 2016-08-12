<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="VS2008.WebForm.AjaxFileUpload.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script src="jquery-1.4.4.min.js"></script>
    <script  src="mask.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div id="test" style="width:200px;height:100px; border:black 1px solid;">
</div>
<a href="javascript:void(0);" onclick="$('javascript:void(0);test').mask('DIV层遮罩')">div遮罩</a>
<a href="javascript:void(0);" onclick="$('javascript:void(0);test').unmask()">关闭div遮罩</a>
<a href="javascript:void(0);" onclick="$(document).mask('全屏遮罩').click(function(){$(document).unmask()})">全部遮罩</a>
    
    </div>
        <div>
    <div id="Div1" style="width:200px;height:100px; border:black 1px solid;">
</div>
<a href="javascript:void(0);" onclick="$('javascript:void(0);test').mask('DIV层遮罩')">div遮罩</a>
<a href="javascript:void(0);" onclick="$('javascript:void(0);test').unmask()">关闭div遮罩</a>
<a href="javascript:void(0);" onclick="$(document).mask('全屏遮罩').click(function(){$(document).unmask()})">全部遮罩</a>
    
    </div>
        <div>
    <div id="Div2" style="width:200px;height:100px; border:black 1px solid;">
</div>
<a href="javascript:void(0);" onclick="$('javascript:void(0);test').mask('DIV层遮罩')">div遮罩</a>
<a href="javascript:void(0);" onclick="$('javascript:void(0);test').unmask()">关闭div遮罩</a>
<a href="javascript:void(0);" onclick="$(document).mask('全屏遮罩').click(function(){$(document).unmask()})">全部遮罩</a>
    
    </div>
        <div>
    <div id="Div3" style="width:200px;height:100px; border:black 1px solid;">
</div>
<a href="javascript:void(0);" onclick="$('javascript:void(0);test').mask('DIV层遮罩')">div遮罩</a>
<a href="javascript:void(0);" onclick="$('javascript:void(0);test').unmask()">关闭div遮罩</a>
<a href="javascript:void(0);" onclick="$(document).mask('全屏遮罩').click(function(){$(document).unmask()})">全部遮罩</a>
    
    </div>
        <div>
    <div id="Div4" style="width:200px;height:100px; border:black 1px solid;">
</div>
<a href="javascript:void(0);" onclick="$('javascript:void(0);test').mask('DIV层遮罩')">div遮罩</a>
<a href="javascript:void(0);" onclick="$('javascript:void(0);test').unmask()">关闭div遮罩</a>
<a href="javascript:void(0);" onclick="$(document).mask('全屏遮罩').click(function(){$(document).unmask()})">全部遮罩</a>
    
    </div>
    </form>
</body>
</html>
