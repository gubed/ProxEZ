using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ProxEZ.Extensions;


namespace ProxEZ.Scraper.Modules
{
    class HideMyAss : IScraper
    {
        public string Name { get; set; }
        public string[] Domains { get; set; }

        public HideMyAss()
        {
            Name = "Hide My Ass";
            Domains = new[] {"hidemyass.com"};
        }
        public List<Proxy> Scrape(string data)
        {
            List<Proxy> scraped = new List<Proxy>();
            data = data.GetBetween("<tbody>", "</tbody>");

            string[] rows = data.Split(new[] {"<tr class"}, StringSplitOptions.None);

            // Clean up
            for (int r = 0; r < rows.Length; r++)
            {
                var IP = "";
                rows[r] = rows[r].GetBetween("</style>", "</td>");
                //rows[r] = rows[r].Replace("<span>", string.Empty).Replace("</span>", string.Empty);
               // var hidden = rows[r].RegexMatch("<span style=\"display:none\">(.*?)");
                MatchCollection mc = Regex.Matches(rows[r], "<span style=\"display:none\">(.*?)</span>");
                MatchCollection mc2 = Regex.Matches(rows[r], "<div style=\"display:none\">(.*?)</div>");
                MatchCollection mc3 = Regex.Matches(rows[r], "<span class=\"(.*?)\">(.*?)</span>");
                var before = rows[r];
                if (mc.Count > 0)
                {
                    foreach (Match m in mc)
                    {
                        //MessageBox.Show(m.Value);
                        rows[r] = rows[r].Replace(m.Value, string.Empty);
                    }
                }
                if (mc2.Count > 0)
                {
                    foreach (Match m in mc2)
                    {
                        //MessageBox.Show(m.Value);
                       // rows[r] = rows[r].Replace(m.Value, string.Empty);
                    }
                }
                if (mc3.Count > 0)
                {
                    IP += mc3[0].Groups[2].Value;
                    IP += mc3[1].Groups[2].Value;
                    IP += mc3[2].Groups[2].Value;
                    IP += ".";
                    IP += rows[r].GetBetween("<span style=\"display: inline\">", "</span>");
                    IP += ".";
                    MatchCollection anus = Regex.Matches(rows[r], "<div style=\"display:none\">(.*?)</div>(.*?)<div");
                    var fucking = anus[2].Groups[2].Value;
                    IP += fucking;
                    MessageBox.Show(IP);
                }
                //rows[r] = rows[r].Replace("<span>", string.Empty).Replace("</span>", string.Empty);
                // foreach(var match in mc.)
                //Clipboard.SetText(rows[r]);
                MessageBox.Show(rows[r]);
                //<span style="display:none">
                // var hidden = rows[r].RegexMatch("<span style=\"display: none\">(.*?)")
            }
            foreach (var row in rows)
            {
                var splitRow = row.Split(new string[] {"\">"}, StringSplitOptions.None);

            }
            return scraped;
        }
    }
}
