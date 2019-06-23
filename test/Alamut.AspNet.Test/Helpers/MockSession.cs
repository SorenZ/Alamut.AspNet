using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Alamut.Utilities.AspNet.Test.Helpers
{
    public class MockSession : ISession
    {
        private readonly Dictionary<string,byte[]> storage = new Dictionary<string, byte[]>();

        public bool IsAvailable => throw new System.NotImplementedException();

        public string Id => throw new System.NotImplementedException();

        public IEnumerable<string> Keys => storage.Keys;

        public void Clear()
        {
            storage.Clear();
        }

        public Task CommitAsync(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task LoadAsync(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(string key)
        {
            storage.Remove(key);
        }

        public void Set(string key, byte[] value)
        {
            storage.Add(key,value);
        }

        public bool TryGetValue(string key, out byte[] value)
        {
            return storage.TryGetValue(key, out value);
        }
    }
}