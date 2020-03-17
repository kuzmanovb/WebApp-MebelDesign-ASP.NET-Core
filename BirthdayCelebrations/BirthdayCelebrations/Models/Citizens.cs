using BirthdayCelebrations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Citizens : ICitizens
    {
        public Citizens(string name, string age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public string Age { get; private set; }

        public string Id { get; private set; }
        public string Birthdate { get; private set; }


    }
}
