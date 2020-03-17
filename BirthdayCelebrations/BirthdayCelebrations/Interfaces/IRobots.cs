using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public interface IRobots : IId
    {
        string Model { get; }
    }
}
