using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WEB
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
/*
            routes.MapRoute(
                name: "GetByName",
                url: "{controller}/{action}/{name}",
                defaults: new { controller = "Programmer", action = "GetProgrammersByName", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "GetById",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Programmer", action = "GetProgrammerById", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Delete",
                url: "{controller}/{action}/{name}",
                defaults: new { controller = "Programmer", action = "DeleteProgrammer", id = UrlParameter.Optional }
            );
*/
        }
    }
}
