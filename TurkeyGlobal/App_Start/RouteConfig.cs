using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TurkeyGlobal
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Buyer",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Buyer", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Seller",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Seller", action = "Index", id = UrlParameter.Optional }
           );
            routes.MapRoute(
              name: "User",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "User", action = "Index", id = UrlParameter.Optional }
          );
        }
    }
}
