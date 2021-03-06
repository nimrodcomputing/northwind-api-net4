﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace Northwind.Api
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Images", "api/{action}/{id}/image", new {controller = "Images"});

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
