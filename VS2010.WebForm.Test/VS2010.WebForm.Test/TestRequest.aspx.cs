using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS2010.WebForm.Test
{
    public partial class TestRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //http://localhost:2433/TestRequest.aspx
            //输出null
            //http://localhost:2433/TestRequest.aspx?ok=
            //输出空字符串
            Response.Write(Request["ok"]);
          
        }
    }
}