using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using RideBikeProjectBLL.DTO;
using RideBikeProjectBLL.Infrastructure;
using RideBikeProjectBLL.Interfaces;
using RideBikeProjectBLL.Services;
using RideBikeWeb.Models;

namespace RideBikeWeb.Controllers
{
    public class HomeController : Controller
    {
        ITeamService _teamService;
        IEventService _evntService;

        public HomeController(ITeamService teamServ, IEventService evntServ)
        {
            _teamService = teamServ;
            _evntService = evntServ;
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