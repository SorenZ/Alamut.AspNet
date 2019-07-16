using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace Alamut.AspNet.Caching
{
    public static class DistributedCacheRefTypeExtensions
    {
        public static void Set<T>(this IDistributedCache cache,
            string key,
            T value,
            DistributedCacheEntryOptions options)
        {
            //cache.Set(key, value.ToBson(), options);
            cache.SetString(key, Newtonsoft.Json.JsonConvert.SerializeObject(value), options);
        }

        public static async Task SetAsync<T>(this IDistributedCache cache,
            string key,
            T value)
        {
            await SetAsync(cache, key, value, new DistributedCacheEntryOptions());
        }

        public static async Task SetAsync<T>(this IDistributedCache cache,
            string key,
            T value,
            DistributedCacheEntryOptions options)
        {
            //return cache.SetAsync(key, value.ToBson(), options);
            await cache.SetStringAsync(key, Newtonsoft.Json.JsonConvert.SerializeObject(value), options);
        }

        public static async Task<T> GetAsync<T>(this IDistributedCache cache, string key) where T : class
        {
            //var val = await cache.GetAsync(key);

            //return val == null
            //    ? null
            //    : BsonSerializer.Deserialize<T>(val);

            var val = await cache.GetStringAsync(key);

            return val == null
                ? null
                : Newtonsoft.Json.JsonConvert.DeserializeObject<T>(val);
        }

        //public static bool TryGet<T>(this IDistributedCache cache, string key, out T value)
        //    where T : class
        //{
        //    var val = cache.Get(key);
        //    value = null;

        //    if (val == null)
        //    {
        //        return false;
        //    }

        //    value = BsonSerializer.Deserialize<T>(val);

        //    return true;
        //}

        public static bool TryGet<T>(this IDistributedCache cache, string key, out T returnValue)
            where T : class
        {
            returnValue = null;
            var val = cache.GetString(key);

            if (val == null)
            {
                return false;
            }

            returnValue = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(val);

            return true;
        }
    }
}