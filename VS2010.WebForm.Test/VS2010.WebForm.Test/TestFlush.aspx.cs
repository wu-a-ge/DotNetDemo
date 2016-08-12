using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS2010.WebForm.Test
{
    public partial class TestFlush : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.BufferOutput = false;
            //Response.Flush();
            //System.Threading.Thread.Sleep(5000);
            //Response.Write("我是最后出现的");
        }
    }
}