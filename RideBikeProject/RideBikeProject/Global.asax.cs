using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using RideBikeProjectWEB.Infrastructure;
using System.Web.Mvc;
using System.Web.Routing;

namespace RideBikeProjectWEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // внедрение зависимостей
            NinjectModule orderModule = new Infrastructure.ServiceModule();
            NinjectModule serviceModule = new RideBikeProjectBLL.Infrastructure.ServiceModule("DefaultConnection");
            var kernel = new StandardKernel(orderModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
