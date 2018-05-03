using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RideBikeProjectDAL.Entities;
using RideBikeProjectDAL.Interfaces;

namespace RideBikeProjectDAL
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            var bikeRepo = kernel.Get<IRepository<Bike>>();
            var userRepo = kernel.Get<IRepository<User>>();
            var teamRepo = kernel.Get<IRepository<Team>>();
            var eventRepo = kernel.Get<IRepository<Event>>();
            var imgRepo = kernel.Get<IRepository<Image>>();
            var evntUserRepo = kernel.Get<IRepository<EventUser>>();


            List<User> listOfUsers = userRepo.Get();
            foreach (var u in listOfUsers)
            {
                Console.WriteLine(u);
            }

            //var Other = new Producer { Producer1 = "Other" };
            //var Specialized = new Producer { Producer1 = "Specialized" };
            //var Giant = new Producer { Producer1 = "Giant" };
            //var Cannondale = new Producer { Producer1 = "Cannondale" };
            //var Focus = new Producer { Producer1 = "Focus" };
            //var Author = new Producer { Producer1 = "Author" };
            //var YT = new Producer { Producer1 = "YT" };
            //var Canyon = new Producer { Producer1 = "Canyon" };
            //var BMC = new Producer { Producer1 = "BMC" };
            //var Cube = new Producer { Producer1 = "Cube" };
            //var GT = new Producer { Producer1 = "GT" };
            //var Merida = new Producer { Producer1 = "Merida" };
            //var SCOTT = new Producer { Producer1 = "SCOTT" };
            //var Yeti = new Producer { Producer1 = "Yeti" };
            //var Alutech = new Producer { Producer1 = "Alutech" };
            //var Trek = new Producer { Producer1 = "Trek" };
            //var SantaCruz = new Producer { Producer1 = "Santa Cruz" };

            //var producers = new List<Producer>() { Other, Specialized, Giant, Cannondale, Focus, Author, YT, Canyon, BMC, Cube, GT, Merida, SCOTT, Yeti, Alutech, Trek, SantaCruz };

            //var MTB = new BikeType { Type = "MTB" };
            //var Road = new BikeType { Type = "Road" };
            //var BMX = new BikeType { Type = "BMX" };
            //var Custom = new BikeType { Type = "Other" };

            //var bikeTypes = new List<BikeType>() { MTB, Road, BMX, Custom };

            //var MTBDownhillType = new BikeSubtype { Subtype = "Downhill", BikeType = MTB };
            //var MTBEnduroType = new BikeSubtype { Subtype = "Enduro", BikeType = MTB };
            //var MTBFreerideType = new BikeSubtype { Subtype = "Freeride", BikeType = MTB };
            //var MTBDirtJumpType = new BikeSubtype { Subtype = "DirtJump", BikeType = MTB };
            //var MTBXCTrailType = new BikeSubtype { Subtype = "XCTrail", BikeType = MTB };
            //var MTBXCRaceType = new BikeSubtype { Subtype = "XCRace", BikeType = MTB };
            //var RoadRaceType = new BikeSubtype { Subtype = "Race", BikeType = Road };
            //var RoadSportType = new BikeSubtype { Subtype = "Sport", BikeType = Road };
            //var RoadAeroType = new BikeSubtype { Subtype = "Aero", BikeType = Road };
            //var RoadTouringType = new BikeSubtype { Subtype = "Touring", BikeType = Road };
            //var BMXFlatType = new BikeSubtype { Subtype = "Flat", BikeType = BMX };
            //var BMXStreetType = new BikeSubtype { Subtype = "Street", BikeType = BMX };
            //var BMXParkType = new BikeSubtype { Subtype = "Park", BikeType = BMX };
            //var BMXRaceType = new BikeSubtype { Subtype = "Race", BikeType = BMX };
            //var CustomType = new BikeSubtype { Subtype = "Custom", BikeType = Custom };

            //var bikeSubtypes = new List<BikeSubtype>() { MTBDownhillType, MTBEnduroType, MTBFreerideType, MTBDirtJumpType, MTBXCTrailType, MTBXCRaceType, RoadAeroType,
            //                                             RoadRaceType, RoadSportType, RoadTouringType, BMXFlatType, BMXStreetType, BMXParkType, BMXRaceType, CustomType };


            Console.ReadKey();
        }
    }
}
