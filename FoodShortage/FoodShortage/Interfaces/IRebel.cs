using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public interface IRebel : IBuyer
    {
        public string Age { get; }
        public string Group { get; }
    }
}
