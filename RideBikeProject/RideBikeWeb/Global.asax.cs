using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using RideBikeWEB.Infrastructure;
using RideBikeWeb.AutoMapperProfiles;
using AutoMapper;

namespace RideBikeWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // внедрение зависимостей
            NinjectModule orderModule = new RideBikeWEB.Infrastructure.ServiceModule();
            NinjectModule serviceModule = new RideBikeProjectBLL.Infrastructure.ServiceModule("DefaultConnection");
            var kernel = new StandardKernel(orderModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));


            Mapper.Initialize(cfg => {
                cfg.AddProfile<MapperProfile>();
            });

        }
    }
}
