using System;
using Microsoft.AspNetCore.Http;

namespace Alamut.AspNet.Session
{
    /// <summary>
    /// provide ASP.NET Core session helpers to save and retrieve value types
    /// </summary>
    public static class SessionValueTypeExtensions 
    {
        /// <summary>
        /// Set the given key and value in the current session
        /// </summary>
        /// <param name="session"></param>
        /// <param name="key">the session key</param>
        /// <param name="value">the session value</param>
        public static void Set(this ISession session,string key, bool value) =>
            session.Set(key, BitConverter.GetBytes(value));

        /// <summary>
        /// Retrieve the value of the given key, if present.
        /// otherwise, return null
        /// </summary>
        public static bool? GetBool(this ISession session, string key) => 
            session.TryGetValue(key, out byte[] value)
                ? BitConverter.ToBoolean(value, 0)
                : (bool?)null;

        /// <summary>
        /// Set the given key and value in the current session
        /// </summary>
        /// <param name="session"></param>
        /// <param name="key">the session key</param>
        /// <param name="value">the session value</param>
        public static void Set(this ISession session,string key, char value) =>
            session.Set(key, BitConverter.GetBytes(value));

        /// <summary>
        /// Retrieve the value of the given key, if present.
        /// otherwise, return null
        /// </summary>
        public static char? GetChar(this ISession session, string key) => 
            session.TryGetValue(key, out byte[] value)
                ? BitConverter.ToChar(value, 0)
                : (char?)null;

        /// <summary>
        /// Set the given key and value in the current session
        /// </summary>
        /// <param name="session"></param>
        /// <param name="key">the session key</param>
        /// <param name="value">the session value</param>
        public static void Set(this ISession session,string key, double value) =>
            session.Set(key, BitConverter.GetBytes(value));

        /// <summary>
        /// Retrieve the value of the given key, if present.
        /// otherwise, return null
        /// </summary>
         public static double? GetDouble(this ISession session, string key) => 
            session.TryGetValue(key, out byte[] value)
                ? BitConverter.ToDouble(value, 0)
                : (double?)null;

        /// <summary>
        /// Set the given key and value in the current session
        /// </summary>
        /// <param name="session"></param>
        /// <param name="key">the session key</param>
        /// <param name="value">the session value</param>
        public static void Set(this ISession session,string key, short value) =>
            session.Set(key, BitConverter.GetBytes(value));

        /// <summary>
        /// Retrieve the value of the given key, if present.
        /// otherwise, return null
        /// </summary>
        public static short? GetShort(this ISession session, string key) => 
            session.TryGetValue(key, out byte[] value)
                ? BitConverter.ToInt16(value, 0)
                : (short?)null;

        /// <summary>
        /// Set the given key and value in the current session
        /// </summary>
        /// <param name="session"></param>
        /// <param name="key">the session key</param>
        /// <param name="value">the session value</param>
        public static void Set(this ISession session,string key, int value) =>
            session.Set(key, BitConverter.GetBytes(value));

        /// <summary>
        /// Retrieve the value of the given key, if present.
        /// otherwise, return null
        /// </summary>
        public static int? GetInt(this ISession session, string key) => 
            session.TryGetValue(key, out byte[] value)
                ? BitConverter.ToInt32(value, 0)
                : (int?)null;

        /// <summary>
        /// Set the given key and value in the current session
        /// </summary>
        /// <param name="session"></param>
        /// <param name="key">the session key</param>
        /// <param name="value">the session value</param>
        public static void Set(this ISession session,string key, long value) =>
            session.Set(key, BitConverter.GetBytes(value));

        /// <summary>
        /// Retrieve the value of the given key, if present.
        /// otherwise, return null
        /// </summary>
        public static long? GetLong(this ISession session, string key) => 
            session.TryGetValue(key, out byte[] value)
                ? BitConverter.ToInt64(value, 0)
                : (long?)null;

        /// <summary>
        /// Set the given key and value in the current session
        /// </summary>
        /// <param name="session"></param>
        /// <param name="key">the session key</param>
        /// <param name="value">the session value</param>
        public static void Set(this ISession session,string key, float value) =>
            session.Set(key, BitConverter.GetBytes(value));

        /// <summary>
        /// Retrieve the value of the given key, if present.
        /// otherwise, return null
        /// </summary>
        public static float? GetFloat(this ISession session, string key) => 
            session.TryGetValue(key, out byte[] value)
                ? BitConverter.ToSingle(value, 0)
                : (float?)null;

        /// <summary>
        /// Set the given key and value in the current session
        /// </summary>
        /// <param name="session"></param>
        /// <param name="key">the session key</param>
        /// <param name="value">the session value</param>
        public static void Set(this ISession session,string key, ushort value) =>
            session.Set(key, BitConverter.GetBytes(value));

        /// <summary>
        /// Retrieve the value of the given key, if present.
        /// otherwise, return null
        /// </summary>
        public static ushort? GetUShort(this ISession session, string key) => 
            session.TryGetValue(key, out byte[] value)
                ? BitConverter.ToUInt16(value, 0)
                : (ushort?)null;
        
        /// <summary>
        /// Set the given key and value in the current session
        /// </summary>
        /// <param name="session"></param>
        /// <param name="key">the session key</param>
        /// <param name="value">the session value</param>
        public static void Set(this ISession session,string key, uint value) =>
            session.Set(key, BitConverter.GetBytes(value));

        /// <summary>
        /// Retrieve the value of the given key, if present.
        /// otherwise, return null
        /// </summary>
        public static uint? GetUInt(this ISession session, string key) => 
            session.TryGetValue(key, out byte[] value)
                ? BitConverter.ToUInt32(value, 0)
                : (uint?)null;

        /// <summary>
        /// Set the given key and value in the current session
        /// </summary>
        /// <param name="session"></param>
        /// <param name="key">the session key</param>
        /// <param name="value">the session value</param>
        public static void Set(this ISession session,string key, ulong value) =>
            session.Set(key, BitConverter.GetBytes(value));

        /// <summary>
        /// Retrieve the value of the given key, if present.
        /// otherwise, return null
        /// </summary>
        public static ulong? GetULong(this ISession session, string key) => 
            session.TryGetValue(key, out byte[] value)
                ? BitConverter.ToUInt64(value, 0)
                : (ulong?)null;

        /// <summary>
        /// Set the given key and value in the current session
        /// </summary>
        /// <param name="session"></param>
        /// <param name="key">the session key</param>
        /// <param name="value">the session value</param>
        public static void Set(this ISession session,string key, DateTime value) =>
            session.Set(key, BitConverter.GetBytes(value.Ticks));

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