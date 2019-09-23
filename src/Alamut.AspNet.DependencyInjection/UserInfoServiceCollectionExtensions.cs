using System;
using Alamut.Abstractions.Principal;
using Alamut.AspNet.Principal;
using Microsoft.Extensions.DependencyInjection;

namespace Alamut.Extensions.Microsoft.DependencyInjection
{
    /// <summary>
    /// Extensions to Register IUserInfo
    /// </summary>
    public static class UserInfoServiceCollectionExtensions
    {
        /// <summary>
        /// Registers <see cref="IUserInfo" /> by <see cref="UserInfoByHttpContext" /> implementation
        /// </summary>
        /// <param name="services"></param>
        /// <param name="byHttpContext"></param>
        /// <returns></returns>
        public static IServiceCollection AddUserInfo(this IServiceCollection services, bool byHttpContext = true)
            => services.AddScoped<IUserInfo, UserInfoByHttpContext>();
    }
}
