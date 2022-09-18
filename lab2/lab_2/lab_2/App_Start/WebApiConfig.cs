using System.Web.Http;

namespace lab_2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "ResultApi",
                routeTemplate: "api/{controller}",
                defaults: new { controller = "Result" }
            );
        }
    }
}
