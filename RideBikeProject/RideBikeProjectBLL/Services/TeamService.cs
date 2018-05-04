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
    public class TeamService : ITeamService
    {
        IRepository<Team> _teamRepo;
        IRepository<User> _userRepo;
        IRepository<Role> _roleRepo;

        public TeamService(IRepository<Team> teamRepo, IRepository<User> userRepo, IRepository<Role> roleRepo)
        {
            _teamRepo = teamRepo;
            _userRepo = userRepo;
            _roleRepo = roleRepo;
        }
        public void CreateTeam(TeamDTO teamDTO)
        {
            User chief = _userRepo.Find(teamDTO.ChiefId);
            Role role = _roleRepo.Find(chief.RoleId);

            // Validation
            if (chief == null)
                throw new ValidationException("User doesn't exist", "");
            if (chief.TeamId != null)
                throw new ValidationException("User has a team already", "");
            if (role.Name.ToUpper().Equals("Chief".ToUpper()))
                throw new ValidationException("User is a chief already", "");

            Team team = new Team
            {
                Name = teamDTO.Name,
                ImageId = teamDTO.ImageId,
                Location = teamDTO.Location,
                Description = teamDTO.Description,
                ChiefId = teamDTO.ChiefId
            };
            chief.RoleId = 3;  //chief-role
            
            _teamRepo.Create(team);
            chief.TeamId = team.Id;
            _userRepo.Update(chief);
        }

        public TeamDTO GetTeam(long id)
        {
            return Mapper.Map<Team, TeamDTO>(_teamRepo.Find(id));
        }

        public List<TeamDTO> GetTeams()
        {
            return Mapper.Map<List<Team>, List<TeamDTO>>(_teamRepo.Get());
        }

        public List<TeamDTO> GetTeams( int jtStartIndex, int jtPageSize, string jtSorting)
        {
            return Mapper.Map<List<Team>, List<TeamDTO>>(_teamRepo.Paging((x => x.Name), jtSorting, jtStartIndex-1, jtPageSize));
        }

        public int GetTeamCount()
        {
            return _teamRepo.Count();
        }

        public void UpdateTeam(TeamDTO teamDTO)
        {
            //change this
            Team team = _teamRepo.Find(teamDTO.Id);
            team.Description = teamDTO.Description;
            team.ImageId = teamDTO.ImageId;
            team.Location = teamDTO.Location;
            team.Name = teamDTO.Name;
            team.ChiefId = teamDTO.ChiefId;
            _teamRepo.Update(team);
        }

        public void DeleteTeam(long id)
        {
            Team team = _teamRepo.Find(id);
            User chief = _userRepo.Find(team.ChiefId);
            chief.TeamId = null;
            chief.RoleId = 2;
            _userRepo.Update(chief);
            _teamRepo.Remove(id);
        }
    }
}
