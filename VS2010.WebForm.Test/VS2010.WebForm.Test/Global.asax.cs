﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;

namespace VS2010.WebForm.Test
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            
            //RouteTable.Routes.Add("Recipe",
            //    new Route("recipe/{name}",
            //    new PageRouteHandler("~/RecipeDisplay.aspx")));
        }

        //protected void Session_OnStart(object sender, EventArgs e)
        //{

        //}
        //protected void Session_End(object sender, EventArgs e)
        //{

        //}
        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }


        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}