using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals.Mammal
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override double WeightMultiplay { get; protected set; } = 0.10;
        public override int FoodEaten { get; protected set; }

        public override void Eaten(string typeFood, int quantity)
        {

            if (typeFood != "Vegetable" && typeFood != "Fruit")
            {
                var typeAnimal = this.GetType().Name;
                throw new ArgumentException($"{typeAnimal} does not eat {typeFood}!");
            }
            this.Weight += quantity * WeightMultiplay;
            this.FoodEaten += quantity;
        }

        public override string Sound()
        {
            return "Squeak";
        }
    }
}
