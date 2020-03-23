using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        public Rogue(string name)
            : base(name)
        {
        }
        public override string CastAbility()
        {
            var nameClass = this.GetType().Name;
            return $"{nameClass} - {this.Name} hit for {this.Power} damage";
        }

    }
}
