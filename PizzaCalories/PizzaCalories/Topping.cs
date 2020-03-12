using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {

        private List<string> typeTopping = new List<string> { "meat", "veggies", "cheese", "sauce" };
        private string top;
        private double grams;

        public Topping(string top, double grams)
        {
            this.Top = top;
            this.Grams = grams;
        }

        public string Top
        {
            get => this.top;
            private set
            {
                if (!typeTopping.Contains(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.top = value;
            }
        }
        public double Grams
        {
            get => this.grams;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.top} weight should be in the range [1..50].");
                }

                this.grams = value;
            }
        }

        public double GetCalories()
        {
            double toppingCal = 0;

            switch (Top.ToLower())
            {
                case "meat": toppingCal = 1.2; break;
                case "veggies": toppingCal = 0.8; break;
                case "cheese": toppingCal = 1.1; break;
                case "sauce": toppingCal = 0.9; break;

            }

            var result = 2 * this.grams * toppingCal;
            return result;
        }



    }
}
