using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
	[HandleError]
	public class HomeController : Controller
	{
		public ActionResult Index(int? id)
		{
			return Content("Index id = " + (id.HasValue ? id.ToString() : "None"));
		}


		public ActionResult Test(int? id)
		{
			return Content("Test id = " + (id.HasValue ? id.ToString() : "None"));
		}

	}
}
