using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UtilityLib.Config;
namespace Web
{
    public partial class TestCache : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
         string aa=    ConfigHelper.GetCustomAppSettings().Settings["aa"].Value;
         this.TextBox1.Text = aa;
        }
    }
}
