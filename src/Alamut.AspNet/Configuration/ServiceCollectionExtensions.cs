using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

// https://www.strathweb.com/2016/09/strongly-typed-configuration-in-asp-net-core-without-ioptionst/
namespace Alamut.AspNet.Configuration
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// bind a configuration section to provided class and inject to the service collection with Singleton life time
        /// </summary>
        /// <typeparam name="TConfig">type of the configuration section</typeparam>
        /// <param name="services">current service collection</param>
        /// <param name="configuration">the configuration instance </param>
        /// <param name="key">the key of the configuration section to bind, use nameof(TConfig) if not provided</param>
        /// <returns></returns>
        public static TConfig AddPoco<TConfig>(this IServiceCollection services, 
            IConfiguration configuration,
            string key = null) where TConfig : class, new()
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            var config = new TConfig();
            configuration.Bind(key ?? typeof(TConfig).Name, config);
            services.AddSingleton(config);
            return config;
        }
    }
}
