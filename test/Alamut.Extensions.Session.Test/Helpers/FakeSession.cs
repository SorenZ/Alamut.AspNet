using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Alamut.Extensions.Session.Test.Helpers
{
    public class FakeSession : ISession
    {
        private readonly Dictionary<string,byte[]> _storage = new Dictionary<string, byte[]>();

        public bool IsAvailable => throw new System.NotImplementedException();

        public string Id => throw new System.NotImplementedException();

        public IEnumerable<string> Keys => _storage.Keys;

        public void Clear()
        {
            _storage.Clear();
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
            _storage.Remove(key);
        }

        public void Set(string key, byte[] value)
        {
            _storage.Add(key,value);
        }

        public bool TryGetValue(string key, out byte[] value)
        {
            return _storage.TryGetValue(key, out value);
        }
    }
}