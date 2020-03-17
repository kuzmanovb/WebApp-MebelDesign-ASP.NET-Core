using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public interface IPet : IBirthdate
    {
        string Name { get; }

    }
}
