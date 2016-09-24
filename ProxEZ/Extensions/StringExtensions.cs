using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProxEZ.Extensions
{
    public static class StringExtensions
    {
        public static string GetBetween(this string strSource, string strStart, string strEnd)
        {
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                var Start = strSource.IndexOf(strStart, 0, StringComparison.Ordinal) + strStart.Length;
                var End = strSource.IndexOf(strEnd, Start, StringComparison.Ordinal);
                return strSource.Substring(Start, End - Start);
            }
            return string.Empty;
        }

        public static string StripHTML(this string input)
        {
            return Regex.Replace(input, "<.*?>", string.Empty);
        }

        public static bool IsNullOrEmpty(this string text)
        {
            return string.IsNullOrEmpty(text);
        }

        public static bool IsNullOrWhiteSpace(this string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }

        public static bool RegexIsMatch(this string text, string regex, RegexOptions op = RegexOptions.IgnoreCase)
        {
            return new Regex(regex, op).IsMatch(text);
        }

        public static Match RegexMatch(this string text, string regex)
        {
            return new Regex(regex).Match(text);
        }

        public static string TitleCase(this string a)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(a.ToLower());
        }
    }
}
