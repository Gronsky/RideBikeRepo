using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using RideBikeProjectBLL.Interfaces;
using System.Text;
using RideBike.Infrastructure.Models;
using RideBike.Infrastructure.DTO;
using System.IO;

namespace RideBikeWeb.Controllers
{
    [Authorize]
    public class TeamController : Controller
    {
        ITeamService _teamService;
        public TeamController(ITeamService teamServ)
        {
            _teamService = teamServ;
        }

        // GET: Profile
        public ActionResult Team(long Id)
        {
            var teamDto = _teamService.GetTeam(Id);
            var model = Mapper.Map<TeamDTO, TeamViewModels>(teamDto);
            return View(model);
        }

        public ActionResult Update(long Id)
        {
            var teamDto = _teamService.GetTeam(Id);
            var model = Mapper.Map<TeamDTO, TeamViewModels>(teamDto);
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(TeamViewModels model)
        {
            var teamDto = Mapper.Map<TeamViewModels, TeamDTO>(model);
            _teamService.UpdateTeam(teamDto);
            return RedirectToAction("Team", "Team", new { Id = model.Id });
        }

        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file, long teamId)
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = Path.Combine(Server.MapPath("~/Content/Img/teams"), pic);
                file.SaveAs(path);

                // save the image path to the database [Image].[Source]
                string imagePath = String.Concat("../../Content/Img/teams/", pic);
                _teamService.ChangeImage(imagePath, teamId);
            }

            return RedirectToAction("Team", "Team", new { Id = teamId });
        }

        //-----------------------------------------------------------------------------------------------
        public ActionResult Teams()
        {
            ViewBag.Message = "Teams";
            IEnumerable<TeamDTO> teamDtos = _teamService.GetTeams();
            var teamMapper = new MapperConfiguration(cfg => cfg.CreateMap<TeamDTO, TeamViewModels>()).CreateMapper();
            var teams = teamMapper.Map<IEnumerable<TeamDTO>, List<TeamViewModels>>(teamDtos);
            return View(teams);
        }

        [HttpPost]//Gets the todo Lists.    
        public JsonResult GetTeams( int jtStartIndex = 0, int jtPageSize = 10 )
        {
            List<TeamDTO> teams = _teamService.GetTeams( jtStartIndex, jtPageSize );
            var TeamCount = _teamService.GetTeamCount();
            return Json(new { Result = "OK", Records = teams, TotalRecordCount = TeamCount });
        }

        public ActionResult Create(long Id)
        {
            var model = new TeamViewModels() { ChiefId = Id };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(TeamViewModels model)
        {
            var teamDTO = Mapper.Map<TeamViewModels, TeamDTO>(model);
            _teamService.CreateTeam(teamDTO);
           // var teamDto = _teamService.GetTeam(x => x.ChiefId == model.ChiefId);
            return RedirectToAction("Team", "Team", new { Id = 1});
        }

        [HttpPost]
        public JsonResult CreateTeam([Bind(Exclude = "TeamId")]TeamViewModels team)
        {
            if (ModelState.IsValid)
            {
                var teamDTO = Mapper.Map<TeamViewModels, TeamDTO>(team);
                _teamService.CreateTeam(teamDTO); 
                return Json(new { Result = "OK", Record = team });
            }
            else
            {
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