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
using System.Web.Services;
using System.Text;

namespace RideBikeWeb.Controllers
{
    public class TeamController : Controller
    {
        ITeamService _teamService;
        public TeamController(ITeamService teamServ)
        {
            _teamService = teamServ;
        }

        public ActionResult Teams()
        {
            ViewBag.Message = "Teams";
            IEnumerable<TeamDTO> teamDtos = _teamService.GetTeams();
            var teamMapper = new MapperConfiguration(cfg => cfg.CreateMap<TeamDTO, TeamViewModels>()).CreateMapper();
            var teams = teamMapper.Map<IEnumerable<TeamDTO>, List<TeamViewModels>>(teamDtos);
            return View(teams);
        }

        [HttpPost]//Gets the todo Lists.    
        public JsonResult GetTeams(string teamName = "", int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = "ASC")
        {
            var TeamCount = _teamService.GetTeamCount();
            List<TeamDTO> teams = _teamService.GetTeams();// jtStartIndex, jtPageSize, jtSorting);
            return Json(new { Result = "OK", Records = teams, TotalRecordCount = TeamCount });
        }


        [HttpPost]
        public JsonResult CreateTeam([Bind(Exclude = "TeamId")]TeamViewModels team)
        {
            //validating Model state   
            if (ModelState.IsValid)
            {
                var teamMapper = new MapperConfiguration(cfg => cfg.CreateMap<TeamViewModels, TeamDTO>()).CreateMapper();
                var teamDTO = teamMapper.Map<TeamViewModels, TeamDTO>(team);
                _teamService.CreateTeam(teamDTO);
                // Sending Response to Ajax request  
                return Json(new { Result = "OK", Record = team });
            }
            else
            {
                // Generating error response  
                StringBuilder msg = new StringBuilder();
                var errormessage = (from item in ModelState
                                    where item.Value.Errors.Any()
                                    select item.Value.Errors[0].ErrorMessage).ToList();
                for (int i = 0; i < errormessage.Count; i++)
                {
                    msg.Append(errormessage[i].ToString());
                    msg.Append("<br />");
                } 
                return Json(new { Result = "Error occured", Message = msg.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public JsonResult EditTeam(TeamViewModels team)
        {
            if (ModelState.IsValid)
            {
                var teamMapper = new MapperConfiguration(cfg => cfg.CreateMap<TeamViewModels, TeamDTO>()).CreateMapper();
                var teamDTO = teamMapper.Map<TeamViewModels, TeamDTO>(team);
                _teamService.UpdateTeam(teamDTO);
                return Json(new { Result = "OK" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                StringBuilder msg = new StringBuilder();
                var errorList = (from item in ModelState
                                    where item.Value.Errors.Any()
                                    select item.Value.Errors[0].ErrorMessage).ToList();
                return Json(new { Result = "ERROR", Message = errorList });
            }
        }

        [HttpPost]
        public JsonResult DeleteTeam(TeamViewModels team)
        {
            var teamMapper = new MapperConfiguration(cfg => cfg.CreateMap<TeamViewModels, TeamDTO>()).CreateMapper();
            var teamDTO = teamMapper.Map<TeamViewModels, TeamDTO>(team);
            _teamService.DeleteTeam(teamDTO.Id);
            return Json(new { Result = "OK" }, JsonRequestBehavior.AllowGet);
        }



    }
}