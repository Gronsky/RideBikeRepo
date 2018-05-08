using System.Web.Mvc;

namespace RideBikeWeb.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Description of the RideBike Project.";

            return View();
        }
    }
}