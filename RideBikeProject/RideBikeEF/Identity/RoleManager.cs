using Microsoft.AspNet.Identity;
using RideBikeProjectDAL.Entities;

namespace RideBikeProjectDAL.Identity
{
    public class RoleManager : RoleManager<Role, long>
    {
        public RoleManager(IRoleStore<Role, long> store) : base(store)
        {
        }
    }
}
