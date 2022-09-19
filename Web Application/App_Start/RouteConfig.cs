using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web_Application
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Order", action = "Order", id = UrlParameter.Optional }
                  //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            //(RouteTable.Routes[routes.Count - 1] as Route).DataTokens["area"] = "Common";

            routes.MapRoute("GetMenuItemListByRestaurantID",
                            "order/getmenuitemlistbyrestaurantid/",
                            new { controller = "Order", action = "GetMenuItemListByRestaurantID" },
                            new[] { "RestaurantApplication.Controllers" });

            routes.MapRoute("GetDiningTableList",
                            "order/getdiningtablelist/",
                            new { controller = "Order", action = "GetDiningTableList" },
                            new[] { "RestaurantApplication.Controllers" });

            routes.MapRoute("getTotalMenuItemPrice",
                           "order/gettotalmenuitemPrice/",
                           new { controller = "Order", action = "getTotalMenuItemPrice" },
                           new[] { "RestaurantApplication.Controllers" });

            routes.MapRoute("getTableStatus",
                          "order/gettablestatus/",
                          new { controller = "Order", action = "getTableStatus" },
                          new[] { "RestaurantApplication.Controllers" });

            routes.MapRoute("GetFilterResult",
                         "report/getfilterresult/",
                         new { controller = "Report", action = "GetFilterResult" },
                         new[] { "RestaurantApplication.Controllers" });

        }
    }
}
