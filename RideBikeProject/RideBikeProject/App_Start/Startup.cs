using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RideBikeProjectWEB.Startup))]
namespace RideBikeProjectWEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}