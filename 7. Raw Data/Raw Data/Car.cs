using System;
using System.Collections.Generic;
using System.Text;

namespace Raw_Data
{
    public class Car
    {

        public Car(string model)
        {
            this.Model = model;
        }
        public string Model { get; set; }

        public Engine EngineCar { get; set; } =;
    }
}
