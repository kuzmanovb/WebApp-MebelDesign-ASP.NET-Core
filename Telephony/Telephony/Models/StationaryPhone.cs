using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICalling
    {
        public StationaryPhone(string number)
        {
            if (!number.All(n => Char.IsDigit(n)))
            {
                throw new ArgumentException("Invalid number!");
            }
            else
            {
                this.PhoneNumber = number;
            }

        }
        public string PhoneNumber { get; private set; }

        public string PrintNumber()
        {
            if (this.PhoneNumber.Length == 7)
            {
                return $"Dialing... {this.PhoneNumber}";
            }
            else 
            {
                return $"Calling... {this.PhoneNumber}";
            }
        }


    }
}
