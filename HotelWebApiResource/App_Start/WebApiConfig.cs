using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Newtonsoft.Json;

namespace HotelWebApiResource
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // well formatted ISO 8601 dates such as 2015-01-19T23:08:57.3010754Z
            //var jsonFormatter = config.Formatters.JsonFormatter;
            //jsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Unspecified;
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
