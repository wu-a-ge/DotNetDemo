using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Web;
using System.Web.Compilation;
using System.Web.UI;
namespace VS2010.WebForm.Test
{
    public class RecipeRouteHandler : IRouteHandler
    {
        public RecipeRouteHandler(string virtualPath)
        {
            _virtualPath = virtualPath;
        }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            var display = BuildManager.CreateInstanceFromVirtualPath(
                            _virtualPath, typeof(Page)) as IRecipeDisplay;

            display.RecipeName = requestContext.RouteData.Values["name"] as string;
            return display as IHttpHandler;
        }

        string _virtualPath;
    }
}
