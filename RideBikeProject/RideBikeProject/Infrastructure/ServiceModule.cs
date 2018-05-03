using Ninject.Modules;
using RideBikeProjectBLL.Interfaces;
using RideBikeProjectBLL.Services;

namespace RideBikeProjectWEB.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<UserService>().To<UserService>();
            Bind<ITeamService>().To<TeamService>();
            Bind<IBikeService>().To<BikeService>();
            Bind<IEventService>().To<EventService>();
        }
    }
}