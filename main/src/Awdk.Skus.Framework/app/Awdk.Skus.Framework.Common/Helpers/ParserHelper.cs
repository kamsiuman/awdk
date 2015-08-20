using System;
using System.Globalization;

namespace Awdk.Skus.Framework.Common.Helpers
{
    public static class ParseHelper
    {
        public static int ParseStringToIntInvariant(string intValueString)
        {
            return int.Parse(intValueString, CultureInfo.InvariantCulture);
        }

        public static string FormatInvariant(this string format, params Object[] args)
        {
            return string.Format(CultureInfo.InvariantCulture, format, args);
        }
    }
}
