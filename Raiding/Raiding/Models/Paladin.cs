using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        public Paladin(string name)
            : base(name)
        {
        }
        public override string CastAbility()
        {
            var nameClass = this.GetType().Name;
            return $"{nameClass} - {this.Name} healed for {this.Power}";

        }

    }
}
