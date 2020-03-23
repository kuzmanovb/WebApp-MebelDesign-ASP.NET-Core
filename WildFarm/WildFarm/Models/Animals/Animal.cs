using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Interface;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        public string Name { get; private set; }

        public double Weight { get; protected set; }

        public abstract int FoodEaten { get; protected set; }
        public abstract double WeightMultiplay { get; protected set; }

        public abstract string Sound();
        public abstract void Eaten(string typeFood, int quantity);


    }
}
