using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RideBikeProjectBLL.DTO;
using RideBikeProjectBLL.Infrastructure;
using System.Security.Claims;

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
    }
}
