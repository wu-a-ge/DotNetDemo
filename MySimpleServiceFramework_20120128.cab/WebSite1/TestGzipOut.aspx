<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestGzipOut.aspx.cs" Inherits="TestGzipOut" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

	<h1>推荐阅读</h1>
	
	<div class="postTitle">
		<a id="homepage1_HomePageDays_ctl03_DayList_TitleUrl_0" class="postTitle2" 
			href="http://www.cnblogs.com/fish-li/archive/2011/05/02/2034354.html" 
			target="_blank">[置顶]Asp.net MVC 框架，我也来山寨一下</a>
	</div>
	<div class="postCon">
		<div class="c_b_p_desc">
			摘要: 继本人的【Ajax服务端框架】完成后，也花了些时间学习了一Asp.net 
			MVC，感觉我的Ajax框架也能玩MVC开发，于是乎，在又加了点功能后，现在也能像Asp.net 
			MVC那样写aspx和ascx了。先来点代码来看看，具体的页面呈现效果请参考：通用数据访问层及Ajax服务端框架的综合示例，展示与下载&lt;%@ Page 
			Title=&quot;商品管理&quot; Language=&quot;C#&quot; MasterPageFile=&quot;~/MasterPage.master&quot; 
			Inherits=&quot;FishWebLib.Mvc.MyPageView&amp;<a class="c_b_p_desc_readmore" 
				href="http://www.cnblogs.com/fish-li/archive/2011/05/02/2034354.html">阅读全文</a></div>
	</div>
	<div class="postDesc">
		posted @ 2011-05-02 21:26 Fish Li 阅读(2784) 评论(3)
	</div>
	
	<p></p>
	
	<div class="postTitle">
		<a id="homepage1_HomePageDays_ctl03_DayList_TitleUrl_1" class="postTitle2" 
			href="http://www.cnblogs.com/fish-li/archive/2011/03/28/1998104.html" 
			target="_blank">[置顶]晒晒我的通用数据访问层</a>
	</div>
	<div class="postCon">
		<div class="c_b_p_desc">
			摘要: 
			今天来晒晒我的通用数据访问层。写了很多年的数据库项目，数据访问嘛，一直是用业务实体+存储过程的方式，因此经常会写很多调用存储过程的代码。这些代码用Ado.net如何写，我想大家应该都知道：创建Connection, 
			创建Command, 
			给命令参数一个一个赋值，然后调用，调用完成后，如果有输出参数，则要读出来，如果有结果集，则要将结果集转换成自己的实体列表，这个过程也是非常机械化的。总之，调用任何...<a 
				class="c_b_p_desc_readmore" 
				href="http://www.cnblogs.com/fish-li/archive/2011/03/28/1998104.html">阅读全文</a></div>
	</div>
	
	<p></p>
	

	<div class="postTitle">
		<a id="homepage1_HomePageDays_DaysList_DayItem_13_DayList_13_TitleUrl_1" 
			class="postTitle2" 
			href="http://www.cnblogs.com/fish-li/archive/2011/03/12/1982434.html" 
			target="_blank">晒晒我的Ajax服务端框架</a>
	</div>
	<div class="postCon">
		<div class="c_b_p_desc">
			摘要: 
			今天晒晒我的Ajax服务端框架。自从接触JQuery-EasyUI后，本人对Ajax越来越感兴趣了。也慢慢的把UI开发的重心从服务器端移到客户端来了。一般说来，在Asp.net的环境中实现Ajax，要么是使用Asp.net 
			AJAX框架，要么就要自己写些ashx来直接与客户端交互，当然还有第三方的框架可供选择。由于对Asp.net 
			AJAX这个东西嘛，实在没啥兴趣。虽然它可以帮你为一些WebService生成JS的代理类。但是在客户端的JQuery却不能发挥它的强大功能。随着ashx处理器越写越多，发现几乎做的事情是一样的：从请求中读取参数，调用C#方法，将结果写入响应流。由是乎就来有了个想法<a 
				class="c_b_p_desc_readmore" 
				href="http://www.cnblogs.com/fish-li/archive/2011/03/12/1982434.html">阅读全文</a></div>
	</div>
	

<p><b style="color: #f00">请打开Fiddler看一下这个页面是否启用了GZIP压缩。</b></p>
</body>
</html>
