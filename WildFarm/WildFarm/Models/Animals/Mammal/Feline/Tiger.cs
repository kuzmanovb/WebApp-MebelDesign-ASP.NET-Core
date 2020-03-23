using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals.Mammal.Feline
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMultiplay { get; protected set; } = 1.00;
        public override int FoodEaten { get; protected set; }

        public override void Eaten(string typeFood, int quantity)
        {

            if (typeFood != "Meat")
            {
                var typeAnimal = this.GetType().Name;
                throw new ArgumentException($"{typeAnimal} does not eat {typeFood}!");
            }
            this.Weight += quantity * WeightMultiplay;
            this.FoodEaten += quantity;
        }

        public override string Sound()
        {
            return "ROAR!!!";
        }
    }


}
