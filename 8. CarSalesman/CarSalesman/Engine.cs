using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        public Engine()
        {

        }
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = 0;
            this.Efficiency = null;

        }
        public Engine(string model, int power, int displacement) : this (model, power)
        {
            this.Displacement = displacement;
        }
        public Engine(string model, int power, string efficiency) : this(model, power)
        {
            this.Efficiency = efficiency;
        } 
        public Engine(string model, int power, int displacement, string efficiency) : this(model, power)
        {
            this.Efficiency = efficiency;
            this.Displacement = displacement;
        }
        
        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

       


    }
}
