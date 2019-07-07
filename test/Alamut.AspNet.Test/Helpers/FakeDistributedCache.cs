using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace Alamut.AspNet.Test.Helpers
{
    public class FakeDistributedCache : IDistributedCache
    {
        private readonly Dictionary<string, byte[]> storage = new Dictionary<string, byte[]>();

        public byte[] Get(string key)
        {
            return storage[key];
        }

        public Task<byte[]> GetAsync(string key, CancellationToken token = default)
        {
            return Task.FromResult(storage[key]);
        }

        public void Refresh(string key)
        {
            throw new System.NotImplementedException();
        }

        public Task RefreshAsync(string key, CancellationToken token = default)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(string key)
        {
            storage.Remove(key);
        }

        public Task RemoveAsync(string key, CancellationToken token = default)
        {
            storage.Remove(key);
            return Task.CompletedTask;
        }

        public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
        {
            storage[key] = value;
        }

        public Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options, CancellationToken token = default)
        {
            storage[key] = value;
            return Task.CompletedTask;
        }
    }
}