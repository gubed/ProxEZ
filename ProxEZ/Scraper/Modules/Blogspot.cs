using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ProxEZ.Extensions;
using ProxEZ.Helpers;

namespace ProxEZ.Scraper.Modules
{
    class Blogspot : IScraper
    {
        public string Name { get; set; }
        public string[] Domains { get; set; }

        public Blogspot()
        {
            Name = "Blogspot";
            Domains = new[]
            {
                "blogspot.com",
                "blogspot.md",
                "blogspot.ro"
                //"blogspot.co.uk"
            };
        }
        public List<Proxy> Scrape(string data)
        {
            List<Proxy> scraped = new List<Proxy>();
            Generic g = new Generic();
            var url = data.RegexMatch(@"(http:\/\/|https:\/\/)(.*?)\/favicon.ico").Groups[2].Value;
            var searchPageURL = "http://" + url + "/search?max-results=10";

            var searchPage = HTTP.DoWebRequest(searchPageURL);
            string[] pages = GetPages(searchPage, url);
            if (pages == null) return scraped;

            var options = new ParallelOptions { MaxDegreeOfParallelism = 10 };
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

        private string[] GetPages(string html, string url)
        {
            //http://sslproxies24.blogspot.ro/2016/08/26-08-16-free-google-proxies-190.html
            //var tmp = html;
            //html = html.GetBetween("<div class=\"date-posts\">", "<span class='post-icons'>");
            //if (string.IsNullOrWhiteSpace(html))
            //    html = tmp;

           
           

            MatchCollection mc = Regex.Matches(html, @"(http:\/\/|https:\/\/)" + url + @"\/2016\/(.*?)\.html");

            List<string> pages = new List<string>();
            Hashtable hash = new Hashtable();

            foreach (Match mt in mc)
            {
                string foundMatch = mt.ToString();
                if (hash.Contains(foundMatch) == false)
                    hash.Add(foundMatch, string.Empty);

            }
            foreach (DictionaryEntry element in hash)
                pages.Add(element.Key.ToString());
            return pages.ToArray();
        }
    }
}
