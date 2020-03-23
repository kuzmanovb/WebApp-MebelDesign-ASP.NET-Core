using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals.Bird
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override double WeightMultiplay { get; protected set; } = 0.35;
        public override int FoodEaten { get; protected set; }

        public override void Eaten(string typeFood, int quantity)
        {
            this.Weight += quantity * WeightMultiplay;
            this.FoodEaten += quantity;
        }

        public override string Sound()
        {
            return "Cluck";
        }
    }
}
