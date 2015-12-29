using System;
using System.Collections.Generic;
using System.Collections;
using static System.Diagnostics.Debug;

namespace VideoTC.src.extensions
{
    public static class TEnumerableExtensions
    {
        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumerable, Action<T> callback)
        {
            Assert(enumerable != null, "enumerable != null");
            var each = new List<T>();
            foreach (var item in enumerable)
            {
                callback(item);
                each.Add(item);
            }
            return each;
        }

        /// <exception cref="Exception">A delegate callback throws an exception.</exception>
        public static IEnumerable ForEach(this IEnumerable enumerable, Action<object> callback)
        {
            var each = new List<object>();
            foreach (var item in enumerable)
            {
                callback(item);
                each.Add(item);
            }
            return each;
        }
    }
}
