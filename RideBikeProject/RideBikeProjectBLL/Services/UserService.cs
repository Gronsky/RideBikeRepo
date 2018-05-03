using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RideBikeProjectDAL.Entities;
using RideBikeProjectDAL.Interfaces;
using RideBikeProjectBLL.DTO;
using RideBikeProjectBLL.Interfaces;
using RideBikeProjectBLL.Infrastructure;
using RideBikeProjectDAL.Repositories;
using System.Security.Claims;
using RideBikeProjectDAL.Identity;
using Microsoft.AspNet.Identity;

namespace RideBikeProjectBLL.Services
{
    public class UserService : IUserService
    {
        IRepository<User> _userRepo;
        IRepository<Role> _roleRepo;
        IRepository<Event> _evntRepo;

        public UserService(IRepository<User> userRepo, IRepository<Role> roleRepo, IRepository<Event> evntRepo)
        {
            _userRepo = userRepo;
            _roleRepo = roleRepo;
            _evntRepo = evntRepo;
        }

        public void CreateUser(UserDTO userDTO)
        {
            Role role = _roleRepo.Find(userDTO.RoleId);

            // Validation
            if (role == null)
                throw new ValidationException("Role doesn't exist", "");

            User user = new User
            {
                Id = userDTO.Id,
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                Password = userDTO.Password,
                BirthDate = userDTO.BirthDate,
                ImageId = userDTO.ImageId,
                TeamId = userDTO.TeamId,
                RoleId = userDTO.RoleId
            };

            _userRepo.Create(user);
        }

        public UserDTO Login(UserDTO userDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            var dbUser = mapper.Map<User, UserDTO>((_userRepo.Get(x => x.Email.Equals(userDto.Email))).FirstOrDefault());

            if (dbUser.Password.Equals(userDto.Password))
            {
                return dbUser;
            }
            return null;
        }

        public UserDTO GetUser(long userId)
        {
            var user = _userRepo.Find(userId);
            if (user == null)
                throw new ValidationException("User doesn't find", "");

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<User, UserDTO>(user);
        }

        public List<UserDTO> GetUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            return mapper.Map<List<User>, List<UserDTO>>(_userRepo.Get());
        }

        public void UpdateUser(UserDTO userDTO)
        {
            User user = _userRepo.Find(userDTO.Id);
            _userRepo.Update(user);
        }

        public void DeleteUser(long userId)
        {
            _userRepo.Remove(userId);
        }

        public List<EventDTO> GetUserEvents(long userId)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Event, EventDTO>()).CreateMapper();
            return mapper.Map<List<Event>, List<EventDTO>>(_evntRepo.Get());
        }
    }
}
