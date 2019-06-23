using Alamut.AspNet.Test.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Alamut.AspNet.Session;
using System;

namespace Alamut.AspNet.Test
{
    public class AspNetValueTypeSessionExtensionsTests
    {
        private readonly ISession _session;

        public AspNetValueTypeSessionExtensionsTests()
        {
            _session = new MockSession();
        }

        [Fact]
        public void ValueType_SessionExtensions_Get_and_Set_Value()
        {
            // arrange 
            var key = "foo-value";
            var expected = "bar";

            // act
            _session.SetString(key, expected);
            var actual = _session.GetString(key);

            // assert 
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValueType_SessionExtensions_Get_Null_on_NotFound()
        {
            // arrange 
            var key = "foo-notfount";
            // var expected = null;

            // act
            _session.Set(key, true);
            var actual = _session.GetBool("not_Exist_Key");

            // assert 
            Assert.Null(actual);
        }

        [Fact]
        public void ValueType_SessionExtensions_Get_and_Set_Bool()
        {
            // arrange 
            var key = "foo-bool";
            var expected = true;

            // act
            _session.Set(key, expected);
            var actual = _session.GetBool(key);

            // assert 
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValueType_SessionExtensions_Get_and_Set_Char()
        {
            // arrange 
            var key = "foo-char";
            var expected = 'c';

            // act
            _session.Set(key, expected);
            var actual = _session.GetChar(key);

            // assert 
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValueType_SessionExtensions_Get_and_Set_Double()
        {
            // arrange 
            var key = "foo-double";
            var expected = double.MaxValue;

            // act
            _session.Set(key, expected);
            var actual = _session.GetDouble(key);

            // assert 
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValueType_SessionExtensions_Get_and_Set_Short()
        {
            // arrange 
            var key = "foo-short";
            var expected = short.MaxValue;

            // act
            _session.Set(key, expected);
            var actual = _session.GetShort(key);

            // assert 
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValueType_SessionExtensions_Get_and_Set_Int()
        {
            // arrange 
            var key = "foo-int";
            var expected = int.MaxValue;

            // act
            _session.Set(key, expected);
            var actual = _session.GetInt(key);

            // assert 
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValueType_SessionExtensions_Get_and_Set_Long()
        {
            // arrange 
            var key = "foo-long";
            var expected = long.MaxValue;

            // act
            _session.Set(key, expected);
            var actual = _session.GetLong(key);

            // assert 
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValueType_SessionExtensions_Get_and_Set_Float()
        {
            // arrange 
            var key = "foo-float";
            var expected = float.MaxValue;

            // act
            _session.Set(key, expected);
            var actual = _session.GetFloat(key);

            // assert 
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValueType_SessionExtensions_Get_and_Set_UShort()
        {
            // arrange 
            var key = "foo-ushort";
            var expected = ushort.MaxValue;

            // act
            _session.Set(key, expected);
            var actual = _session.GetUShort(key);

            // assert 
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValueType_SessionExtensions_Get_and_Set_UInt()
        {
            // arrange 
            var key = "foo-uint";
            var expected = uint.MaxValue;

            // act
            _session.Set(key, expected);
            var actual = _session.GetUInt(key);

            // assert 
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValueType_SessionExtensions_Get_and_Set_ULong()
        {
            // arrange 
            var key = "foo-ulong";
            var expected = ulong.MaxValue;

            // act
            _session.Set(key, expected);
            var actual = _session.GetULong(key);

            // assert 
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ValueType_SessionExtensions_Get_and_Set_DateTime()
        {
            // arrange 
            var key = "foo-datetime";
            var expected = DateTime.Now;

            // act
            _session.Set(key, expected);
            var actual = _session.GetDateTime(key);

            // assert 
            Assert.Equal(expected, actual);
        }
    }
}