using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Text;
using System.Net;
using System.IO;

namespace VS2010.WebForm.Test
{
    public partial class AsyncPageTask : System.Web.UI.Page
    {
        private WebRequest _request;

        protected void Page_Load(object sender, EventArgs e)
        {
            PageAsyncTask task = new PageAsyncTask(
                new BeginEventHandler(BeginAsyncOperation),
                new EndEventHandler(EndAsyncOperation),
                new EndEventHandler(TimeoutAsyncOperation),
                null
            );
            RegisterAsyncTask(task);
        }

        IAsyncResult BeginAsyncOperation(object sender, EventArgs e,
            AsyncCallback cb, object state)
        {
            _request = WebRequest.Create("http://msdn.microsoft.com");
            System.Threading.Thread.Sleep(5000);
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
        }

        void TimeoutAsyncOperation(IAsyncResult ar)
        {
            Output.Text = "Data temporarily unavailable";
        }
    }
}