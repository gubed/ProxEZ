using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProxEZ.Extensions;

namespace ProxEZ.Scraper.Modules
{
    class FreeProxyList :IScraper
    {
        public string Name { get; set; }
        public string[] Domains { get; set; }

        public FreeProxyList()
        {
            Name = "Free Proxy List";
            Domains = new[]
            {
                "free-proxy-list.net",
                "sslproxies.org",
                "us-proxy.org",
                "socks-proxy.net",
                "google-proxy.net"

            };
        }
        public List<Proxy> Scrape(string html)
        {


            List<Proxy> scraped = new List<Proxy>();
            if (!html.Contains("<tbody><tr><td>")) return scraped;
            html = "<tbody><tr><td>" + html.GetBetween("<tbody><tr><td>", "</tbody>");
            string[] entries = html.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            var options = new ParallelOptions() { MaxDegreeOfParallelism = 15 };
            Task t = new Task(() =>
            {
                Parallel.ForEach(entries, options, (entry) =>
                {
                    try
                    {
                        if (entry.IsNullOrWhiteSpace()) return;
                        var tmp = entry.Replace("<tbody>", "").Replace("<tr><td>", "@@").Replace("</td><td>", "@@");
                        string[] data = tmp.Split(new[] { "@@" }, StringSplitOptions.None);
                        var ip = data[1];
                        var port = data[2];

                        var cunt = data[4];
                        var anon = ((string)data[5]).TitleCase().Replace("Proxy", string.Empty);

                        lock (scraped)
                        {
                            if (!scraped.Contains(new Proxy(ip + ":" + port, anon, cunt)))
                                scraped.Add(new Proxy(ip + ":" + port, anon, cunt));
                        }

                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.ToString());
                    }
                });
            });

            t.Start();
            Task.WaitAll(t);

            return scraped;
        }
    }
}
