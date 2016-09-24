using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProxEZ.Extensions;
using ProxEZ.Helpers;

namespace ProxEZ.Scraper.Modules
{
    class ProxyRox : IScraper
    {

        //https://proxyrox.com/?p=22&sortdir=desc&sort=reliability
        public string Name { get; set; }
        public string[] Domains { get; set; }

        public ProxyRox()
        {
            Name = "Proxy Rox";
            Domains = new[] {"proxyrox.com"};
        }
        public List<Proxy> Scrape(string data)
        {
            List<string> pages = new List<string>();
            List<Proxy> scraped = new List<Proxy>();
            
            Generic g = new Generic();
            var options = new ParallelOptions { MaxDegreeOfParallelism = 10 };

            for(int i = 0; i < 23; i++)
                pages.Add("https://proxyrox.com/?p=" + i + "&sortdir=desc&sort=reliability");

            Task t = new Task(() =>
            {
                Parallel.ForEach(pages, options, (item) =>
                {
                    try
                    {
                        string html = HTTP.DoWebRequest(item);
                        if (string.IsNullOrEmpty(html)) return;

                        lock (scraped)
                        {
                            scraped.AddRange(g.Scrape(html));
                        }
                    }
                    catch
                    {
                    }
                });
            });
            t.Start();
            Task.WaitAll(t);
            return scraped;
        }
    }
}
