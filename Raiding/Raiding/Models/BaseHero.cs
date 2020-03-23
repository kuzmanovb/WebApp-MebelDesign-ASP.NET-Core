using Raiding.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public abstract class BaseHero : IBaseHero
    {
        public BaseHero(string name)
        {
            this.Name = name;
            if (this.GetType().Name == "Druid")
            {
                this.Power = 80;
            }
            else if (this.GetType().Name == "Paladin")
            {
                this.Power = 100;
            }
            else if (this.GetType().Name == "Rogue")
            {
                this.Power = 80;
            }
            else if (this.GetType().Name == "Warrior")
            {
                this.Power = 100;
            }
        }

        public string Name { get; }

        public int Power { get; protected set; }

        public abstract string CastAbility();
        

    }
}
