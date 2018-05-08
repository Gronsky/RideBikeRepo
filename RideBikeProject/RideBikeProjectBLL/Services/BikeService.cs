using System.Collections.Generic;
using AutoMapper;
using RideBikeProjectDAL.Entities;
using RideBikeProjectDAL.Interfaces;
using RideBikeProjectBLL.Interfaces;
using RideBikeProjectBLL.Infrastructure;
using RideBike.Infrastructure.DTO;

namespace RideBikeProjectBLL.Services
{
    public class BikeService : IBikeService
    {
        IRepository<User> _userRepo;
        IRepository<Bike> _bikeRepo;
        IRepository<BikeSubtype> _bikeSubtypeRepo;

        public BikeService(IRepository<User> userRepo, IRepository<Bike> bikeRepo, IRepository<BikeSubtype> bikeSubtypeRepo)
        {
            _userRepo = userRepo;
            _bikeRepo = bikeRepo;
            _bikeSubtypeRepo = bikeSubtypeRepo;
        }
        public void CreateBike(BikeDTO bikeDTO)
        {
            User owner = _userRepo.Find(bikeDTO.OwnerId);

            if (owner == null)
                throw new ValidationException("User doesn't exist", "");

            Bike bike = new Bike
            {
                Name = bikeDTO.Name,
                OwnerId = bikeDTO.OwnerId,
                ProducerId = bikeDTO.ProducerId,
                Model = bikeDTO.Model,
                Description = bikeDTO.Description
            };

            _bikeRepo.Create(bike);
        }

        public BikeDTO GetBike(long id)
        {
            #region
            //var bike = Database.Bikes.Find(id);
            //if (bike == null)
            //    throw new ValidationException("Bike doesn't find", "");
            //return new BikeDTO { Id = bike.Id, Name = bike.Name, Producer = bike.Producer, Model = bike.Model, Description = bike.Description, User = bike.User };
            #endregion
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Bike, BikeDTO>()).CreateMapper();
            return mapper.Map<Bike, BikeDTO>(_bikeRepo.Find(id));
        }

        public List<BikeDTO> GetBikes()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Bike, BikeDTO>()).CreateMapper();
            return mapper.Map<List<Bike>, List<BikeDTO>>(_bikeRepo.Get());
        }

        public List<BikeDTO> GetBikesByUser(long id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Bike, BikeDTO>()).CreateMapper();
            return mapper.Map<List<Bike>, List<BikeDTO>>(_bikeRepo.Get(x => x.OwnerId == id));
        }

        //public IEnumerable<BikeDTO> GetBikesByTeam(long id)
        //{
        //    Team team = Database.Teams.Find(id);
        //    List<User> riders = Database.Users.Get(x => x.Team == team);

        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Bike, BikeDTO>()).CreateMapper();
        //    return mapper.Map<IEnumerable<Bike>, List<BikeDTO>>(Database.Bikes.Get(x => x.OwnerId == id));
        //}

        public List<BikeDTO> GetBikesBySubtype(long id)
        {
            BikeSubtype subtype = _bikeSubtypeRepo.Find(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Bike, BikeDTO>()).CreateMapper();
            return mapper.Map<List<Bike>, List<BikeDTO>>(_bikeRepo.Get(x => x.TypeId == subtype.Id));
        }

        public void UpdateBike(BikeDTO bikeDTO)
        {
            Bike bike = _bikeRepo.Find(bikeDTO.Id);
            _bikeRepo.Update(bike);
        }
        public void DeleteBike(long id)
        {
            _bikeRepo.Remove(id);
        }
    }
}
