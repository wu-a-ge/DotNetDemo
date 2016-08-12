using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VS2008.WebForm.Session
{
    public partial class _Default : System.Web.UI.Page
    {
        private static int count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            // 因为前面的页面都没有使用Session，所以就在这里简单地使用一下了。
            Session["Key1"] = System.Threading.Interlocked.Increment(ref count);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            this.labResult.Text = Session["Key1"].ToString();
        }

    }
}
