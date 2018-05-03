using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RideBikeProjectBLL.DTO;

namespace RideBikeProjectBLL.Interfaces
{
    public interface ITeamService
    {
        void CreateTeam(TeamDTO teamDTO);
        TeamDTO GetTeam(long id);
        List<TeamDTO> GetTeams();
        List<TeamDTO> GetTeams( int jtStartIndex, int jtPageSize, string jtSorting);
        int GetTeamCount();
        void UpdateTeam(TeamDTO team);
        void DeleteTeam(long id);
    }
}
