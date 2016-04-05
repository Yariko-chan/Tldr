using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Tldr
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null, "", new
            {
                controller = "Creative",
                action = "List",
                category = 3,
                page = 1
            });
            routes.MapRoute(null, "{page}", new
            {
                controller = "Creative",
                action = "List",
                category = 3
            }, new { page = @"\d+" });
            routes.MapRoute(null, "{categoryId}", new
            {
                controller = "Creative",
                action = "List",
                page = 1
            });
            routes.MapRoute(null, "{categoryId}/{page}", new
            {
                controller = "Creative",
                action = "List"
            }, new { page = @"\d+" });
            routes.MapRoute(null, "{controller}/{action}");
        }
    }
}
