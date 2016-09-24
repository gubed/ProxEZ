using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using ProxEZ.Extensions;

namespace ProxEZ.Scraper.Modules
{
    class HideMyIP: IScraper
    {
        public string Name { get; set; }
        public string[] Domains { get; set; }

        public HideMyIP()
        {
            Name = "Hide My IP";
            Domains = new[] {"hide-my-ip.com"};
        }

        public List<Proxy> Scrape(string data)
        {
            List<Proxy> scraped = new List<Proxy>();
            data = data.GetBetween("var json =", ";<!-- proxylist -->").Trim();
            JArray jo;
            try
            {
                jo = JArray.Parse(data);
            }
            catch (Exception)
            {
                return null;
            }
            List<object> children = new List<object>();
            foreach (var jToken in jo.Children())
                children.Add(jToken);

            var options = new ParallelOptions() { MaxDegreeOfParallelism = 15 };
            Task t = new Task(() =>
            {
                Parallel.ForEach(children, options, (entry) =>
                {
                    try
                    {
                        var j = (JObject)entry;
                        var itemProperties = j.Children<JProperty>();

                        var ip = itemProperties.FirstOrDefault(x => x.Name == "i").Value;
                        var port = itemProperties.FirstOrDefault(x => x.Name == "p").Value;
                        var cunt = j["c"]["n"];

                        lock (scraped)
                        {
                            scraped.Add(new Proxy(ip + ":" + port, "", cunt.ToString()));
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
