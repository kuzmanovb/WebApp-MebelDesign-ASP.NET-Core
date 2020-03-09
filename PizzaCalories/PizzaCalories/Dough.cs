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
            set
            {
                if (value != "White" || value != "Wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flour = value;
            }
        }
        public string Baking
        {
            get => this.baking;
            set
            {
                if (value != "Crispy" || value != "Chewy" || value != "Homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.baking = value;
            }

        }

        public double Grams
        {
            get => this.grams;
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
            }
        }

        public double GetCalories()
        {
            double flourValue = 0;
            double bakingValue = 0;

            switch (flour)
            {
                case "White": flourValue = 1.5; break;
                case "•	Wholegrain": flourValue = 1.0; break;
            }

            switch (baking)
            {
                case "Crispy": bakingValue = 0.9; break; 
                case "Chewy": bakingValue = 1.1; break;  
                case "Homemade": bakingValue = 1.0; break;

            }

            return 2 * 100 * flourValue * bakingValue;
        }

    }
}
