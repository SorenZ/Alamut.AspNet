using System;
using System.Security.Claims;

namespace Alamut.AspNet.Identity
{
    public static class ClaimsPrincipalExtensions 
    {
        /// <summary>
        /// get user Id for current user from ClaimPrincipal 
        /// </summary>
        /// <param name="principal"></param>
        /// <returns>if user id provided in claim return that, otherwise return null</returns>
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
