﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RideBikeWeb.Controllers
{
    public class NoAccessController : Controller
    {
        // GET: NoAccess
        public ActionResult Index()
        {
            return View();
        }
    }
}