using System;
using Microsoft.AspNetCore.Http;

using Xunit;
using Alamut.Extensions.Session.Test.Helpers;

namespace Alamut.Extensions.Session.Test
{
    public class AspNetRefTypeSessionExtensionsTest
    {
        private readonly ISession _session;

        public AspNetRefTypeSessionExtensionsTest()
        {
            _session = new FakeSession();
        }

        [Fact]
        public void RefType_Basic_Get_Set()
        {
            // arrange
            const string key = "basic-test";
            var expected = new RefTypeObject
            {
                foo = 1,
                bar = "test",
                Created = DateTime.UtcNow
            };
            _session.Set(key, expected);

            // act
            var actual = _session.Get<RefTypeObject>(key);

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RefValue_TryGetValue()
        {
            //Given
            const string key = "tryGetValue-test";
            var expected = new RefTypeObject
            {
                foo = 1,
                bar = "test",
                Created = DateTime.UtcNow
            };
            _session.Set(key, expected);

            //When
            var result = _session.TryGetValue<RefTypeObject>(key, out var actual);

            //Then
            Assert.True(result);
            Assert.Equal(expected, actual);
        }
    }
}