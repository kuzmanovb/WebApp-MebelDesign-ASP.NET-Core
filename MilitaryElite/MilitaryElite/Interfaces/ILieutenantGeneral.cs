using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Interfaces
{
    public interface ILieutenantGeneral : IPrivate
    {
        ICollection <IPrivate> PrivateCorp { get; }
    }
}
