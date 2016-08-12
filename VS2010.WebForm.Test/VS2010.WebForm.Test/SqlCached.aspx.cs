using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Caching;
namespace VS2010.WebForm.Test
{
    public partial class SqlCached : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                SqlCacheDependency den = new SqlCacheDependency("sqlcachetest1", "sqlcachetest");
                Cache.Insert("ik",2,den);
            }
        }
    }
}