using System;
using System.Web;

namespace VS2010.WebForm.ModuleAndHandler
{
    public class HTMLCompressModule : IHttpModule
    {
        /// <summary>
        /// 您将需要在您网站的 web.config 文件中配置此模块，
        /// 并向 IIS 注册此模块，然后才能使用。有关详细信息，
        /// 请参见下面的链接: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //此处放置清除代码。
        }

        public void Init(HttpApplication context)
        {
            // 下面是如何处理 LogRequest 事件并为其
            // 提供自定义日志记录实现的示例
            context.LogRequest += new EventHandler(OnLogRequest);
            context.PostUpdateRequestCache += new EventHandler(context_PostUpdateRequestCache);
        }

        void context_PostUpdateRequestCache(object sender, EventArgs e)
        {
            GZipEncodePage();
        }
       public void OnLogRequest(Object source, EventArgs e)
        {
            //可以在此放置自定义日志记录逻辑
        }
       public static void GZipEncodePage()
       {
           HttpResponse Response = HttpContext.Current.Response;

           if (IsGZipSupported())
           {
               string AcceptEncoding = HttpContext.Current.Request.Headers["Accept-Encoding"];
               if (AcceptEncoding.Contains("deflate"))
               {
                   Response.Filter = new System.IO.Compression.DeflateStream(Response.Filter,
                                              System.IO.Compression.CompressionMode.Compress);
                   Response.AppendHeader("Content-Encoding", "deflate");
               }
               else
               {
                   Response.Filter = new System.IO.Compression.GZipStream(Response.Filter,
                                             System.IO.Compression.CompressionMode.Compress);
                   Response.AppendHeader("Content-Encoding", "gzip");
               }
           }

           // Allow proxy servers to cache encoded and unencoded versions separately
           Response.AppendHeader("Vary", "Content-Encoding");
       }

       public static bool IsGZipSupported()
       {
           string AcceptEncoding = HttpContext.Current.Request.Headers["Accept-Encoding"];
           if (!string.IsNullOrEmpty(AcceptEncoding) &&
                (AcceptEncoding.Contains("gzip") || AcceptEncoding.Contains("deflate")))
               return true;
           return false;
       }
        #endregion

 
    }
}
