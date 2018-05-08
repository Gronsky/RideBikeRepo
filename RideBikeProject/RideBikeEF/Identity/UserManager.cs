using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using RideBikeProjectDAL.Entities;

namespace RideBikeProjectDAL.Identity
{
    public class UserManager : UserManager<User>
    {
        public UserManager(IUserStore<User> store) : base(store)
        {
        }

        public static UserManager Create(IdentityFactoryOptions<UserManager> options, IOwinContext context)
        {

            RideBikeContext db = context.Get<RideBikeContext>();
            UserManager manager = new UserManager(new UserStore<User>(db));

            return manager;
        }
    }
}
