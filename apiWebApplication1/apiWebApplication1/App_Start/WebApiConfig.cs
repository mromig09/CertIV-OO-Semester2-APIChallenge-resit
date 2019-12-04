using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace apiWebApplication1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "RoomsUsed",
                routeTemplate: "api/Rooms/Used",
                defaults: new { controller = "RoomsUsed", action = "Get", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "RoomsUnsed",
                routeTemplate: "api/Rooms/Unused",
                defaults: new { controller = "RoomsNotUsed", action = "Get", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Computers",
                routeTemplate: "api/Rooms/Computers",
                defaults: new { controller = "Computer", action = "Get", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Class",
                routeTemplate: "api/Class/{classCode}",
                defaults: new { controller = "Class", action = "Get", id = RouteParameter.Optional }
            );


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
