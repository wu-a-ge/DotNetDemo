using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace VS2010.WebForm.Test
{
    public partial class AsyncPage : System.Web.UI.Page
    {
        private WebRequest _request;

        void Page_Load(object sender, EventArgs e)
        {
            AddOnPreRenderCompleteAsync(
                new BeginEventHandler(BeginAsyncOperation),
                new EndEventHandler(EndAsyncOperation)
            );
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="cb">这个CB是系统的一个回调方法在这个回调方法中调用EndAsyncOperation </param>
        /// <param name="state"></param>
        /// <returns></returns>
        IAsyncResult BeginAsyncOperation(object sender, EventArgs e,
            AsyncCallback cb, object state)
        {
            _request = WebRequest.Create("http://msdn.microsoft.com");
            Trace.Write("BeginAsyncOperation ThreadId = " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
            return _request.BeginGetResponse(cb, state);
        }
        void EndAsyncOperation(IAsyncResult ar)
        {
            string text;
            using (WebResponse response = _request.EndGetResponse(ar))
            {
                using (StreamReader reader =
                    new StreamReader(response.GetResponseStream()))
                {
                    text = reader.ReadToEnd();
                }
            }

            Regex regex = new Regex("href\\s*=\\s*\"([^\"]*)\"",
                RegexOptions.IgnoreCase);
            MatchCollection matches = regex.Matches(text);

            StringBuilder builder = new StringBuilder(1024);
            foreach (Match match in matches)
            {
                builder.Append(match.Groups[1]);
                builder.Append("<br/>");
            }

            Output.Text = builder.ToString();
            Trace.Write("EndAsyncOperation ThreadId = " + System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
        }
    }
}