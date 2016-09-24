using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProxEZ.Scraper
{
    class Utils
    {
        public static string FindIP2(string text)
        {
            Match m = Regex.Match(text, @"(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})(?=[^\d])\s*:?\s*(\d{1,5})");
            if (!m.Success) return null;
            return m.Value;
        }
        public static string FindIP(string text)
        {
            try
            {

                int maxLength = "255.255.255.255".Length;
                int minLength = "2.2.2.2".Length;
                var last = string.Empty;
                for (int i = 0; i < text.Length; i++)
                {
                    for (int j = minLength; j < maxLength; j++)
                    {
                        if ((i + j) > text.Length) break;
                        var attempt = text.Substring(i, j);
                        if (Regex.IsMatch(attempt, @"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$",
                            RegexOptions.IgnoreCase))
                        {
                            last = attempt;
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(last))
                                return last;
                        }
                    }
                }
                return last;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string GetCuntry(string entry, string ip, string port)
        {
            try
            {
                int comma = entry.IndexOf(',');
                if (comma != -1)
                    entry = entry.Substring(0, comma);
                var cunts = GetCountryList();
                var c = entry.Substring(entry.IndexOf(ip));
                if (cunts.Contains(c)) return c;

                int x = entry.IndexOf(port);
                c = entry.Substring(x + port.Length);
                if (cunts.Contains(c)) return c;
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }
        public static List<string> GetCountryList()
        {
            List<string> cultureList = new List<string>();

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo culture in cultures)
            {
                RegionInfo region = new RegionInfo(culture.LCID);

                if (!(cultureList.Contains(region.Name)))
                {
                    cultureList.Add(region.EnglishName);
                    cultureList.Add(region.Name);

                    cultureList.Add(region.NativeName);
                }
            }
            return cultureList;
        }
    }
}
