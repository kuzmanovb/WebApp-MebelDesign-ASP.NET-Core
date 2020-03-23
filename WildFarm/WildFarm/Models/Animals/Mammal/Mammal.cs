using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interface;

namespace WildFarm.Models.Animals.Mammal
{
    public abstract class Mammal : Animal,IMammal
    {
        public Mammal(string name, double weight, string livingRegion) 
            : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }

        public override string ToString()
        {
            var typeAnimal = this.GetType().Name;
            return $"{typeAnimal} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
