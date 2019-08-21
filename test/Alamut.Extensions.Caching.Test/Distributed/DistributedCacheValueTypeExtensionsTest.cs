using System;
using System.Threading.Tasks;
using Alamut.Extensions.Caching.Test.Helpers;
using Microsoft.Extensions.Caching.Distributed;
using Xunit;
using Alamut.Extensions.Caching.Distributed;


namespace Alamut.Extensions.Caching.Test.Distributed
{
    public class DistributedCacheValueTypeExtensionsTest
    {
        private readonly IDistributedCache _cache;
        private readonly DistributedCacheEntryOptions _option;

        public DistributedCacheValueTypeExtensionsTest()
        {
            _cache = new FakeDistributedCache();
            _option = new DistributedCacheEntryOptions();
        }

        [Fact]
        public async Task DistributedCache_Get_and_Set_BoolAsync()
        {
            // arrange 
            var key = "foo-bool";
            var expected = true;

            // act
            await _cache.SetAsync(key, expected,_option);
            var actual = await _cache.GetBoolAsync(key);

            // assert 
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task DistributedCache_Get_and_Set_CharAsync()
        {
            // arrange 
            var key = "foo-char";
            var expected = 'c';

            // act
           await _cache.SetAsync(key, expected,_option);
           var actual = await _cache.GetCharAsync(key);

            // assert 
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task DistributedCache_Get_and_Set_DoubleAsync()
        {
            // arrange 
            var key = "foo-double";
            var expected = double.MaxValue;

            // act
            await _cache.SetAsync(key, expected,_option);
            var actual = await _cache.GetDoubleAsync(key);

            // assert 
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task DistributedCache_Get_and_Set_ShortAsync()
        {
            // arrange 
            var key = "foo-short";
            var expected = short.MaxValue;

            // act
            await _cache.SetAsync(key, expected,_option);
            var actual = await _cache.GetShortAsync(key);

            // assert 
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task DistributedCache_Get_and_Set_IntAsync()
        {
            // arrange 
            var key = "foo-int";
            var expected = int.MaxValue;

            // act
            await _cache.SetAsync(key, expected,_option);
            var actual = await _cache.GetIntAsync(key);

            // assert 
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task DistributedCache_Get_and_Set_LongAsync()
        {
            // arrange 
            var key = "foo-long";
            var expected = long.MaxValue;

            // act
            await _cache.SetAsync(key, expected,_option);
            var actual = await _cache.GetLongAsync(key);


            // assert 
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task DistributedCache_Get_and_Set_FloatAsync()
        {
            // arrange 
            var key = "foo-float";
            var expected = float.MaxValue;

            // act
            await _cache.SetAsync(key, expected,_option);
            var actual = await _cache.GetFloatAsync(key);

            // assert 
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task DistributedCache_Get_and_Set_UShortAsync()
        {
            // arrange 
            var key = "foo-ushort";
            var expected = ushort.MaxValue;

            // act
            await _cache.SetAsync(key, expected,_option);
            var actual = await _cache.GetUShortAsync(key);

            // assert 
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task DistributedCache_Get_and_Set_UIntAsync()
        {
            // arrange 
            var key = "foo-uint";
            var expected = uint.MaxValue;

            // act
            await _cache.SetAsync(key, expected,_option);
            var actual = await _cache.GetUIntAsync(key);

            // assert 
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task DistributedCache_Get_and_Set_ULongAsync()
        {
            // arrange 
            var key = "foo-ulong";
            var expected = ulong.MaxValue;

            // act
            await _cache.SetAsync(key, expected,_option);
            var actual = await _cache.GetULongAsync(key);

            // assert 
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task DistributedCache_Get_and_Set_DateTimeAsync()
        {
            // arrange 
            var key = "foo-datetime";
            var expected = DateTime.Now;

            // act
            await _cache.SetAsync(key, expected,_option);
            var actual = await _cache.GetDateTimeAsync(key);

            // assert 
            Assert.Equal(expected, actual);
        }
    }
}