using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple<Tfirst, Tsecond>
    {
        private Tfirst item1;
        private Tsecond item2;

        public Tuple(Tfirst inputItem1 , Tsecond inputItem2)
        {
            this.item1 = inputItem1;
            this.item2 = inputItem2;
        }

        public override string ToString()
        {
            return $"{this.item1} -> {this.item2}";
        }

    }
}
