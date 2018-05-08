using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using RideBikeProjectBLL.Interfaces;
using System.Text;
using RideBike.Infrastructure.DTO;
using RideBike.Infrastructure.Models;

using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Drive.v2;
using Google.Apis.Services;
using System.Threading;
using System.Threading.Tasks;
using RideBikeWeb.Infrastructure;

namespace RideBikeWeb.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        IEventService _evntService;
        public EventController(IEventService evntServ)
        {
            _evntService = evntServ;
        }     

        public ActionResult Events()
        {
            ViewBag.Message = "Events";
            List<EventDTO> evntDtos = _evntService.GetEvents();
            var evntMapper = new MapperConfiguration(cfg => cfg.CreateMap<EventDTO, EventViewModels>()).CreateMapper();
            var evnts = evntMapper.Map<List<EventDTO>, List<EventViewModels>>(evntDtos);
            return View(evnts);
        }

        [HttpPost]//Gets the todo Lists.    
        public JsonResult GetEvents(int jtStartIndex = 0, int jtPageSize = 10)
        {
            List<EventDTO> evnts = _evntService.GetEvents(jtStartIndex, jtPageSize );
            var EventCount = evnts.Count();
            return Json(new { Result = "OK", Records = evnts, TotalRecordCount = EventCount });
        }

        [HttpPost]
        public JsonResult CreateEvent([Bind(Exclude = "EventId")]EventViewModels evnt)
        {
            if (ModelState.IsValid)
            {
                evnt.TypeId = 1;
                var evntMapper = new MapperConfiguration(cfg => cfg.CreateMap<EventViewModels, EventDTO>()).CreateMapper();
                var evntDTO = evntMapper.Map<EventViewModels, EventDTO>(evnt);
                _evntService.CreateEvent(evntDTO); 
                return Json(new { Result = "OK", Record = evnt });
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
        public JsonResult EditEvent(EventViewModels evnt)
        {
            if (ModelState.IsValid)
            {   
                var evntDTO = Mapper.Map<EventViewModels, EventDTO>(evnt);
                _evntService.UpdateEvent(evntDTO);
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
        public JsonResult DeleteEvent(EventViewModels evnt)
        {
            var evntMapper = new MapperConfiguration(cfg => cfg.CreateMap<EventViewModels, EventDTO>()).CreateMapper();
            var evntDTO = evntMapper.Map<EventViewModels, EventDTO>(evnt);
            _evntService.DeleteEvent(evntDTO.Id);
            return Json(new { Result = "OK" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]//Gets the todo Lists.    
        public JsonResult EventsOfMyTeam(long teamId)
        {
            List<EventDTO> events = _evntService.GetEventsByTeam(teamId);
            var eventCount = events.Count;
            return Json(new { Result = "OK", Records = events, TotalRecordCount = eventCount });
        }
    }
}