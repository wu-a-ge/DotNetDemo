using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS2008.WebForm.Test
{
    public partial class NoServerForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void button_click(object sender, EventArgs e)
        {
            Label1.Text = "我是BUTTON按钮发出的";
        }
    }
}
