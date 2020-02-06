using System;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    public class Arena
    {
        private List<Gladiator> gladiators;

        public Arena(string name)
        {
            this.Name = name;
            this.gladiators = new List<Gladiator>();
        }

        public string Name { get; set; }
        public int Count
        {
            get { return this.gladiators.Count; }
        }

        public void Add(Gladiator gladiator)
        {
            gladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            for (int i = 0; i < this.gladiators.Count; i++)
            {
                if (this.gladiators[i].Name == name)
                {
                    this.gladiators.RemoveAt(i);
                }
            }
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            Gladiator forReturn = this.gladiators[0];
            foreach (var gladiator in this.gladiators)
            {
                if (gladiator.GetStatPower() > forReturn.GetStatPower())
                {
                    forReturn = gladiator;
                }
            }

            return forReturn;
        }
        public Gladiator GetGladitorWithHighestWeaponPower()
        {
            Gladiator forReturn = this.gladiators[0];
            foreach (var gladiator in this.gladiators)
            {
                if (gladiator.GetWeaponPower() > forReturn.GetWeaponPower())
                {
                    forReturn = gladiator;
                }
            }

            return forReturn;
        }
        public Gladiator GetGladitorWithHighestTotalPower()
        {
            Gladiator forReturn = this.gladiators[0];
            foreach (var gladiator in this.gladiators)
            {
                if (gladiator.GetTotalPower() > forReturn.GetTotalPower())
                {
                    forReturn = gladiator;
                }
            }

            return forReturn;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.gladiators.Count} gladiators are participating.";
        }
    }
}
