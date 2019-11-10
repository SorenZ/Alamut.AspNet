using System.Security.Claims;
using Alamut.Abstractions.Principal;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace Alamut.AspNet.Principal
{
    public class UserInfoByHttpContext : IUserInfo
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserInfoByHttpContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string UserName => _httpContextAccessor.HttpContext?.User?.Identity?.Name;
        
        public string Name => _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Name)?.Value;
        
        public string GivenName => _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.GivenName)?.Value;
        
        public string UserId => _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        public string UserAgent => _httpContextAccessor.HttpContext?.Request?.Headers[HeaderNames.UserAgent].ToString();

        public string RequestPath => _httpContextAccessor.HttpContext?.Request?.Path;

        public string RequestQueryString => _httpContextAccessor.HttpContext?.Request?.QueryString.ToString();

        public string RequestMethod => _httpContextAccessor.HttpContext?.Request?.Method;

        public string GetClientIpAddress(bool tryUseXForwardHeader = true)
        {
            var ipHelper = new IpHelper(_httpContextAccessor);
            return ipHelper.GetRequestIp(tryUseXForwardHeader);
        }
    }

}