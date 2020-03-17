using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    public class Robots : IRobots
    {
        public Robots(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get; private set; }

        public string Id { get; private set; }
    }
}
