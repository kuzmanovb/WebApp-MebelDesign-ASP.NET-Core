using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public interface IBuyer : IName
    {
        int Food { get;}

        void BuyFood();
    }
}
