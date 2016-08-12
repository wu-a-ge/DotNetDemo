using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS2010.WebForm.Test
{
    public partial class UseWebService : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            VipWebService.CalisYWCD calis = new VipWebService.CalisYWCD();
            Response.Write(calis.ChargeOrder());
        }
    }
}