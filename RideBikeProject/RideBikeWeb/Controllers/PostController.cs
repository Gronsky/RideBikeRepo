using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RideBikeWeb.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        public PostController()
        {

        }

        // GET: Post
        public ActionResult Post()
        {
            ViewBag.Message = "Posts";
            return View();
        }
    }
}