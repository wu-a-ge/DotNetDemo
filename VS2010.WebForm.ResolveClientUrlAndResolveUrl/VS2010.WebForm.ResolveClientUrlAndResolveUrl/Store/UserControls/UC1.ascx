<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC1.ascx.cs" Inherits="VS2010.WebForm.ResolveClientUrlAndResolveUrl.Store.UserControls.UC1" %>
<!--绝对路径 -->
<div>ResolveUrl:<% Response.Write(ResolveUrl("/Store/UserControls/Images/Image1.jpg")); %></div>
<div>ResolveClientUrl:<% Response.Write(ResolveClientUrl("/Store/UserControls/Images/Image1.jpg")); %></div>
<div>ResolveUrl:<% Response.Write(ResolveUrl("/Images/Image1.jpg")); %></div>
<div>ResolveClientUrl:<% Response.Write(ResolveClientUrl("/Images/Image1.jpg")); %></div>
<!--
返回结果：
ResolveUrl:/Store/UserControls/Images/Image1.jpg
ResolveClientUrl:/Store/UserControls/Images/Image1.jpg
ResolveUrl:/Images/Image1.jpg
ResolveClientUrl:/Images/Image1.jpg
分析：全部返回绝对路径，将当前程序放在虚拟目录下，也是返回相同的路径
-->
==========================================================
<!--相对路径 -->
<div>ResolveUrl:<% Response.Write(ResolveUrl("Store/UserControls/Images/Image1.jpg")); %></div>
<div>ResolveClientUrl:<% Response.Write(ResolveClientUrl("Store/UserControls/Images/Image1.jpg")); %></div>
<div>ResolveUrl:<% Response.Write(ResolveUrl("Images/Image1.jpg")); %></div>
<div>ResolveClientUrl:<% Response.Write(ResolveClientUrl("Images/Image1.jpg")); %></div>
<div>ResolveUrl:<% Response.Write(ResolveUrl("Image1.jpg")); %></div>
<div>ResolveClientUrl:<% Response.Write(ResolveClientUrl("Image1.jpg")); %></div>
<div>ResolveUrl:<% Response.Write(ResolveUrl("../../Images1/Image1.jpg")); %></div>
<div>ResolveClientUrl:<% Response.Write(ResolveClientUrl("../../Images1/Image1.jpg")); %></div>
<div>ResolveUrl:<% Response.Write(ResolveUrl("../Images1/Image1.jpg")); %></div>
<div>ResolveClientUrl:<% Response.Write(ResolveClientUrl("../Images1/Image1.jpg")); %></div>
<!--
ResolveUrl:/Store/UserControls/Store/UserControls/Images/Image1.jpg
ResolveClientUrl:UserControls/Store/UserControls/Images/Image1.jpg
ResolveUrl:/Store/UserControls/Images/Image1.jpg
ResolveClientUrl:UserControls/Images/Image1.jpg
ResolveUrl:/Store/UserControls/Image1.jpg
ResolveClientUrl:UserControls/Image1.jpg
ResolveUrl:/Images1/Image1.jpg
ResolveClientUrl:../Images1/Image1.jpg
ResolveUrl:/Store/Images1/Image1.jpg
ResolveClientUrl:Images1/Image1.jpg
分析：ResolveUrl：返回路径==针对没有加前导.和..路径，从根算起当前控件或页面所在的目录路径+传递的路径，返回一个绝对路径 
ResolveClientUrl：返回路径=针对没有加前导.和..路径，当前控件或页面所在的目录+传递的路径，而且返回的是一个相对当前控件或目录所在文件夹的相对路径
将当前程序放入虚拟目录返回的路径是加上虚拟目录的路径的：
ResolveUrl:/test/Store/UserControls/Store/UserControls/Images/Image1.jpg
ResolveClientUrl:UserControls/Store/UserControls/Images/Image1.jpg
ResolveUrl:/test/Store/UserControls/Images/Image1.jpg
ResolveClientUrl:UserControls/Images/Image1.jpg
ResolveUrl:/test/Store/UserControls/Image1.jpg
ResolveClientUrl:UserControls/Image1.jpg
ResolveUrl:/test/Images1/Image1.jpg
ResolveClientUrl:../Images1/Image1.jpg
ResolveUrl:/test/Store/Images1/Image1.jpg
ResolveClientUrl:Images1/Image1.jpg
-->
==========================================================
<!--虚拟路径 -->
<div>ResolveUrl:<% Response.Write(ResolveUrl("~/Store/UserControls/Images/Image1.jpg")); %></div>
<div>ResolveClientUrl:<% Response.Write(ResolveClientUrl("~/Store/UserControls/Images/Image1.jpg")); %></div>
<div>ResolveUrl:<% Response.Write(ResolveUrl("~/Images/Image1.jpg")); %></div>
<div>ResolveClientUrl:<% Response.Write(ResolveClientUrl("~/Images/Image1.jpg")); %></div>
<div>ResolveUrl:<% Response.Write(ResolveUrl("~/Image1.jpg")); %></div>
<div>ResolveClientUrl:<% Response.Write(ResolveClientUrl("~/Image1.jpg")); %></div>
<!--
ResolveUrl:/Store/UserControls/Images/Image1.jpg
ResolveClientUrl:UserControls/Images/Image1.jpg
ResolveUrl:/Images/Image1.jpg
ResolveClientUrl:../Images/Image1.jpg
ResolveUrl:/Image1.jpg
ResolveClientUrl:../Image1.jpg
分析：ResolveUrl：返回路径=传递路径，绝对路径
ResolveClientUrl：返回路径=相对路径
将当前程序放入虚拟目录返回的路径如下：
ResolveUrl:/Store/UserControls/Images/Image1.jpg
ResolveClientUrl:../../Store/UserControls/Images/Image1.jpg
ResolveUrl:/Images/Image1.jpg
ResolveClientUrl:../../Images/Image1.jpg
ResolveUrl:/Image1.jpg
ResolveClientUrl:../../Image1.jpg
分析：ResolveUrl还是返回绝对路径，不包含虚拟目录路径
从上可以看出ResolveUrl传递的路径前面加不加~符号返回的都是绝对路径 
-->
 <!--
 总结：不用ResolveClientUrl，尽量用ResolveUrl返回绝对路径
 -->