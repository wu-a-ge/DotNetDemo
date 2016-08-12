using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace VS2008.WebForm.LocalizeAndGlobalize
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        /// <summary>
        /// 对于日期，应该对于所有的区域性表示成一样的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dt = new DateTime(2006, 8, 11, 11, 12, 10, 10);
            //System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("zh-cn");
            Response.Write("<b><u>zh-CN</u></b><br>");
            Response.Write(dt.ToString() + "<br>");

            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Response.Write("<b><u>en-US</u></b><br>");
            Response.Write(dt.ToString() + "<br>");

            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-ru");
            Response.Write("<b><u>ru-RU</u></b><br>");
            Response.Write(dt.ToString() + "<br>");

            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("fi-FI");
            Response.Write("<b><u>fi-FI</u></b><br>");
            Response.Write(dt.ToString() + "<br>");

            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("th-TH");
            Response.Write("<b><u>th-TH</u></b><br>");
            Response.Write(dt.ToString());
        }
    }
}
