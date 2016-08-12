using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace VS2010.WebForm.ModuleAndHandler
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void Render(HtmlTextWriter writer)
        {

            StringWriter sw = new StringWriter();
            HtmlTextWriter htmlw = new HtmlTextWriter(sw);
            //把页面生成内容拿出来
            base.Render(htmlw);
            sw.WriteLine("<div>我是来自webform3，并且是通过重写render方法来处理页面输出内容</div>");
            htmlw.Flush();
            htmlw.Close();
            string pageContent = sw.ToString();

            //对内容进行修改
            //pageContent = KillTheBugAndShit(pageContent);

            Response.Write(pageContent);
        }
    }
}
