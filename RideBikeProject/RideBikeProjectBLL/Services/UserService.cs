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
        IRepository<Image> _imgRepo;
        IRepository<User> _userRepo;
        IRepository<Role> _roleRepo;
        IRepository<Event> _evntRepo;
        IRepository<Team> _teamRepo;

        public UserService(IRepository<User> userRepo, IRepository<Role> roleRepo, IRepository<Event> evntRepo, IRepository<Image> imgRepo, IRepository<Team> teamRepo)
        {
            _userRepo = userRepo;
            _roleRepo = roleRepo;
            _evntRepo = evntRepo;
            _imgRepo = imgRepo;
            _teamRepo = teamRepo;
        }

        public void CreateUser(UserDTO userDTO)
        {
            Role role = _roleRepo.Find(userDTO.RoleId);
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
            var dbUser = Mapper.Map<User, UserDTO>((_userRepo.Get(x => x.Email.Equals(userDto.Email))).FirstOrDefault());

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

            var userDto =  Mapper.Map<User, UserDTO>(user);

            //get image src
            if (user.ImageId != null)
            {
                long id = user.ImageId.Value;
                Image img = _imgRepo.Find(id);
                userDto.Image = img.Source;
            }

            //get team name
            if (user.TeamId != null)
            {
                long id = user.TeamId.Value;
                Team team = _teamRepo.Find(id);
                userDto.Team = team.Name;
            }
            return userDto;
        }

        public List<UserDTO> GetUsers()
        {
            return Mapper.Map<List<User>, List<UserDTO>>(_userRepo.Get());
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
            return Mapper.Map<List<Event>, List<EventDTO>>(_evntRepo.Get());
        }

        public void ChangeImage(string image, long userId)
        {
            Image img = new Image { Source = image };
            _imgRepo.Create(img);
            Image getImg = _imgRepo.Get(x => x.Source == image).FirstOrDefault();

            User user = _userRepo.Find(userId);
            user.ImageId = getImg.Id;
            _userRepo.Update(user);
        }
    }
}
