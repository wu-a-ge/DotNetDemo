using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
		HttpApplication app = HttpContext.Current.ApplicationInstance;		
		StringBuilder sb = new StringBuilder();

		foreach( string module in app.Modules.AllKeys ) 
			sb.AppendFormat(module).Append("<br />");

		Response.Write(sb.ToString());
    }
}
