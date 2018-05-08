using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using RideBikeWeb.Infrastructure;
using RideBike.Infrastructure.Models;
using RideBike.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using RideBikeProjectBLL.Interfaces;
using Microsoft.AspNet.Identity;

namespace RideBikeWeb.Controllers
{
    [Authorize]
    public class CalendarController : Controller
    {
        CalendarService service;
        IEventService _evntService;
        ITeamService _teamService;
        List<string> typeList = new List<string>() { "XC Marathon", "FourCross", "Enduro", "Dirt Jumping" };
        public CalendarController(IEventService evntServ, ITeamService teamServ)
        {
            _evntService = evntServ;
            _teamService = teamServ;
        }

        // GET: Calendar
        public async Task<ActionResult> Index(CancellationToken cancellationToken)
        {
            var result = await new AuthorizationCodeMvcApp(this, new AppFlowMetadata()).
                AuthorizeAsync(cancellationToken);

            if (result.Credential == null)
            {
                return new RedirectResult(result.RedirectUri);
            }
            else
            {
                service = new CalendarService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = result.Credential,
                    ApplicationName = "ASP.NET MVC RideBike"
                });
            }

            return View();
        }


        public ActionResult AddEvent(long? teamId)
        {
            EventViewModels model;
            // For Types Drop Down List
           
            ViewBag.List = typeList;


            if (teamId != null)
            {
                model = new EventViewModels() { CreatedBy = teamId.Value };
            }
            else
            {
                var Id = User.Identity.GetUserId();
                var teams = _teamService.GetTeams();
                var team = teams.Find(x => x.ChiefId.ToString() == Id);

                if (team == null)
                    return Redirect("/NoAccess/");
                else 
                    model = new EventViewModels() { CreatedBy = team.Id };
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddEvent(CancellationToken cancellationToken, EventViewModels model)
        {
            var result = await new AuthorizationCodeMvcApp(this, new AppFlowMetadata()).
                AuthorizeAsync(cancellationToken);

            if (result.Credential == null)
            {
                return new RedirectResult(result.RedirectUri);
            }
            else
            {
                service = new CalendarService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = result.Credential,
                    ApplicationName = "ASP.NET MVC Sample"
                });
            }

            // Add to DataBase
            model.TypeId = typeList.IndexOf(model.Type);

            var evntDto = Mapper.Map<EventViewModels, EventDTO>(model);
            _evntService.CreateEvent(evntDto);

            // Add to Google Calendar
            Event newEvent = new Event
            {
                Summary = model.Description,
                Location = model.Location,
                Start = new EventDateTime()
                {
                    DateTime = model.DateTime,
                    TimeZone = "America/Los_Angeles"
                },
                End = new EventDateTime()
                {
                    DateTime = model.DateTime.AddHours(8),
                    TimeZone = "America/Los_Angeles"
                },
                Recurrence = new String[] { /*"RRULE:FREQ=WEEKLY;BYDAY=MO"*/ },
                Attendees = new List<EventAttendee>()
                {
                    new EventAttendee() { Email = "gronsky.n@gmail.com" }
                }
            };


            Event recurringEvent = service.Events.Insert(newEvent, "glal2glkneisa5uk6ma42h5oi0@group.calendar.google.com").Execute();

            return RedirectToAction("Index", "Calendar");
            
        }
    }
}