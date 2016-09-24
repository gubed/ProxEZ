using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProxEZ.Helpers
{
    class HTTP
    {
        public static string DoWebRequest(string url, WebProxy proxy = null, int timeout = 10000)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = AlwaysAccept;

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url.Trim());
                httpWebRequest.UserAgent =
                    "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.111 Safari/537.36";
                httpWebRequest.Timeout = timeout;
                httpWebRequest.Accept = "*/*";
                httpWebRequest.Referer = "http://" + new Uri(url).Host;
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                httpWebRequest.KeepAlive = false;
                httpWebRequest.Proxy = proxy;
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpWebResponse.StatusCode != HttpStatusCode.OK) return null;
                Stream responseStream = httpWebResponse.GetResponseStream();
                var streamReader = httpWebResponse.CharacterSet == null ? new StreamReader(responseStream) : new StreamReader(responseStream, Encoding.GetEncoding(httpWebResponse.CharacterSet));
                string input = streamReader.ReadToEnd();
                httpWebResponse.Close();
                streamReader.Close();
                return input;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                return null;
            }

        }
        public static bool AlwaysAccept(object sender, X509Certificate certification, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
