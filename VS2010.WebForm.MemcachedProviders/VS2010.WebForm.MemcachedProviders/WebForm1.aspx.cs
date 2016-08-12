using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MemcachedProviders.Cache;
namespace VS2010.WebForm.MemcachedProviders
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            lblSessionId.Text = Session.SessionID;
            if (string.IsNullOrEmpty(TextBox1.Text) ) 
                    return;
           var flag=  DistCache.Add(null, TextBox1.Text);
           lblShowValue.Text = flag.ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            lblSessionId.Text = Session.SessionID;
            string tt = null;
            lblShowValue.Text = DistCache.Get(tt) == null ? "" : DistCache.Get(Session.SessionID).ToString();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            lblShowValue.Text = DistCache.Remove(Session.SessionID).ToString();
        }
    }
}