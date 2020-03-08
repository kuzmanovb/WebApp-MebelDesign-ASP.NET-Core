using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {

        private string name;
        private decimal money;
        private List<string> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            bagOfProducts = new List<string>();
        }
        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public decimal Money
        {
            get => this.money;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public string BoughtProduct(Product product)
        {
            if (product.Cost <= this.Money)
            {
                bagOfProducts.Add(product.Name);
                this.Money -= product.Cost;
                return $"{this.Name} bought {product.Name}";
            }

            return $"{this.Name} can't afford {product.Name}";
        }


        public override string ToString()
        {
            var products = string.Join(", ", bagOfProducts);
            if (bagOfProducts.Count > 0)
            {
                return $"{this.Name} - {products}";
            }
            else
            {
                return $"{this.Name} - Nothing bought ";

            }
        }
    }
}
