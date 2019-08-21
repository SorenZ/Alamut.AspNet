using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.Caching.Distributed;

namespace Alamut.Extensions.Caching.Distributed
{
    /// <summary>
    /// implements missed distributed cache methods for ValueTypes with the help of MemoryStream
    /// </summary>
    public static class DistributedCacheValueTypeExtensions
    {

        public static async Task SetAsync(this IDistributedCache cache, string key, bool value,
            DistributedCacheEntryOptions options, CancellationToken token = default) => 
            await cache.SetAsync(key, BitConverter.GetBytes(value), options, token);

        public static async Task<bool?> GetBoolAsync(this IDistributedCache cache, string key, 
            CancellationToken token = default)
        {
            byte[] bytes = await cache.GetAsync(key, token);
            
            return (bytes == null) 
                ? (bool?)null
                : BitConverter.ToBoolean(bytes,0);
        }

        public static async Task SetAsync(this IDistributedCache cache, string key, char value,
            DistributedCacheEntryOptions options, CancellationToken token = default) => 
            await cache.SetAsync(key, BitConverter.GetBytes(value), options, token);

        public static async Task<char?> GetCharAsync(this IDistributedCache cache, string key, 
            CancellationToken token = default)
        {
            byte[] bytes = await cache.GetAsync(key, token);
            
            return (bytes == null) 
                ? (char?)null
                : BitConverter.ToChar(bytes,0);
        }

        public static async Task SetAsync(this IDistributedCache cache, string key, double value,
            DistributedCacheEntryOptions options, CancellationToken token = default) => 
            await cache.SetAsync(key, BitConverter.GetBytes(value), options, token);

        public static async Task<double?> GetDoubleAsync(this IDistributedCache cache, string key, 
            CancellationToken token = default)
        {
            byte[] bytes = await cache.GetAsync(key, token);
            
            return (bytes == null) 
                ? (double?)null
                : BitConverter.ToDouble(bytes,0);
        }

        public static async Task SetAsync(this IDistributedCache cache, string key, short value,
            DistributedCacheEntryOptions options, CancellationToken token = default) => 
            await cache.SetAsync(key, BitConverter.GetBytes(value), options, token);

        public static async Task<short?> GetShortAsync(this IDistributedCache cache, string key, 
            CancellationToken token = default)
        {
            byte[] bytes = await cache.GetAsync(key, token);
            
            return (bytes == null) 
                ? (short?)null
                : BitConverter.ToInt16(bytes,0);
        }

        public static async Task SetAsync(this IDistributedCache cache, string key, int value,
            DistributedCacheEntryOptions options, CancellationToken token = default) => 
            await cache.SetAsync(key, BitConverter.GetBytes(value), options, token);

        public static async Task<int?> GetIntAsync(this IDistributedCache cache, string key, 
            CancellationToken token = default)
        {
            byte[] bytes = await cache.GetAsync(key, token);
            
            return (bytes == null) 
                ? (int?)null
                : BitConverter.ToInt32(bytes,0);
        }

        public static async Task SetAsync(this IDistributedCache cache, string key, long value,
            DistributedCacheEntryOptions options, CancellationToken token = default) => 
            await cache.SetAsync(key, BitConverter.GetBytes(value), options, token);

        public static async Task<long?> GetLongAsync(this IDistributedCache cache, string key, 
            CancellationToken token = default)
        {
            byte[] bytes = await cache.GetAsync(key, token);
            
            return (bytes == null) 
                ? (long?)null
                : BitConverter.ToInt64(bytes,0);
        }

        public static async Task SetAsync(this IDistributedCache cache, string key, float value,
            DistributedCacheEntryOptions options, CancellationToken token = default) => 
            await cache.SetAsync(key, BitConverter.GetBytes(value), options, token);

        public static async Task<float?> GetFloatAsync(this IDistributedCache cache, string key, 
            CancellationToken token = default)
        {
            byte[] bytes = await cache.GetAsync(key, token);
            
            return (bytes == null) 
                ? (float?)null
                : BitConverter.ToSingle(bytes,0);
        }

        public static async Task SetAsync(this IDistributedCache cache, string key, ushort value,
            DistributedCacheEntryOptions options, CancellationToken token = default) => 
            await cache.SetAsync(key, BitConverter.GetBytes(value), options, token);

        public static async Task<ushort?> GetUShortAsync(this IDistributedCache cache, string key, 
            CancellationToken token = default)
        {
            byte[] bytes = await cache.GetAsync(key, token);
            
            return (bytes == null) 
                ? (ushort?)null
                : BitConverter.ToUInt16(bytes,0);
        }

        public static async Task SetAsync(this IDistributedCache cache, string key, uint value,
            DistributedCacheEntryOptions options, CancellationToken token = default) => 
            await cache.SetAsync(key, BitConverter.GetBytes(value), options, token);

        public static async Task<uint?> GetUIntAsync(this IDistributedCache cache, string key, 
            CancellationToken token = default)
        {
            byte[] bytes = await cache.GetAsync(key, token);
            
            return (bytes == null) 
                ? (uint?)null
                : BitConverter.ToUInt32(bytes,0);
        }

        public static async Task SetAsync(this IDistributedCache cache, string key, ulong value,
            DistributedCacheEntryOptions options, CancellationToken token = default) => 
            await cache.SetAsync(key, BitConverter.GetBytes(value), options, token);

        public static async Task<ulong?> GetULongAsync(this IDistributedCache cache, string key, 
            CancellationToken token = default)
        {
            byte[] bytes = await cache.GetAsync(key, token);
            
            return (bytes == null) 
                ? (ulong?)null
                : BitConverter.ToUInt64(bytes,0);
        }

        public static async Task SetAsync(this IDistributedCache cache, string key, DateTime value,
            DistributedCacheEntryOptions options, CancellationToken token = default) => 
            await cache.SetAsync(key, BitConverter.GetBytes(value.Ticks), options, token);

        public static async Task<DateTime?> GetDateTimeAsync(this IDistributedCache cache, string key, 
            CancellationToken token = default)
        {
            byte[] bytes = await cache.GetAsync(key, token);
            
            return (bytes == null) 
                ? (DateTime?)null
                : new DateTime(BitConverter.ToInt64(bytes,0));
        }
    }
}