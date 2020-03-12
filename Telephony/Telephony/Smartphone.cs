using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICalling, IBrowsing
    {

        public string PhoneNumber { get; private set; }

        public string Sites { get; private set; }
    }
}
