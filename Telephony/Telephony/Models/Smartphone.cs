using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : StationaryPhone, IBrowsing
    {
        public Smartphone( string sites) : base("0")
        {
            if (sites.Any(n => Char.IsDigit(n)))
            {
                throw new ArgumentException("Invalid URL!");
            }
            else
            {
                this.Sites = sites;
            }

        }

        public string Sites { get; private set; }

        public string PrintURL()
        {
            return $"Browsing: {Sites}!";
        }
    }
}
