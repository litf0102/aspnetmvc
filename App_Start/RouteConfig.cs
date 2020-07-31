﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace aspnetmvc2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              "Localization", // 路由名称
              "{lang}/{controller}/{action}/{id}", // 带有参数的 URL
              new { lang ="ja-JP", controller = "Home", action = "Index", id = UrlParameter.Optional }//参数默认值
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { lang = "ja-JP", controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
