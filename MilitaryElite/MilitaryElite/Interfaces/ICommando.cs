using System.Collections.Generic;

namespace MilitaryElite.Interfaces
{
    public interface ICommando : IPrivate, ISpecialisedSoldier
    {
        ICollection<IMission> Missions { get; }
    }
}
