using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using UrlsAndRoutes.Infrastructure;
using URLsAndRoutes.Infrastructure;

namespace UrlsAndRoutes
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.Add(new LegacyRoute(
        "~/articles/Windows_3.1_Overview.html",
        "~/old/.NET_1.0_Class_Library"));
            routes.Add(new Route("SayHello", new CustomRouteHandler()));
         
            //routes.MapRoute("MyRoute", "{controller}/{action}/{color}/{page}");
            //routes.MapRoute("NewRoute", "App/Do{action}",
            //new { controller = "Home" });//这里用了别名

            //控制器和动作参数的名字还只能是controller,action，不然MVC框架无法识别.是自定义可选片段变量id，如果未指定值，那么用RouteData.Values根本就不存在id键。
          //  routes.MapRoute("MyRoute", "{controller}/{action}/{id}",
          //  new {  controller = "Home", action = "Index", id = UrlParameter.Optional }
          //);

             //设置true的意思是，路由会处理与现有文件匹配的URL，如果为false,就直接显示
            //现有文件的内容且不经过路由系统
            //routes.RouteExistingFiles = true;
            //routes.MapRoute("DiskFile", "Content/StaticContent.htm",
            //    new
            //    {
            //        controller = "Account",
            //        action = "LogOn",
            //    },
            //    new { customConstraint = new UserAgentConstraint("IE") }
            //    );
            //routes.IgnoreRoute("Content/{filename}.htm");

            //可变长URL路由片段和使用约束，以及自定义约束，用命名空间区分控制器
            //routes.MapRoute("MyRoute", "{controller}/{action}/{id}/{*catchall}",
            //    new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            //    new
            //    {
            //        controller = "^H.*",
            //        action = "Index|About",
            //        httpMethod = new HttpMethodConstraint("GET", "POST"),
            //        //customConstraint = new UserAgentConstraint("IE")
            //    },
            //    new[] { "URLsAndRoutes.Controllers" });

            //指定别名，入站时，URL模式中的文本量用默认值去查找控制器和动作
            //这里将controller和action参数名字改为其它的名字会找不到相应的控制器和动作而报错
            //你如果改成了其它的名字，路由系统如何知道哪个是控制器，哪个是动作呢？这里就无法使用别名
            //所以这里算作保留字
            //routes.MapRoute("ShopSchema2", "Shop/OldAction",
            //  new { controller = "Home", action = "Index" });
            //routes.MapRoute("ShopSchema", "Shop/{action}", new { controller = "Home" });

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}