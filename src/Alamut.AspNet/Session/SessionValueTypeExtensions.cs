using System;
using Microsoft.AspNetCore.Http;

namespace Alamut.Utilities.AspNet.Session
{
    /// <summary>
    /// provide ASP.NET Core session helpers to save and retrieve value types
    /// </summary>
    public static class SessionValueTypeExtensions 
    {

        /// <summary>
        /// Set the given key and value (only value-type) in the current session
        /// </summary>
        /// <param name="session"></param>
        /// <param name="key">the session key</param>
        /// <param name="value">the session value</param>
        public static void Set(this ISession session, string key, object value)
        {
            switch (value)
                {
                    case bool v:
                    session.Set(key, BitConverter.GetBytes(v));
                    return;

                    case char v:
                    session.Set(key, BitConverter.GetBytes(v));
                    return;

                    case double v:
                    session.Set(key, BitConverter.GetBytes(v));
                    return;

                    case short v:
                    session.Set(key, BitConverter.GetBytes(v));
                    return;

                    case int v:
                    session.Set(key, BitConverter.GetBytes(v));
                    return;

                    case long v:
                    session.Set(key, BitConverter.GetBytes(v));
                    return;

                    case float v:
                    session.Set(key, BitConverter.GetBytes(v));
                    return;

                    case ushort v:
                    session.Set(key, BitConverter.GetBytes(v));
                    return;

                    case uint v:
                    session.Set(key, BitConverter.GetBytes(v));
                    return;

                    case ulong v:
                    session.Set(key, BitConverter.GetBytes(v));
                    return;

                    case DateTime v:
                    session.Set(key, BitConverter.GetBytes(v.Ticks));
                    return;

                    default:
                        throw new NotSupportedException($"value {value} of type {value.GetType()} does not supported :'(");
                }
        }

        /// <summary>
        /// Retrieve the value of the given key, if present.
        /// otherwise, return null
        /// </summary>
        public static bool? GetBool(this ISession session, string key) => 
            session.TryGetValue(key, out byte[] value)
                ? BitConverter.ToBoolean(value, 0)
                : (bool?)null;

        /// <summary>
        /// Retrieve the value of the given key, if present.
        /// otherwise, return null
        /// </summary>
        public static char? GetChar(this ISession session, string key) => 
            session.TryGetValue(key, out byte[] value)
                ? BitConverter.ToChar(value, 0)
                : (char?)null;

        /// <summary>
        /// Retrieve the value of the given key, if present.
        /// otherwise, return null
        /// </summary>
         public static double? GetDouble(this ISession session, string key) => 
            session.TryGetValue(key, out byte[] value)
                ? BitConverter.ToDouble(value, 0)
                : (double?)null;

        /// <summary>
        /// Retrieve the value of the given key, if present.
        /// otherwise, return null
        /// </summary>
        public static short? GetShort(this ISession session, string key) => 
            session.TryGetValue(key, out byte[] value)
                ? BitConverter.ToInt16(value, 0)
                : (short?)null;

        /// <summary>
        /// Retrieve the value of the given key, if present.
        /// otherwise, return null
        /// </summary>
        public static int? GetInt(this ISession session, string key) => 
            session.TryGetValue(key, out byte[] value)
                ? BitConverter.ToInt32(value, 0)
                : (int?)null;

        /// <summary>
        /// Retrieve the value of the given key, if present.
        /// otherwise, return null
        /// </summary>
        public static long? GetLong(this ISession session, string key) => 
            session.TryGetValue(key, out byte[] value)
                ? BitConverter.ToInt64(value, 0)
                : (long?)null;

        /// <summary>
        /// Retrieve the value of the given key, if present.
        /// otherwise, return null
        /// </summary>
        public static float? GetFloat(this ISession session, string key) => 
            session.TryGetValue(key, out byte[] value)
                ? BitConverter.ToSingle(value, 0)
                : (float?)null;

        /// <summary>
        /// Retrieve the value of the given key, if present.
        /// otherwise, return null
        /// </summary>
        public static ushort? GetUShort(this ISession session, string key) => 
            session.TryGetValue(key, out byte[] value)
                ? BitConverter.ToUInt16(value, 0)
                : (ushort?)null;
        
        /// <summary>
        /// Retrieve the value of the given key, if present.
        /// otherwise, return null
        /// </summary>
        public static uint? GetUInt(this ISession session, string key) => 
            session.TryGetValue(key, out byte[] value)
                ? BitConverter.ToUInt32(value, 0)
                : (uint?)null;

        /// <summary>
        /// Retrieve the value of the given key, if present.
        /// otherwise, return null
        /// </summary>
        public static ulong? GetULong(this ISession session, string key) => 
            session.TryGetValue(key, out byte[] value)
                ? BitConverter.ToUInt64(value, 0)
                : (ulong?)null;

        /// <summary>
        /// Retrieve the value of the given key, if present.
        /// otherwise, return null
        /// </summary>
        public static DateTime? GetDateTime(this ISession session, string key) =>
            session.TryGetValue(key, out byte[] value)
                ? new DateTime(BitConverter.ToInt64(value, 0))
                : (DateTime?)null;
    }
}