using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface IEngineer : IPrivate, ISpecialisedSoldier
    {
        ICollection<IRepair> Repairs { get; }
    }
}
