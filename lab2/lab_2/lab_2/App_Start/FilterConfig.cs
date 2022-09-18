using System.Web.Mvc;

namespace lab_2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) => filters.Add(new HandleErrorAttribute());
    }
}
