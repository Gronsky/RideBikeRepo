using RideBike.Infrastructure.DTO;
using System;
using System.Collections.Generic;

namespace RideBikeProjectBLL.Interfaces
{
    public interface ITeamService
    {
        void CreateTeam(TeamDTO teamDTO);
        TeamDTO GetTeam(long id);
        List<TeamDTO> GetTeams();
        List<TeamDTO> GetTeams( int jtStartIndex, int jtPageSize );
        int GetTeamCount();
        void UpdateTeam(TeamDTO team);
        void DeleteTeam(long id);
        void ChangeImage(string image, long teamId);
    }
}
