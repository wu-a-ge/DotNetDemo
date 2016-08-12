using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS2010.WebForm.ModuleAndHandler
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session[Session.SessionID] = "我是在页面中的写入的会话";
            Response.Write(Session[Session.SessionID]);
        }
    }
}
