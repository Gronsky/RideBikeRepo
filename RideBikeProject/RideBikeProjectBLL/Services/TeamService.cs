using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using RideBikeProjectDAL.Entities;
using RideBikeProjectDAL.Interfaces;
using RideBikeProjectBLL.Interfaces;
using RideBikeProjectBLL.Infrastructure;
using RideBike.Infrastructure.DTO;

namespace RideBikeProjectBLL.Services
{
    public class TeamService : ITeamService
    {
        IRepository<Team> _teamRepo;
        IRepository<User> _userRepo;
        IRepository<Role> _roleRepo;
        IRepository<Image> _imgRepo;

        public TeamService(IRepository<Team> teamRepo, IRepository<User> userRepo, IRepository<Role> roleRepo, IRepository<Image> imgRepo)
        {
            _teamRepo = teamRepo;
            _userRepo = userRepo;
            _roleRepo = roleRepo;
            _imgRepo = imgRepo;
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
            // Set chief-role
            chief.RoleId = 3;  
            
            _teamRepo.Create(team);
            chief.TeamId = team.Id;
            _userRepo.Update(chief);
        }

        public TeamDTO GetTeam(long teamId)
        {
            var team = _teamRepo.Find(teamId);
            if (team == null)
                throw new ValidationException("Team doesn't find", "");

            var teamDto = Mapper.Map<Team, TeamDTO>(team);

            // Get image src
            if (team.ImageId != null)
            {
                long id = team.ImageId.Value;
                Image img = _imgRepo.Find(id);
                teamDto.Image = img.Source;
            }

            // Get chief name
            User chief = _userRepo.Find(team.ChiefId);
            teamDto.Chief = string.Concat(chief.FirstName, " ", chief.LastName);
            return teamDto;
        }

        public List<TeamDTO> GetTeams()
        {
            return Mapper.Map<List<Team>, List<TeamDTO>>(_teamRepo.Get());
        }

        public List<TeamDTO> GetTeams( int jtStartIndex, int jtPageSize )
        {
            return Mapper.Map<List<Team>, List<TeamDTO>>(_teamRepo.Paging((x => x.Name), jtStartIndex, jtPageSize));
        }

        public int GetTeamCount()
        {
            return _teamRepo.Count();
        }

        public void UpdateTeam(TeamDTO teamDTO)
        {
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

        public void ChangeImage(string image, long teamId)
        {
            Image img = new Image { Source = image };
            _imgRepo.Create(img);
            Image getImg = _imgRepo.Get(x => x.Source == image).FirstOrDefault();

            Team team = _teamRepo.Find(teamId);
            team.ImageId = getImg.Id;
            _teamRepo.Update(team);
        }
    }
}
