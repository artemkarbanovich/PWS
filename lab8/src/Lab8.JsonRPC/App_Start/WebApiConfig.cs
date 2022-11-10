using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace lab8.App_Start {

    public static class WebApiConfig {

        public static void Register(HttpConfiguration config) {
            var cors = new EnableCorsAttribute("http://localhost:52773,http://localhost:47203", "*", "*");
            cors.SupportsCredentials = true;
            //var cors = new EnableCorsAttribute("*", "*", "*");
            // Web API configuration and services
            config.EnableCors(cors);

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