using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections.Specialized;
namespace VS2010.WebForm.Test
{
    public partial class TestHttpUtility : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String currurl = HttpContext.Current.Request.RawUrl;
            String querystring = null;

            // Check to make sure some query string variables
            // exist and if not add some and redirect.
            int iqs = currurl.IndexOf('?');
            if (iqs == -1)
            {
                String redirecturl = currurl + "?var1=1&var2=2+2%2f3&var1=3&var3=";
                Response.Redirect(redirecturl, true);
            }
            // If query string variables exist, put them in
            // a string.
            else if (iqs >= 0)
            {
                querystring = Request.Url.Query;
            }

            // Parse the query string variables into a NameValueCollection.
            NameValueCollection qscoll = HttpUtility.ParseQueryString(querystring);

            // Iterate through the collection.
            StringBuilder sb = new StringBuilder("<br>");
            foreach (String s in qscoll.AllKeys)
            {
                sb.Append(s + " - " + qscoll[s] + "<br>");
            }

            // Write the result to a label.
            ParseOutput.Text = sb.ToString();
            string url = "http://search. 99read. com/index. 中国aspx?book_search=all&main_str=奥迷尔";
            StringBuilder sb1 = new StringBuilder();
            sb1.AppendLine("HtmlAttributeEncode(String)=" + HttpUtility.HtmlAttributeEncode("开始 ' \" & <  > end结束"));
            sb1.AppendLine("<br/>HtmlEncode(String)=" + HttpUtility.HtmlEncode("开始 ' \" & < > end结束"));
            sb1.AppendLine("<br/>HtmlDecode(String)=" + HttpUtility.HtmlDecode(HttpUtility.HtmlEncode("开始 ' \" & < > end结束")));
            sb1.AppendLine("<br/>ParseQueryString(String)=" + HttpUtility.ParseQueryString("?book_search=all&main_str=奥迷尔"));
            sb1.AppendLine("<br/>UrlEncode(String)=" + HttpUtility.UrlEncode(url));
            //只对URL路径编码，对查询字符串根本不管
            sb1.AppendLine("<br/>UrlPathEncode(String)=" + HttpUtility.UrlPathEncode(url));
            Response.Write(sb1.ToString());
            

        }
    }
}