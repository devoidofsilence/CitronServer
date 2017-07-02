using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CitronWeb.Utils
{
    public static class ParseUtilities
    {
        public static string NullIfEmptyString(this string str)
        {
            return string.IsNullOrEmpty(str) ? null : str;
        }

        public static int? NullIntIfEmptyString(this string str)
        {
            return string.IsNullOrEmpty(str) ? (int?)null : int.Parse(str);
        }

        public static DateTime? NullDateIfEmptyString(this string str)
        {
            return string.IsNullOrEmpty(str) ? (DateTime?)null : Convert.ToDateTime(str);
        }

        public static string DateToString(this DateTime? date)
        {
            try
            {
                return date != null ? Convert.ToDateTime(date).ToString("yyyy/MM/dd") : null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}