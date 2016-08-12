using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MemcachedProviders.Cache;
namespace VS2010.WebForm.Test
{
    public partial class TestMemcachedProviders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Session["ok"] = "ff";
                //5秒后缓存失效
                //DistCache.Add("ok1", "value", new TimeSpan(0, 0, 5));
                //5秒后缓存失效
                //DistCache.Add("ok1", "value", 5000);
                //永不失效
                //DistCache.Add("ok1", "value");
                //永不失效，为什么会永不失效呢？
                DistCache.Add("ok1", "value", true);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //lblShowNew.Text = Session.IsNewSession.ToString();
            //默认Session中的键是不区分大小写的！
            //Label1.Text = Session.SessionID;
            Label1.Text = DistCache.Get<string>("ok1");

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            lblShowNew.Text = DistCache.Get<string>("ok1");
            //Session.Clear();
            //Session.Abandon();

        }

    }
}