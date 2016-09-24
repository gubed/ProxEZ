using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProxEZ.Extensions;
using ProxEZ.Helpers;

namespace ProxEZ.Scraper.Modules
{
    class Generic : IScraper
    {

        public string Name { get; set; }
        public string[] Domains { get; set; }
        public Generic()
        {
            Name = "Generic";
            Domains = new [] { "none"};
;       }

        public List<Proxy> Scrape(string data)
        {
            List<Proxy> scraped = new List<Proxy>();

            //data = data.GetBetween("<body", "</body>"); // Attempt to remove some garbage
            //data = data.StripHTML();

            MatchCollection proxies = Regex.Matches(data, @"(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})(?=[^\d])\s*:?\s*(\d{1,5})");

            if (proxies.Count == 0) return scraped;

            List<string> tempP = new List<string>();
            foreach (Match pr in proxies)
            {
                if(!tempP.Contains(pr.Value))
                    tempP.Add(pr.Value);
            }
            var options = new ParallelOptions() { MaxDegreeOfParallelism = 15 };
            Task t = new Task(() =>
            {
                Parallel.ForEach(tempP, options, (entry) =>
                {
                    try
                    {
                        var split = entry.Split(':');
                        var ip = split[0];
                        var port = split[1];
                        var prox = ip + ":" + port;
                        //if ((p > 0 && p <= 65535) /*&& prox.RegexIsMatch(@"[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}:[0-9]{1,4}")*/)
                        lock(scraped)
                        {
                            scraped.Add(new Proxy(prox, "", ""/*CountryInfo.GetCountryInfo(ip)[1]*/));
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                });
            });
           
            t.Start();
            Task.WaitAll(t);
            
            return scraped;
        }


    }
}
