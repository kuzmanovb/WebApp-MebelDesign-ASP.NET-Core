using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals.Bird
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override double WeightMultiplay { get; protected set; } = 0.25;
        public override int FoodEaten { get; protected set;}

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
            return "Hoot Hoot";
        }
    }
}
