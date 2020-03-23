using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals.Mammal.Feline
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMultiplay { get; protected set; } = 0.30;
        public override int FoodEaten { get; protected set;}

        public override void Eaten(string typeFood, int quantity)
        {
           
            if (typeFood != "Vegetable" && typeFood != "Meat") 
            {
                var typeAnimal = this.GetType().Name;
                throw new ArgumentException($"{typeAnimal} does not eat {typeFood}!");
            }
            this.Weight += quantity * WeightMultiplay;
            this.FoodEaten += quantity;
        }

        public override string Sound()
        {
            return "Meow";
        }
    }
}
