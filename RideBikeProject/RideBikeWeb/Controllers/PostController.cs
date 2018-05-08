using System.Web.Mvc;

namespace RideBikeWeb.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Post()
        {
            ViewBag.Message = "Posts";
            return View();
        }
    }
}