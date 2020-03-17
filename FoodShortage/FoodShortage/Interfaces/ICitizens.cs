using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public interface ICitizens : IId , IBuyer
    {
       
        string Age { get; }


    }
}
