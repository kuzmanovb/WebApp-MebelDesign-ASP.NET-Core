using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interface;

namespace WildFarm.Models.Animals.Mammal.Feline
{
    public abstract class Feline : Mammal, IFeline
    {
        public Feline(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion)
        {
            this.Breed = breed;
        }
       
        public string Breed { get; private set; }

        public override string ToString()
        {
            var typeAnimal = this.GetType().Name;
            return $"{typeAnimal} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
