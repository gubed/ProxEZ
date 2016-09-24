using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProxEZ.Scraper.Modules;

namespace ProxEZ.Scraper
{
    class Scraper
    {
        private List<IScraper> modules; 
        public Scraper()
        {
            modules = new List<IScraper>();
            modules.Add(new Generic());
            modules.Add(new FreeProxyList());
            modules.Add(new SamairRU());
            //modules.Add(new HideMyAss());
            modules.Add(new HideMyIP());
            modules.Add(new ProxyRox());
            modules.Add(new NordVPN());
            modules.Add(new Blogspot());
        }

        public List<Proxy> Scrape(string url, string data)
        {
            return GetModule(url).Scrape(data);
        }

        private IScraper GetModule(string url)
        {
            foreach (var mod in modules)
            {
                foreach (var u in mod.Domains)
                {
                    if (url.Contains(u))
                        return mod;
                }

            }
            return new Generic();
        }
    }
}
