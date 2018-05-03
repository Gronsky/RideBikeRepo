using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RideBikeProjectBLL.DTO;

namespace RideBikeProjectBLL.Interfaces
{
    public interface IEventService
    {
        void CreateEvent(EventDTO eventDTO);
        EventDTO GetEvent(long id);
        List<EventDTO> GetEvents();
        List<EventDTO> GetEventsByTeam(long id);
        void UpdateEvent(EventDTO eventDTO);
        void DeleteEvent(long id);

        void AddParticipant(EventDTO evntDTO, UserDTO userDTO);
        void AddParticipant(EventDTO evntDTO, UserDTO userDTO, BikeDTO bikeDTO);
        List<UserDTO> GetParticipants(long id);
    }
}
