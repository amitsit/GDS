using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GDS.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes(); //Enables Attribute Based Routing 

            routes.MapRoute(
            name: "Application",
            url: "{*url}",
            defaults: new { controller = "Home", action = "Index" });

            AreaRegistration.RegisterAllAreas();

        }
    }
}
