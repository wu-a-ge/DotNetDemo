using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class VipPager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                VIPPager1.RecordCount = 289;
            }
        }

        protected void VIPPager1_PageChanged(object sender, EventArgs e)
        {
           
        }
    }
}
