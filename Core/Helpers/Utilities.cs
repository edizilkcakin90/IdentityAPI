using IdentityModel;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Core.Helpers
{
    public class Utilities
    {
        public static string GetUserId(ClaimsPrincipal user)
        {
            return user.FindFirst(JwtClaimTypes.Subject)?.Value?.Trim();
        }
    }
}
