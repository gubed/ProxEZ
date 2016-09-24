using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using ProxEZ.Extensions;

namespace ProxEZ.Scraper.Modules
{
    class NordVPN : IScraper
    {
        public string Name { get; set; }
        public string[] Domains { get; set; }

        public NordVPN()
        {
            Name = "NordVPN";
            Domains = new[] {"nordvpn.com"};
        }
        public List<Proxy> Scrape(string data)
        {
            List<Proxy> scraped = new List<Proxy>();
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

                        var ip = itemProperties.FirstOrDefault(x => x.Name == "ip").Value;
                        var port = itemProperties.FirstOrDefault(x => x.Name == "port").Value;
                        var cunt = j["country"];

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
