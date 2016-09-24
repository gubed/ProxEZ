using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using ProxEZ.Extensions;
using ProxEZ.Helpers;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace ProxEZ.Scraper.Modules
{
    class SamairRU : IScraper
    {
        public string Name { get; set; }
        public string[] Domains { get; set; }

        public SamairRU()
        {
            Name = "Free Proxy List";
            Domains = new[]{
                "samair.ru"
            };
        }
        public List<Proxy> Scrape(string data)
        {
            List<Proxy> scraped = new List<Proxy>();
            List<string> pages = new List<string>();
            List<string> ippages = new List<string>();
            Generic g = new Generic();
            var options = new ParallelOptions { MaxDegreeOfParallelism = 10 };

            pages.Add("http://www.samair.ru/proxy/proxy-1.htm");
            for (int i = 2; i < 30; i++)
            {          
                if (i <= 9 && i > 1)
                    pages.Add("http://www.samair.ru/proxy/proxy-0" + i + ".htm");
                else
                    pages.Add("http://www.samair.ru/proxy/proxy-" + i + ".htm");
                //<a href="/proxy/ip-port/977482367.html">You can do it there</a>
            }
            Task t = new Task(() =>
            {
                Parallel.ForEach(pages, options, (item) =>
                {
                    try
                    {
                        string html = HTTP.DoWebRequest(item);
                        if (string.IsNullOrEmpty(html)) return;

                        var page = html.GetBetween("<a href=\"/proxy/ip-port/", ".html");
                        var linkToPage = "http://www.samair.ru/proxy/ip-port/" + page + ".html";
                        ippages.Add(linkToPage);
                        

                        var page2 = HTTP.DoWebRequest(linkToPage);
                        if (string.IsNullOrEmpty(page2)) return;

                        lock (scraped)
                        {
                            scraped.AddRange(g.Scrape(page2));
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
