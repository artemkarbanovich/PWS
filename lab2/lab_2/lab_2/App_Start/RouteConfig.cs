using System.Web.Mvc;
using System.Web.Routing;

namespace lab_2
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes) => routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    }
}
