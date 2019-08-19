using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace Alamut.AspNet.Caching
{
    public static class DistributedCacheHelperExtensions
    {
        public static T GetOrCreate<T>(this IDistributedCache cache,
            string key,
            Func<T> factory,
            TimeSpan? slidingExpiration = null,
            TimeSpan? absoluteExpirationRelativeToNow = null,
            DateTimeOffset? absoluteExpiration = null)
        {
            if (cache.TryGet(key, out T value))
                { return value; }

            value = factory();

            cache.Set(key, value, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpirationRelativeToNow,
                SlidingExpiration = slidingExpiration,
                AbsoluteExpiration = absoluteExpiration
            });

            return value;
        }

        public static async Task<T> GetOrCreateAsync<T>(this IDistributedCache cache,
            string key,
            Func<Task<T>> factory,
            TimeSpan? slidingExpiration = null,
            TimeSpan? absoluteExpirationRelativeToNow = null,
            DateTimeOffset? absoluteExpiration = null) 
        {

            var result = await cache.TryGetAsync<T>(key);

            if (result.exist)
                { return result.returnValue; }

            var value = await factory();

            if (value == null)
                { return value; }

            await cache.SetAsync(key, value, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpirationRelativeToNow,
                SlidingExpiration = slidingExpiration,
                AbsoluteExpiration = absoluteExpiration
            });

            return value;
        }
         
    }
}