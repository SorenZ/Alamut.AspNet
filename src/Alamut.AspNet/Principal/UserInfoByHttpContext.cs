using System.Security.Claims;
using Alamut.Abstractions.Principal;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace Alamut.AspNet.Principal
{
    public class UserInfoByHttpContext : IUserInfo
    {
        private readonly IHttpContextAccessor _context;

        public UserInfoByHttpContext(IHttpContextAccessor context)
        {
            _context = context;
        }

        public string UserName => _context.HttpContext.User?.Identity?.Name;
        
        public string Name => _context.HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
        
        public string GivenName => _context.HttpContext.User.FindFirst(ClaimTypes.GivenName)?.Value;
        
        public string UserId => _context.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        public string UserAgent => _context.HttpContext.Request.Headers[HeaderNames.UserAgent].ToString();

        public string GetClientIpAddress(bool tryUseXForwardHeader = true)
        {
            var ipHelper = new IpHelper(_context);
            
            return ipHelper.GetRequestIp(tryUseXForwardHeader);
        }
    }

}