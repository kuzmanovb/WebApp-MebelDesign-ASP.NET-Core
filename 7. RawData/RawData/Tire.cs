using System;
using System.Collections.Generic;
using System.Text;

namespace Raw_Data
{
    public class Tire
    {
        public Tire(double pressure, int age)
        {
            this.Pressure = pressure;
            this.Age = age;
        }
        public double Pressure { get; set; }
        public int Age { get; set; }
    }
}
