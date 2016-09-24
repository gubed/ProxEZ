using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProxEZ.Extensions;
using ProxEZ.Helpers;

namespace ProxEZ.Checker
{
    class Checker
    {
        public static bool IsValid(string ip, int port)
        {
            return (ip + ":" + port).RegexIsMatch(@"(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})(?=[^\d])\s*:?\s*(\d{2,5})") && (port > 0 && port <= 65535);
        }
        public static ProxyResult Check(WebProxy p, int port, string sslURL= "", string cURL = "")
        {
            object[] result = ProxyCheck("http://azenv.net/", p);

            if (result == null)
                return new ProxyResult(false, "", new []{"",""}, 0, false, false);


            var lvl = GetLevel(result[0] as string, port);
            object[] ssl = null;
            object[] custom = null;
            if (!string.IsNullOrWhiteSpace(sslURL))
                ssl = ProxyCheck(sslURL, p);

            if (!string.IsNullOrWhiteSpace(cURL))
                custom = ProxyCheck(cURL, p);



            return new ProxyResult(true, lvl.ToString(), 
                CountryInfo.GetCountryInfo(p.Address.ToString().RegexMatch(@"http:\/\/(.*?)(\/|:)").Groups[1].Value), 
                (long)result[1], 
                ssl != null, 
                custom != null
            );

        }


        private static object[] ProxyCheck(string url, WebProxy wp)
        {
            try
            {
                Stopwatch s = new Stopwatch();
                
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url.Trim());
                httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.111 Safari/537.36";
                httpWebRequest.Timeout = 10000;
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                httpWebRequest.KeepAlive = false;
                httpWebRequest.Proxy = wp;
                httpWebRequest.Method = "GET";
                s.Start();
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                s.Stop();
                if (httpWebResponse.StatusCode != HttpStatusCode.OK) return null;

                Stream responseStream = httpWebResponse.GetResponseStream();
                StreamReader streamReader;
                if (httpWebResponse.CharacterSet == null)
                    streamReader = new StreamReader(responseStream);
                else
                    streamReader = new StreamReader(responseStream,
                        Encoding.GetEncoding(httpWebResponse.CharacterSet));
                string output = streamReader.ReadToEnd();
                    
                httpWebResponse.Close();
                streamReader.Close();

                return new object[] { output, s.ElapsedMilliseconds };
            }
            catch (Exception)
            {
                return null;
            }

        }
        [Flags]
        private enum ProxyLevel
        {
            All,
            Transparent,
            High_Elite,
            Elite,
            Anonymous
        }
        private static List<string> SuspiciousHeaders = new List<string> {
            "HTTP_USER_AGENT",
            "HTTP_ACCEPT", "REQUEST_METHOD",
            "X_FORWARD_FOR", "HTTP_PROXY_CONNECTION",
            "HTTP_X_CONTENT_OPT", "HTTP_X_FORWARD_FOR",
            "VIA", "CLIENT-IP", "REAL_IP" };
        private static List<int> ProxyPorts = new List<int>
        {
            3218, 3128, 8080, 8081, 1080, 80
        };
        private static ProxyLevel GetLevel(string x, int port)
        {
            ProxyLevel pl;
            int level = 0;

            foreach (string susp in SuspiciousHeaders)
            {
                if (x.Contains(susp))
                    level++;
            }
           

            if (ProxyPorts.Contains(port))
                level++;

            // keys count 7 == perfect headers

            switch (level)
            {
                case 0:
                    pl = ProxyLevel.High_Elite;
                    break;
                case 1:
                    pl = ProxyLevel.Elite;
                    break;
                case 2:
                    pl = ProxyLevel.Anonymous;
                    break;
                default:
                    pl = ProxyLevel.Transparent;
                    break;
            }

            pl |= ProxyLevel.All;

            return pl;
        }
    }

    class ProxyResult
    {
        public bool Working;
        public string Anonymity;
        public string[] CountryInfo;
        public long Speed;
        public bool SSL;
        public bool Custom;

        public ProxyResult(bool w, string a, string[] cu, long s, bool ssl, bool c)
        {
            Working = w;
            Anonymity = a.Replace("_", " ");
            CountryInfo = cu;
            Speed = s;
            SSL = ssl;
            Custom = c;
        }
    }
}
