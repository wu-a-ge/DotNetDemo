using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace VS2010.WebForm.ModuleAndHandler
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session[Session.SessionID]!=null)
                Response.Write(Session[Session.SessionID]);
        }

    }
}
