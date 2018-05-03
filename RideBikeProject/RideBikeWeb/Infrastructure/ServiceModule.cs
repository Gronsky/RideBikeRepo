using Ninject.Modules;
using RideBikeProjectBLL.Interfaces;
using RideBikeProjectBLL.Services;

namespace RideBikeWEB.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<ITeamService>().To<TeamService>();
            Bind<IBikeService>().To<BikeService>();
            Bind<IEventService>().To<EventService>();
        }
    }
}