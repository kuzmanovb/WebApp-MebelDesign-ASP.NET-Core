using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizens : ICitizens, IBuyer
    {
        public Citizens(string name, string age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
            this.Food = 0;
        }

        public string Name { get; private set; }

        public string Age { get; private set; }

        public string Id { get; private set; }
        public string Birthdate { get; private set; }
        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
