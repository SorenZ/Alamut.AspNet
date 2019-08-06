using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace Alamut.AspNet.Caching
{
    public static class DistributedCacheHelperExtensions
    {
        // public static async Task<T> GetOrCreateAsync<T>(this IDistributedCache cache,
        //     string key,
        //     Func<Task<T>> factory,
        //     TimeSpan? slidingExpiration = null,
        //     TimeSpan? absoluteExpirationRelativeToNow = null,
        //     DateTimeOffset? absoluteExpiration = null) where T : class
        // {
        //     //if (cache.TryGet(key, out T value)) 
        //     //{ return value; }

        //     var value = await cache.GetAsync<T>(key);

        //     if (value != null)
        //         { return value;}


        //     value = await factory();

        //     await cache.SetAsync(key, value, new DistributedCacheEntryOptions
        //     {
        //         AbsoluteExpirationRelativeToNow = absoluteExpirationRelativeToNow,
        //         SlidingExpiration = slidingExpiration,
        //         AbsoluteExpiration = absoluteExpiration
        //     });

        //     return value;
        // }

        public static T GetOrCreate<T>(this IDistributedCache cache,
            string key,
            Func<T> factory,
            TimeSpan? slidingExpiration = null,
            TimeSpan? absoluteExpirationRelativeToNow = null,
            DateTimeOffset? absoluteExpiration = null) where T : class
        {
            if (cache.TryGet(key, out T value))
            {return value;}

            value = factory();

            cache.Set(key, value, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpirationRelativeToNow,
                SlidingExpiration = slidingExpiration,
                AbsoluteExpiration = absoluteExpiration
            });

            return value;
        }

        public static string GetOrCreateString(this IDistributedCache cache,
            string key,
            Func<string> factory,
            TimeSpan? slidingExpiration = null,
            TimeSpan? absoluteExpirationRelativeToNow = null,
            DateTimeOffset? absoluteExpiration = null)
        {
            var value = cache.GetString(key);
            if (value != null)
                { return value;}

            value = factory();

            cache.SetString(key, value, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = absoluteExpirationRelativeToNow,
                SlidingExpiration = slidingExpiration,
                AbsoluteExpiration = absoluteExpiration
            });

            return value;
        }

        public static async Task<string> GetOrCreateStringAsync(this IDistributedCache cache,
            string key,
            Func<Task<string>> factory,
            TimeSpan? slidingExpiration = null,
            TimeSpan? absoluteExpirationRelativeToNow = null,
            DateTimeOffset? absoluteExpiration = null)
        {

            var value = cache.GetString(key);

            if (value != null)
                {return value;}

            value = await factory();

            if (value == null)
                {return null;}

            await cache.SetStringAsync(key, value, new DistributedCacheEntryOptions
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