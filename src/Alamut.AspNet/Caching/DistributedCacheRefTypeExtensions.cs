using System.Threading;
using System.Threading.Tasks;
using MessagePack;
using Microsoft.Extensions.Caching.Distributed;

namespace Alamut.AspNet.Caching
{
    public static class DistributedCacheRefTypeExtensions
    {
        public static void Set<T>(this IDistributedCache cache,
            string key,
            T value,
            DistributedCacheEntryOptions options) where T : class
        {
            //cache.Set(key, value.ToBson(), options);
            // cache.SetString(key, Newtonsoft.Json.JsonConvert.SerializeObject(value), options);
            cache.Set(key,
                MessagePackSerializer.Serialize(value, MessagePack.Resolvers.ContractlessStandardResolver.Instance),
                options);
        }

        public static T Get<T>(this IDistributedCache cache, string key) where T : class
        {
            var val = cache.Get(key);

            return val == null
                ? null
                : MessagePackSerializer.Deserialize<T>(val, MessagePack.Resolvers.ContractlessStandardResolver.Instance);
        }

        public static async Task SetAsync<T>(this IDistributedCache cache,
            string key,
            T value,
            CancellationToken token = default) where T : class
        {
            await SetAsync(cache, key, value, new DistributedCacheEntryOptions(), token);
        }

        public static async Task SetAsync<T>(this IDistributedCache cache,
            string key,
            T value,
            DistributedCacheEntryOptions options,
            CancellationToken token = default)
        {
            //return cache.SetAsync(key, value.ToBson(), options);
            // await cache.SetStringAsync(key, Newtonsoft.Json.JsonConvert.SerializeObject(value), options);
            await cache.SetAsync(key,
                MessagePackSerializer.Serialize(value, MessagePack.Resolvers.ContractlessStandardResolver.Instance),
                options,
                token);
        }

        public static async Task<T> GetAsync<T>(this IDistributedCache cache, string key) where T : class
        {
             var val = await cache.GetAsync(key);

             return val == null
                 ? null
                 : MessagePackSerializer.Deserialize<T>(val, MessagePack.Resolvers.ContractlessStandardResolver.Instance);

        }

        public static bool TryGet<T>(this IDistributedCache cache, string key, out T returnValue) 
            where T : class
        {
            returnValue = null;
            var val = cache.Get(key);

            if (val == null)
            {
                return false;
            }

            returnValue = MessagePackSerializer.Deserialize<T>(val, MessagePack.Resolvers.ContractlessStandardResolver.Instance);

            return true;
        }

        public static async Task<(bool exist, T returnValue)> TryGetAsync<T>(this IDistributedCache cache, string key)
        {
            var val = await cache.GetAsync(key);
            if (val == null)
            {
                return (false, default(T));
            }

            var value = MessagePackSerializer.Deserialize<T>(val, MessagePack.Resolvers.ContractlessStandardResolver.Instance);

            return (true, value);
        }
    }
}