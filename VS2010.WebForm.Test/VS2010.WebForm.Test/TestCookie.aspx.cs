using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace VS2010.WebForm.Test
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            this.labStatus.Text = (Request.IsAuthenticated ? "已登录"+Context.User.Identity.Name : "未登录"+FormsAuthentication.FormsCookieName);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //内部使用了下面的票据代码
            //FormsAuthentication.SetAuthCookie("xiaofu", false);
            // 下面的代码和上面的代码在作用上是等效的。
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                2, "xiaofu", DateTime.Now, DateTime.Now.AddDays(30d), false, "你好");
            string str = FormsAuthentication.Encrypt(ticket);

            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, str);
            Response.Cookies.Add(cookie);
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        { 
            FormsAuthentication.SignOut();
           
        }
    }
}