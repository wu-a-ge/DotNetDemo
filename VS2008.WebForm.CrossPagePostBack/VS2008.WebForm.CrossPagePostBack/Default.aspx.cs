using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS2008.WebForm.CrossPagePostBack
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (PreviousPage != null)
            {
                HiddenField hfldField = PreviousPage.FindControl("HiddenField1") as HiddenField;
                Response.Write(hfldField.Value);
            }
        }
    }
}
