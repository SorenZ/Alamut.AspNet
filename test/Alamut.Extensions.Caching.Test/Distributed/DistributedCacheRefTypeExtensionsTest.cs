using System;
using Alamut.Extensions.Caching.Test.Helpers;
using Microsoft.Extensions.Caching.Distributed;
using Xunit;
using Alamut.Extensions.Caching.Distributed;


namespace Alamut.Extensions.Caching.Test.Distributed
{
    public class DistributedCacheRefTypeExtensionsTest
    {
        private readonly IDistributedCache _cache;

        public DistributedCacheRefTypeExtensionsTest()
        {
            _cache = new FakeDistributedCache();
        }

        [Fact]
        public void RefTypeExtensions_SyncMethodSet_GetExpected()
        {
            // arrange
            const string key = "RefType_Sync_Get_Set";
            var expected = new RefTypeObject
            {
                foo = 1,
                bar = "test",
                Created = DateTime.Now
            };
            _cache.Set(key, expected, new DistributedCacheEntryOptions());

            // act
            var actual = _cache.Get<RefTypeObject>(key);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void RefTypeExtensions_ASyncMethodSet_GetExpected()
        {
            // arrange
            const string key = "RefType_ASync_Get_Set";
            var expected = new RefTypeObject
            {
                foo = 1,
                bar = "test",
                Created = DateTime.Now
            };
            await _cache.SetAsync(key, expected, new DistributedCacheEntryOptions());

            // act
            var actual = await _cache.GetAsync<RefTypeObject>(key);

            // assert
            Assert.Equal(expected, actual);
        }
    }
}