﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Project_7
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();
            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
            //var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            //config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "ActionApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                 defaults: new { id = RouteParameter.Optional }

                );
            //config.Routes.MapHttpRoute(
            // name: "ActionApi",
            // routeTemplate: "api/{controller}/{action}/{id?}",
            //  defaults: new { id = RouteParameter.Optional }

            // );
        }
    }
}
