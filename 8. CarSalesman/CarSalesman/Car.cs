using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public Car(string model, Engine carEngine)
        {
            this.Model = model;
            this.CarEngine = carEngine;
            this.Weight = 0;
            this.Color = null;
        }
        public Car(string model, Engine carEngine, int weight) : this(model, carEngine)
        {
            this.Weight = weight;
        }
        public Car(string model, Engine carEngine, string color) : this(model, carEngine)
        {
            this.Color = color;
        }
        public Car(string model, Engine carEngine, int weight, string color) : this(model, carEngine)
        {
            this.Weight = weight;
            this.Color = color;
        }
        public string Model { get; set; }
        public Engine CarEngine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
           
            
            
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Model}:").
                AppendLine($"  {this.CarEngine.Model}:").
                AppendLine($"    Power: {this.CarEngine.Power}").

                AppendLine(this.CarEngine.Displacement > 0 ?
                           $"    Displacement: {this.CarEngine.Displacement}" :
                           $"    Displacement: n/a").

                AppendLine(this.CarEngine.Efficiency != null ?
                           $"    Efficiency: {this.CarEngine.Efficiency}" :
                           $"    Efficiency: n/a").

                AppendLine(this.Weight > 0 ?
                           $"  Weight: {this.Weight}" :
                           $"  Weight: n/a").
                Append(this.Color != null ?
                           $"  Color: {this.Color}" :
                           $"  Color: n/a");




            return sb.ToString();
        }
    }
}
