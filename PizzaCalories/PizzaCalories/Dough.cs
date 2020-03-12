using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flour;
        private string baking;
        private double grams;

        public Dough(string flour, string baking, double grams)
        {
            this.Flour = flour;
            this.Baking = baking;
            this.Grams = grams;
        }

        public string Flour
        {
            get => this.flour;
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flour = value;
            }
        }
        public string Baking
        {
            get => this.baking;
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.baking = value;
            }

        }

        public double Grams
        {
            get => this.grams;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.grams = value;
            }
        }

        public double GetCalories()
        {
            double flourValue = 0;
            double bakingValue = 0;

            switch (flour.ToLower())
            {
                case "white": flourValue = 1.5; break;
                case "wholegrain": flourValue = 1.0; break;
            }

            switch (baking.ToLower())
            {
                case "crispy": bakingValue = 0.9; break;
                case "chewy": bakingValue = 1.1; break;
                case "homemade": bakingValue = 1.0; break;

            }

            var result = 2 * this.grams * flourValue * bakingValue;
            return result;
        }

    }
}
