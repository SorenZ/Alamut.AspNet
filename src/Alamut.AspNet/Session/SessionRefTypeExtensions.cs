using System;
using MessagePack;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Alamut.AspNet.Session
{
    public static class SessionRefTypeExtensions
    {

        public static void Set<T>(this ISession session, string key, T value) =>
            session.Set(key,
                MessagePackSerializer.Serialize(value,
                    MessagePack.Resolvers.ContractlessStandardResolver.Instance));

        public static T Get<T>(this ISession session, string key) 
        {
            if (session.TryGetValue(key, out var value))
            {
                return MessagePackSerializer.Deserialize<T>(value, MessagePack.Resolvers.ContractlessStandardResolver.Instance);
            }

            return default(T);
        }

        public static bool TryGetValue<T>(this ISession session, string key, out T value) 
        {
            if (session.TryGetValue(key, out var internalValue))
            {
                value = MessagePackSerializer.Deserialize<T>(internalValue, MessagePack.Resolvers.ContractlessStandardResolver.Instance);
                return true;
            }

            value = default(T);
            return false;
        }
    }
}