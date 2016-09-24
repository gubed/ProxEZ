using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LumenWorks.Framework.IO.Csv;
using ProxEZ.Extensions;

namespace ProxEZ.Helpers
{
    class CountryInfo
    {
        private static string[] csv = File.ReadAllLines(Application.StartupPath + "\\GeoIPCountryWhois.csv");
        private static Dictionary<string, string> cc = new Dictionary<string, string>(); 
        public static string[] GetCountryInfo(string ip)
        {
            try
            {
                //var shit = HTTP.DoWebRequest("http://ipinfo.io/" + ip + "/json", new WebProxy(ip, port));
                //using (CachedCsvReader csv = new CachedCsvReader(new StreamReader(Application.StartupPath + "\\GeoIPCountryWhois.csv"), true))
                //{
                //    int fieldCount = csv.FieldCount;

                //    string[] headers = csv.GetFieldHeaders();
                //    while (csv.ReadNextRecord())
                //    {
                //        for (int i = 0; i < fieldCount; i++)
                //            Console.Write(string.Format("{0} = {1};",
                //                          headers[i], csv[i]));
                //        Console.WriteLine();
                //    }
                //    // Field headers will automatically be used as column names
                //    // myDataGrid.DataSource = csv;
                //}
                //foreach (var line in csv)
                //{
                //    string[] split = line.Split(',');
                //    var ipStart = split[0].Replace("\"", "");
                //    var ipEnd = split[1].Replace("\"", "");
                //    var cuntcode = split[4].Replace("\"", "").ToLower();
                //    var cunt = split[5].Replace("\"", "");

                //    if (IsInRange(ipStart, ipEnd, p))
                //        return new [] {cuntcode, cunt};

                //}
                return new[] {"xx", "Unknown"};

            }
            catch (Exception ex)
            {

                return new[] { "xx", "Unknown" };
            }
        }

        public static string GetCode(string cunttree)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cunttree)) return "xx";
                foreach (var line in csv)
                {
                    string[] split = line.Split(',');
                    var cuntcode = split[4].Replace("\"", "").ToLower();
                    var cunt = split[5].Replace("\"", "");

                    if (cunt.Contains(cunttree))
                        return cuntcode;


                }
                return "xx";

            }
            catch (Exception ex)
            {

                return "xx";
            }
        }
        private static bool IsInRange(string startIpAddr, string endIpAddr, string address)
        {
            long ipStart = BitConverter.ToInt32(IPAddress.Parse(startIpAddr).GetAddressBytes().Reverse().ToArray(), 0);

            long ipEnd = BitConverter.ToInt32(IPAddress.Parse(endIpAddr).GetAddressBytes().Reverse().ToArray(), 0);

            long ip = BitConverter.ToInt32(IPAddress.Parse(address).GetAddressBytes().Reverse().ToArray(), 0);

            return ip >= ipStart && ip <= ipEnd; //edited
        }
    }
}
