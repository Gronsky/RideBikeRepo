using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RideBikeProjectDAL;
using RideBikeProjectDAL.Entities;
using RideBikeProjectDAL.Interfaces;
using RideBikeProjectBLL.DTO;
using RideBikeProjectBLL.Interfaces;
using RideBikeProjectBLL.Infrastructure;

namespace RideBikeProjectBLL.Services
{
    public class EventService : IEventService
    {
        IRepository<Team> _teamRepo;
        IRepository<Event> _eventRepo;
        IRepository<EventUser> _eventUserRepo;

        public EventService(IRepository<Team> teamRepo, IRepository<Event> eventRepo, IRepository<EventUser> eventUserRepo)
        {
            _teamRepo = teamRepo;
            _eventRepo = eventRepo;
            _eventUserRepo = eventUserRepo;
        }

        public void CreateEvent(EventDTO eventDTO)
        {
            Team team = _teamRepo.Find(eventDTO.CreatedBy);
            if (team == null)
                throw new ValidationException("Team doesn't exist", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<EventDTO, Event>()).CreateMapper();
            _eventRepo.Create(mapper.Map<EventDTO, Event>(eventDTO));
        }

        public EventDTO GetEvent(long id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Event, EventDTO>()).CreateMapper();
            return mapper.Map<Event, EventDTO>(_eventRepo.Find(id));
        }

        public List<EventDTO> GetEvents()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Event, EventDTO>()).CreateMapper();
            return mapper.Map<List<Event>, List<EventDTO>>(_eventRepo.Get());
        }

        public List<EventDTO> GetEventsByTeam(long id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Event, EventDTO>()).CreateMapper();
            return mapper.Map<List<Event>, List<EventDTO>>(_eventRepo.Get(x => x.CreatedBy == id));
        }

        public void UpdateEvent(EventDTO eventDTO)
        {
            Event evnt = _eventRepo.Find(eventDTO.Id);
            _eventRepo.Update(evnt);
        }

        public void DeleteEvent(long id)
        {
            _eventRepo.Remove(id);
        }

        public void AddParticipant(EventDTO evntDTO, UserDTO userDTO)
        {
            EventUser evntUser = new EventUser
            {
                EventId = evntDTO.Id,
                UserId = userDTO.Id
            };
            _eventUserRepo.Create(evntUser);
        }

        public void AddParticipant(EventDTO evntDTO, UserDTO userDTO, BikeDTO bikeDTO)
        {
            EventUser evntUser = new EventUser
            {
                EventId = evntDTO.Id,
                UserId = userDTO.Id,
                BikeId = bikeDTO.Id
            };
            _eventUserRepo.Create(evntUser);
        }

        public List<UserDTO> GetParticipants(long id)
        {
            throw new NotImplementedException();
        }

    }
}
