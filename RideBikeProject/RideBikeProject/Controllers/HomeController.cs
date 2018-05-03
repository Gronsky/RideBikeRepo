using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using RideBikeProjectBLL.DTO;
using RideBikeProjectBLL.Services;
using RideBikeProjectBLL.Interfaces;
using RideBikeProjectBLL.Infrastructure;
using RideBikeProjectWEB.Models;

namespace RideBikeProjectWEB.Controllers
{
    public class HomeController : Controller
    {
        ITeamService teamService;
        RideBikeProjectBLL.Interfaces.IUserService userService;
        public HomeController(ITeamService teamServ, RideBikeProjectBLL.Interfaces.IUserService userServ)
        {
            teamService = teamServ;
            userService = userServ;
        }
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Register()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Register(UserModel user)
        {
            return View();
        }

        public ViewResult UserTable()
        {
            IEnumerable<UserDTO> userDtos = userService.GetUsers();
            var userMapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, UserModel>()).CreateMapper();
            var users = userMapper.Map<IEnumerable<UserDTO>, List<UserModel>>(userDtos);
            return View(users);
        }

        public ActionResult CreateTeam(long userId)
        {
            try
            {
                UserDTO user = userService.GetUser(userId);
                var team = new TeamModel { ChiefId = user.Id };

                return View(team);
            }
            catch (ValidationException ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult CreateTeam(TeamModel team)
        {
            try
            {
                var teamDTO = new TeamDTO { Name = team.Name, ImageId = team.ImageId, Location = team.Location, Description = team.Description, ChiefId = team.ChiefId };
                teamService.CreateTeam(teamDTO);
                return Content("<h2>Team is created.</h2>");
            }
            catch (ValidationException ex)
            {
                ModelState.AddModelError(ex.Property, ex.Message);
            }
            return View(team);
        }









        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}