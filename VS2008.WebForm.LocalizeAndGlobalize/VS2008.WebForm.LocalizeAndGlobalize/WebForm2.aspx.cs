using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

namespace VS2008.WebForm.LocalizeAndGlobalize
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        /// <summary>
        /// 对于货币和数字，对于不同的区域性应该设置成一致
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            double myNumber = 5123456.00;
            //System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Response.Write("<b><u>zh-cn</u></b><br>");
            Response.Write(myNumber.ToString("n") + "<br>");

            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Response.Write("<b><u>en-US</u></b><br>");
            Response.Write(myNumber.ToString("n") + "<br>");

            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");
            Response.Write("<b><u>vi-VN</u></b><br>");
            Response.Write(myNumber.ToString("n") + "<br>");

            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("fi-FI");
            Response.Write("<b><u>fi-FI</u></b><br>");
            Response.Write(myNumber.ToString("n") + "<br>");

            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-CH");
            Response.Write("<b><u>fr-CH</u></b><br>");
            Response.Write(myNumber.ToString("n"));
        }
    }
}
