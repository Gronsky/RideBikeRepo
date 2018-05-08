using System.Collections.Generic;
using RideBike.Infrastructure.DTO;

namespace RideBikeProjectBLL.Interfaces
{
    public interface IUserService
    {
        void CreateUser(UserDTO userDTO);
        UserDTO Login(UserDTO userDto);
        UserDTO GetUser(long userId);
        List<UserDTO> GetUsers();
        void UpdateUser(UserDTO userDTO);
        void DeleteUser(long userId);

        List<EventDTO> GetUserEvents(long userId);

        void ChangeImage(string image, long userId);
    }
}
