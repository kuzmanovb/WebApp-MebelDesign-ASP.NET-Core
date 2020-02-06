using System;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    public class Arena
    {
        private List<Gladiator> allGladiators;

        public Arena(string name)
        {
            this.Name = name;
            this.allGladiators = new List<Gladiator>();
        }

        public string Name { get; set; }
        public int Count
        {
            get { return this.allGladiators.Count; }
        }

        public void Add(Gladiator gladiator)
        {
            allGladiators.Add(gladiator);
        }

        public void Remove(string name)
        {
            for (int i = 0; i < this.allGladiators.Count; i++)
            {
                if (this.allGladiators[i].Name == name)
                {
                    this.allGladiators.RemoveAt(i);
                }
            }
        }

        public Gladiator GetGladitorWithHighestStatPower()
        {
            Gladiator forReturn = this.allGladiators[0];
            foreach (var gladiator in this.allGladiators)
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
            Gladiator forReturn = this.allGladiators[0];
            foreach (var gladiator in this.allGladiators)
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
            Gladiator forReturn = this.allGladiators[0];
            foreach (var gladiator in this.allGladiators)
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
            return $"{this.Name} - {this.allGladiators.Count} gladiators are participating.";
        }
    }
}
