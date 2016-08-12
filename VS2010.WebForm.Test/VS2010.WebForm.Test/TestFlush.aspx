<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestFlush.aspx.cs" Inherits="VS2010.WebForm.Test.TestFlush" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     在处理比较耗时的请求的时候，我们总希望先让用户先看到部分内容，让用户知道系统正在进行处理，而不是无响应。一般大家在处理这种情况，都使用ajax，先把html输出到客户端，然后再用ajax取加载比较耗时的资源。用ajax麻烦的地方是增加了请求数，而且需要写额外的js代码、和js调用的请求接口。

      正对这种情况，还有一种处理方法，就是让response分块编码进行传输。response分块编码，可以先传输一部分不需要处理的html代码到客户端，等其他耗时代码执行完毕后再传输另外的html代码。

 

分块编码(chunked encoding)

      chunked encoding 是http1.1 才支持编码格式(当然目前没有哪个浏览器不支持1.1了)，chunked encoding 与一般的响应区别如下：

 

    正常的响应：

    HTTP/1.1 200 OK

    Cache-Control: private, max-age=60

    Content-Length: 75785

    Content-Type: text/html; charset=utf-8

    ..其他response headers

   <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 

 

    chunked encoding 响应:

    HTTP/1.1 200 OK

    Cache-Control: private, max-age=60

    Content-Length: 75785

    Content-Type: text/html; charset=utf-8

    Transfer-Encoding: chunked

    ..其他response headers

    chunk #1(这里通常是16进制的数字，标志这个块的大小)

    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"....

  

    chunk #2

    <div .....

 

    chunk #3

    ....</body></html>

 

实例(JSP)

     一个简单的页面，分为头部(header)和内容(部分)，假设内容部分需要读取数据库，花费3秒时间,然后显示csdn的logo。header部分显示cnblogs的logo。代码如下：
?
1
2
3
4
5
6
7
8
9
10
11
12
13
14
	
<body>
    <div id="head" style="border:1px solid #ccc;">
       cnblogs logo <img src="http://images.cnblogs.com/logo_small.gif" />  
    </div>
    <br />
    <div id="content" style="border:1px solid blue;">

        csdn logo<br />
        <img src="http://csdnimg.cn/www/images/csdnindex_piclogo.gif" />  
    </div>
</body>

  演示地址：http://213.186.44.204:8080/ChunkTest/nochunk.jsp (服务器比较差，请大家温柔点)

  打开这个演示地址发现很正常的页面，在3秒后才开始下载显示2个logo，资源加载瀑布图如下： 

  

 

 

  现在把代码改成如下，加上flush，让response把之前的html分块输出：

  <div id="head" style="border:1px solid #ccc;">
?
1
2
3
4
5
6
7
8
9
10
11
12
13
14
	
   cnblogs logo <img src="http://images.cnblogs.com/logo_small.gif" />  
</div>
<br />
<div id="content" style="border:1px solid blue;">

    csdn logo<br />
    <img src="http://csdnimg.cn/www/images/csdnindex_piclogo.gif" />  
</div>

   演示地址：http://213.186.44.204:8080/ChunkTest/chunk.jsp

   打开这个演示地址，是不是发现cnblogs logo先下载显示出来，3秒后csdn logo才显示，资源加载图如下：

  

   从这个图发现，cnblogs的logo在jsp页面还没执行完就开始下载了，这就是分块输出的效果。

 

监控工具：

      如何知道我们是否成功使用了chunk encoding了 ，只要用工具查看response header 中是否包含了Transfer-Encoding: chunked，如果包含了，则是分块了。但要想监控分块的详细信息，据我所知，目前只有httpwatch支持，可以查看我们到底分了多少块，但是数量好像都多显示了1个，如下图：

    
    <% Response.BufferOutput = false; Response.Flush(); %>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <%             System.Threading.Thread.Sleep(5000);
                   Response.Write("我是最后出现的"); %>
 
    </div>
    </form>
</body>
</html>
