using System.Collections.Generic;
using AutoMapper;
using RideBikeProjectDAL.Entities;
using RideBikeProjectDAL.Interfaces;
using RideBikeProjectBLL.Interfaces;
using RideBikeProjectBLL.Infrastructure;
using RideBike.Infrastructure.DTO;

namespace RideBikeProjectBLL.Services
{
    public class EventService : IEventService
    {
        IRepository<Team> _teamRepo;
        IRepository<Event> _eventRepo;
        IRepository<EventUser> _eventUserRepo;
        IRepository<EventType> _evntTypeRepo;

        public EventService(IRepository<Team> teamRepo, IRepository<Event> eventRepo, IRepository<EventUser> eventUserRepo, IRepository<EventType> evntTypeRepo)
        {
            _teamRepo = teamRepo;
            _eventRepo = eventRepo;
            _eventUserRepo = eventUserRepo;
            _evntTypeRepo = evntTypeRepo;
        }

        public void CreateEvent(EventDTO eventDTO)
        {
            Team team = _teamRepo.Find(eventDTO.CreatedBy);
            if (team == null)
                throw new ValidationException("Team doesn't exist", "");

            _eventRepo.Create(Mapper.Map<EventDTO, Event>(eventDTO));
        }

        public EventDTO GetEvent(long id)
        {
            return Mapper.Map<Event, EventDTO>(_eventRepo.Find(id));
        }

        public List<EventDTO> GetEvents()
        {
            return Mapper.Map<List<Event>, List<EventDTO>>(_eventRepo.Get());
        }

        public List<EventDTO> GetEvents(int jtStartIndex, int jtPageSize)
        {
            return Mapper.Map<List<Event>, List<EventDTO>>(_eventRepo.Paging((x => x.Id), jtStartIndex, jtPageSize));
        }

        public List<EventDTO> GetEventsByTeam(long id)
        {
            return Mapper.Map<List<Event>, List<EventDTO>>(_eventRepo.Get(x => x.CreatedBy == id));
        }

        public void UpdateEvent(EventDTO eventDTO)
        {
            Event evnt = _eventRepo.Find(eventDTO.Id);
            evnt.Location = eventDTO.Location;
            evnt.Name = eventDTO.Name;
            evnt.Description = eventDTO.Description;
            evnt.CreatedBy = eventDTO.CreatedBy;
            _eventRepo.Update(evnt);
        }

        public void DeleteEvent(long id)
        {
            _eventRepo.Remove(id);
        }

        public List<EventTypeDTO> GetAllEventTypes()
        {
            return Mapper.Map<List<EventType>, List<EventTypeDTO>>(_evntTypeRepo.Get());
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
    }
}
