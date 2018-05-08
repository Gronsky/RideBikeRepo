using RideBike.Infrastructure.DTO;
using System.Collections.Generic;

namespace RideBikeProjectBLL.Interfaces
{
    public interface IBikeService
    {
        void CreateBike(BikeDTO bikeDTO);
        BikeDTO GetBike(long id);
        List<BikeDTO> GetBikes();
        List<BikeDTO> GetBikesByUser(long id);
        void UpdateBike(BikeDTO bikeDTO);
        void DeleteBike(long id);
    }
}
