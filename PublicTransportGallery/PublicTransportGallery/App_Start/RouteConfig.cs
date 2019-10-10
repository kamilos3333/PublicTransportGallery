using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PublicTransportGallery
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "voivodeshipsList",
                url: "localization",
                defaults: new { controller = "Localization", action = "VoivodeshipList" }
            );

            routes.MapRoute(
                name: "citiesList",
                url: "localization/{WOJ}",
                defaults: new { controller = "Localization", action = "CityList", WOJ = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "passengerTransportList",
                url: "localization/{WOJ}/{City}",
                defaults: new { controller = "Localization", action = "PassengerTransportList", City = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "passengerTransport",
                url: "localization/{WOJ}/{City}/{id}",
                defaults: new { controller = "PassengerTransport", action = "Details", City = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
