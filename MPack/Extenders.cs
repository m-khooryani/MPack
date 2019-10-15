using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace MPack
{
    public static class Extenders
    {
        public static bool IsNonStringEnumerable(this PropertyInfo pi)
        {
            return pi != null && pi.PropertyType.IsNonStringEnumerable();
        }

        public static bool IsNonStringEnumerable(this object instance)
        {
            return instance != null && instance.GetType().IsNonStringEnumerable();
        }

        public static bool IsNonStringEnumerable(this Type type)
        {
            if (type == null /*|| type == typeof(string)*/)
                return false;
            return typeof(IEnumerable).IsAssignableFrom(type) ||
                typeof(IEnumerable<>).IsAssignableFrom(type);
        }

        public static bool IsKeyValueCollection(this Type type)
        {
            if (type == null /*|| type == typeof(string)*/)
                return false;
            return typeof(IDictionary).IsAssignableFrom(type) ||
                typeof(IDictionary<,>).IsAssignableFrom(type);
        }
    }
}
