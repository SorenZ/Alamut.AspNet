using System;
using Alamut.AspNet.Test.Helpers;
using Microsoft.Extensions.Caching.Distributed;
using Xunit;
using Alamut.AspNet.Caching;

namespace Alamut.AspNet.Test
{
    public class DistributedCacheRefTypeExtensionsTest
    {
        private readonly IDistributedCache _cache;

        public DistributedCacheRefTypeExtensionsTest()
        {
            _cache = new FakeDistributedCache();
        }

        [Fact]
        public void RefType_Sync_Get_Set()
        {
            // arrange
            const string key = "RefType_Sync_Get_Set";
            var expected = new RefTypeObject
            {
                foo = 1,
                bar = "test", 
                Created = DateTime.UtcNow
            };
            _cache.Set(key, expected, new DistributedCacheEntryOptions());

            // act
            var actual = _cache.Get<RefTypeObject>(key);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void RefType_ASync_Get_Set()
        {
            // arrange
            const string key = "RefType_ASync_Get_Set";
            var expected = new RefTypeObject
            {
                foo = 1,
                bar = "test", 
                Created = DateTime.UtcNow
            };
            await _cache.SetAsync(key, expected, new DistributedCacheEntryOptions());

            // act
            var actual = await _cache.GetAsync<RefTypeObject>(key);

            // assert
            Assert.Equal(expected, actual);
        }
    }
}