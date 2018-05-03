using Microsoft.AspNet.Identity;
using RideBikeProjectBLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

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