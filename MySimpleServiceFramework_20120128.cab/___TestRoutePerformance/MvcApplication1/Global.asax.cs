using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApplication1
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"Default", // Route name
				"Home/hh/{cc}/yy{yy}/xx/{id}", // URL with parameters
				new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
			);


			for( int i = 1; i <= 100; i++ ) {
				routes.MapRoute("Route" + i.ToString(),
					"Page" + i.ToString() + "/Test/{cc}/p{page}/dd/{id}/tt{tt}/cd{cd}",
					new { controller = "Home", action = "Test" } 
					);
			}

		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			RegisterRoutes(RouteTable.Routes);

			this.BeginRequest += new EventHandler(MvcApplication_BeginRequest);
		}

		void MvcApplication_BeginRequest(object sender, EventArgs e)
		{
			
		}
	}
}