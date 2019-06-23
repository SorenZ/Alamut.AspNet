using Microsoft.AspNetCore.Http;

namespace Alamut.Utilities.AspNet.Http
{
    public static class UrlHelper
    {
        public static string GetSubDomain(HttpContext httpContext)
        {
            var subDomain = string.Empty;

            var host = httpContext.Request.Host.Host;

            if (!string.IsNullOrWhiteSpace(host))
            {
                subDomain = host.Split('.')[0];
            }

            return subDomain.Trim().ToLower();
        }
    }
}
