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
    }
}