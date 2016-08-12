using System;
using System.Web;
using System.IO;
using System.Text;

namespace VS2010.WebForm.ModuleAndHandler
{
    public class ResponseFilterModule : IHttpModule
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
           
            context.PostUpdateRequestCache += new EventHandler(context_PostUpdateRequestCache);
        }

        void context_PostUpdateRequestCache(object sender, EventArgs e)
        {
            ResponseFilterStream filter = new ResponseFilterStream(HttpContext.Current.Response.Filter);
            filter.TransformStream += filter_TransformStream;
            HttpContext.Current.Response.Filter = filter;  
        }
        MemoryStream filter_TransformStream(MemoryStream ms)
        {
            Encoding encoding = HttpContext.Current.Response.ContentEncoding;

            string output = encoding.GetString(ms.ToArray());

            output = FixPaths(output);

            ms = new MemoryStream(output.Length);

            byte[] buffer = encoding.GetBytes(output);
            ms.Write(buffer, 0, buffer.Length);

            return ms;
        }
        private string FixPaths(string output)
        {
            string path = HttpContext.Current.Request.ApplicationPath;
            // override root path wonkiness
            if (path == "/")
                path = "";
            output = output.Replace("\"~/", "\"" + path + "/").Replace("'~/", "'" + path + "/");
            return output;
        }
        #endregion

      

    }

}
