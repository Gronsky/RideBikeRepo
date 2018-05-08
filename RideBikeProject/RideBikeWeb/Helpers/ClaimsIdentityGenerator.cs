using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using RideBike.Infrastructure.DTO;

namespace RideBikeWeb.Helpers
{
    public static class ClaimsIdentityGenerator
    {
        public static ClaimsIdentity GetClaimsIdentity(this UserDTO user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            return identity;
        }
    }
}