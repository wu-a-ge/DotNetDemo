using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;
namespace VS2010.WebForm.Test
{
    public partial class RecipeDisplay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ltl1.Text = RouteTable.Routes.GetVirtualPath(Request.RequestContext,Request.RequestContext.RouteData.Values).VirtualPath;
       }
    }
}