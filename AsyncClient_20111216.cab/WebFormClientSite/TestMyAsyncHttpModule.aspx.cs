using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TestMyAsyncHttpModule : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		string result = (string)HttpContext.Current.Items[MyAsyncHttpModule.HttpContextItemsKey]
						?? "没有开启MyAsyncHttpModule，请在web.config中启用它。";
		Response.Write(result);
	}
}
