using RideBike.Infrastructure.DTO;
using System.Collections.Generic;

namespace RideBikeProjectBLL.Interfaces
{
    public interface IEventService
    {
        void CreateEvent(EventDTO eventDTO);
        EventDTO GetEvent(long id);
        List<EventDTO> GetEvents();
        List<EventDTO> GetEvents(int jtStartIndex, int jtPageSize);
        List<EventDTO> GetEventsByTeam(long id);
        void UpdateEvent(EventDTO eventDTO);
        void DeleteEvent(long id);

        List<EventTypeDTO> GetAllEventTypes();

        void AddParticipant(EventDTO evntDTO, UserDTO userDTO);
        void AddParticipant(EventDTO evntDTO, UserDTO userDTO, BikeDTO bikeDTO);
    }
}
