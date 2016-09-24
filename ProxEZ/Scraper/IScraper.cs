
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProxEZ.Scraper
{
    public interface IScraper
    {
        string Name { get;  set; }
        string[] Domains { get; set; }
        List<Proxy> Scrape(string data);
    }
}
