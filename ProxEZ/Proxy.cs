using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxEZ
{
    public class Proxy
    {
        public string Proxy_;
        public string Anonymity;
        public string Country;

        public Proxy(string p, string a, string c)
        {
            Proxy_ = p;
            Anonymity = a;
            Country = c;
        }

        public override bool Equals(object obj)
        {
            return ((Proxy)obj).Proxy_ == Proxy_;
        }
    }
}
