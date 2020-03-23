using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        public Warrior(string name)
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
