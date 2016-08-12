#define SQL2005
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace VS2010.WebForm.TestSqlCacheDependency
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
#if SQL2005
            SqlDependency.Start(ConfigurationManager.ConnectionStrings["sqlcachetest"].ConnectionString);                         //推荐将这段代码加到Global.asax的Application_Start方法中，

#endif
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
            #if SQL2005
            SqlDependency.Stop(ConfigurationManager.ConnectionStrings["sqlcachetest"].ConnectionString);    
#endif
        }
    }
}