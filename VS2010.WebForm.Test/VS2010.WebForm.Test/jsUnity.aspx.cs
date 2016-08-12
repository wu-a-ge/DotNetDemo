using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS2010.WebForm.Test
{
    public partial class JsUnity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(Request.QueryString["ajax"]))
            //{
            //    Response.Write(GetXmlInfo());
            //    Response.ContentType = "text/xml";
            //    Response.End();
            //}
        }
        //private string GetXmlInfo()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
        //    sb.AppendLine("<results>");
        //    sb.AppendLine("<item><![CDATA[fsadfsaff&*《》《奔奔奔<&<&><a href=''>中化人民共和国</a>]]></item>");
        //    sb.AppendLine("</results>");
        //    return sb.ToString();
        //}
    }
}