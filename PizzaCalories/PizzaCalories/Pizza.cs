using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }
        public Dough Dough { get; set; }

        public void addTopping(Topping top)
        {
            if (toppings.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(top);
        }

        public double calculateCaloriesInPizza()
        {
            double result = 0;
            result += this.Dough.GetCalories();

            foreach (var item in toppings)
            {
                result += item.GetCalories();
            }

            return result;
        }

        


    }
}
