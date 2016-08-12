MSDN解释：
1.ResolveUrl:
如果 relativeUrl 参数包含绝对 URL，则该 URL 原样返回。 如果 relativeUrl 参数包含相对 URL，则该 URL 将更改为与当前请求路径相符的相对 URL，这样浏览器便能够解析该 URL。

例如，考虑以下方案：

    客户端已请求了一个 ASP.NET 页，该页含有一个用户控件，该用户控件有一个关联的图像。

    ASP.NET 页位于 /Store/page1.aspx。

    用户控件位于 /Store/UserControls/UC1.ascx。

    图像文件位于 /UserControls/Images/Image1.jpg。

如果用户控件将图像的相对路径（即 /Store/UserControls/Images/Image1.jpg）传递给 ResolveUrl 方法，此方法将返回值 /Images/Image1.jpg。?这说法有错吧？传入的是绝对路径，返回绝对路径 
此方法使用 TemplateSourceDirectory 属性解析为绝对 URL。 返回的 URL 适用于客户端。 

2.ResolveClientUrl:

使用 ResolveClientUrl 方法返回 URL 字符串，该字符串适合由客户端用来访问 Web 服务器上的资源，如图像文件、指向其他页的链接等。
注意注意

此方法返回的 URL 是相对于包含源文件（在该源文件中对控件进行实例化）的文件夹。 继承此属性的控件（例如 UserControl 和 MasterPage）将返回相对于该控件的完全限定的 URL。 
其它说明：查看Wiz中的两篇文章
《ResolveClientUrl与ResolveUrl》
《ResolveUrl() 和 ResolveClientUrl()》