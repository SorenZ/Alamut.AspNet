using System;
using Alamut.AspNet.Test.Helpers;
using Microsoft.Extensions.Caching.Distributed;
using Alamut.AspNet.Caching;
using System.Threading.Tasks;
using Xunit;

namespace Alamut.AspNet.Test
{
    public class DistributedCacheHelperExtensionsTests
    {
        private readonly IDistributedCache _cache;

        public DistributedCacheHelperExtensionsTests()
        {
            _cache = new FakeDistributedCache();
        }

        [Fact]
        public void GetOrCreate_Test()
        {
            // arrange
            const string key = "GetOrCreate_Test";
            var expected = new RefTypeObject
            {
                foo = 1,
                bar = "test", 
                Created = DateTime.UtcNow
            };
            Func<RefTypeObject> factory = () =>
            {
                return expected;
            };

            // act
            var cacheResult = _cache.GetOrCreate(key, factory);

            // assert
            Assert.Equal(expected, cacheResult);
            Assert.Equal(expected, _cache.Get<RefTypeObject>(key));
            
        }

        [Fact]
        public async void GetOrCreateAsync_Test()
        {
            // arrange
            const string key = "GetOrCreateAsync_Test";
            var expected = new RefTypeObject
            {
                foo = 1,
                bar = "test", 
                Created = DateTime.UtcNow
            };
            Func<Task<RefTypeObject>> factory = () =>
            {
                return Task.FromResult(expected);
            };

            // act
            var cacheResult = await _cache.GetOrCreateAsync(key, factory);

            // assert
            Assert.Equal(expected, cacheResult);
            Assert.Equal(expected, _cache.Get<RefTypeObject>(key));
            
        }
    }
}