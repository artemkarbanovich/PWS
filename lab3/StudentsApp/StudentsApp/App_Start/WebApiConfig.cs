using System.Web.Http;

namespace StudentsApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "StudentsApi",
                routeTemplate: "api/{controller}.{format}/{id}",
                defaults: new { id = RouteParameter.Optional, format = "json" },
                constraints: new { format = @"(json|xml)" }
            );
        }
    }
}
