using System;
using System.Collections.Generic;
using System.Text;

namespace P02_CarsSalesman
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
            this.Displacement = -1;
            this.Efficiency = "n/a";
        }

        public Engine(string model, int power, int displacement) : this(model, power)
        {
            this.Displacement = displacement;
        }

        public Engine(string model, int power, string efficiency) : this(model, power)
        {
            
            this.Efficiency = efficiency;
        }

        public Engine(string model, int power, int displacement, string efficiency) : this (model, power)
        {
            this.Displacement = displacement;
            this.Efficiency = efficiency;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"  {this.Model}:");
            sb.AppendLine($"    Power: {this.Power}");
            sb.AppendLine(this.Displacement == - 1 ? $"    Displacement: n/a" : $"    Displacement: {this.Displacement}");
            sb.AppendLine($"    Efficiency: {this.Efficiency}");

            return sb.ToString().TrimEnd();
        }

    }
}
