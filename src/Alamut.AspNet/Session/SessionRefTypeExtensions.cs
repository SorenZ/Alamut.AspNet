using System;
using MessagePack;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Alamut.AspNet.Session
{
    public static class SessionRefTypeExtensions
    {

        public static void Set<T>(this ISession session, string key, T value) where T : class =>
            session.Set(key,
                MessagePackSerializer.Serialize(value,
                    MessagePack.Resolvers.ContractlessStandardResolver.Instance));

        // Newtonsoft.Json version
        // public static void Set<T>(this ISession session, string key, T value) where T : class
        // {

        //     session.SetString(key, JsonConvert.SerializeObject(value));

        //     // https://stackoverflow.com/questions/4865104/convert-any-object-to-a-byte/4865123
        //     // https://stackoverflow.com/questions/1446547/how-to-convert-an-object-to-a-byte-array-in-c-sharp
        // }

        public static T Get<T>(this ISession session, string key) where T : class
        {
            if (session.TryGetValue(key, out var value))
            {
                return MessagePackSerializer.Deserialize<T>(value, MessagePack.Resolvers.ContractlessStandardResolver.Instance);
            }

            return null;
        }

        // Newtonsoft.Json version
        // public static T Get<T>(this ISession session, string key) where T : class
        // {
        //     var value = session.GetString(key);

        //     return (value == null)
        //         ? null
        //         : JsonConvert.DeserializeObject<T>(value);
        //     // https://stackoverflow.com/questions/4865104/convert-any-object-to-a-byte/4865123
        // }
    }
}