using System.Web.Mvc;

namespace StudentsApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() => View();

        public ActionResult Details(string url)
        {
            ViewBag.Url = url;
            return View();
        }

        public ActionResult Create() => View();

        public ActionResult Error(string statusCode, string url)
        {
            ViewBag.StatusCode = statusCode;
            ViewBag.Url = url;
            return View();
        }
    }
}
