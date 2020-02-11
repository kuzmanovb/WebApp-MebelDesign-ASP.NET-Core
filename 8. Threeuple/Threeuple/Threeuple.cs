using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    public class Threeuple<Tfirst, Tsecond, Tthird>
    {

        private Tfirst item1;
        private Tsecond item2;
        private Tthird item3;

        public Threeuple(Tfirst inputItem1, Tsecond inputItem2, Tthird inputItem3)
        {
            this.item1 = inputItem1;
            this.item2 = inputItem2;
            this.item3 = inputItem3;
        }

        public override string ToString()
        {
            return $"{this.item1} -> {this.item2} -> {this.item3}";
        }
    }
}
