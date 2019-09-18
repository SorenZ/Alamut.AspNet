using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Caching.Distributed;

using MessagePack;
using MessagePack.Resolvers;

namespace Alamut.Extensions.Caching.Distributed
{
    public static class DistributedCacheRefTypeExtensions
    {
        static DistributedCacheRefTypeExtensions()
        {
            CompositeResolver.RegisterAndSetAsDefault(
            new[] { NativeDateTimeResolver.Instance, ContractlessStandardResolver.Instance });
        }

        public static void Set<T>(this IDistributedCache cache,
            string key,
            T value,
            DistributedCacheEntryOptions options)
        {
            cache.Set(key, MessagePackSerializer.Serialize(value), options);
        }

        public static T Get<T>(this IDistributedCache cache, string key) where T : class
        {
            var val = cache.Get(key);

            return val == null
                ? null
                : MessagePackSerializer.Deserialize<T>(val);
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
            await cache.SetAsync(key,
                MessagePackSerializer.Serialize(value),
                options,
                token);
        }

        public static async Task<T> GetAsync<T>(this IDistributedCache cache, string key) where T : class
        {
            var val = await cache.GetAsync(key);

            return val == null
                ? null
                : MessagePackSerializer.Deserialize<T>(val);

        }

        public static bool TryGet<T>(this IDistributedCache cache, string key, out T returnValue)
        {
            var val = cache.Get(key);

            if (val == null)
            {
                returnValue = default(T);
                return false;
            }

            returnValue = MessagePackSerializer.Deserialize<T>(val);

            return true;
        }

        public static async Task<(bool exist, T returnValue)> TryGetAsync<T>(this IDistributedCache cache, string key)
        {
            var val = await cache.GetAsync(key);
            if (val == null)
            {
                return (false, default(T));
            }

            var value = MessagePackSerializer.Deserialize<T>(val);

            return (true, value);
        }
    }
}