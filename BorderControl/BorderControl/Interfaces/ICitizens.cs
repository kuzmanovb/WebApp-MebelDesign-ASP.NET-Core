using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface ICitizens : IId
    {
        string Name { get; }
        string Age { get; }

    }
}
