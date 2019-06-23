using Alamut.AspNet.Test.Helpers;
using Microsoft.AspNetCore.Http;
using Xunit;
using Alamut.AspNet.Session;

namespace Alamut.AspNet.Test
{
    public class AspNetRefTypeSessionExtensionsTest
    {
        private readonly ISession _session;

        public AspNetRefTypeSessionExtensionsTest()
        {
            _session = new MockSession();
        }

        [Fact]
        public void RefType_Basic_Get_Set()
        {
            // arrange
            const string key = "basic-test";
            var expected = new RefTypeObject
            {
                foo = 1,
                bar = "test"
            };
            _session.Set(key, expected);

            // act
            var actual = _session.Get<RefTypeObject>(key);

            // assert
            Assert.Equal(expected, actual);
        }
    }
}