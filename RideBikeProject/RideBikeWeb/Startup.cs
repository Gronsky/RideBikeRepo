using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RideBikeWeb.Startup))]
namespace RideBikeWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
