using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RideBikeProjectBLL.DTO;

namespace RideBikeProjectBLL.Interfaces
{
    public interface IBikeService
    {
        void CreateBike(BikeDTO bikeDTO);
        BikeDTO GetBike(long id);
        List<BikeDTO> GetBikes();
        List<BikeDTO> GetBikesByUser(long id);
        //List<BikeDTO> GetBikesByTeam(long id);
        void UpdateBike(BikeDTO bikeDTO);
        void DeleteBike(long id);
    }
}
