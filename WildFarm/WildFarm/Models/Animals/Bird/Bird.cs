using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interface;

namespace WildFarm.Models.Animals.Bird
{
    public abstract class Bird : Animal, IBird
    {
        public Bird(string name, double weight, double wingSize)
            : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; private set; }

        public override string ToString()
        {
            var typeAnimal = this.GetType().Name;
            return $"{typeAnimal} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
