using System;
using System.Collections.Generic;
using System.Text;

namespace Raw_Data
{
    public class Car
    {
        public Car(string model, Engine carEngine, Cargo cargoCar, List<Tire> tiresCar )
        {
            this.Model = model;
            this.EngineCar = carEngine;
            this.CargoCar = cargoCar;
            this.TiresCar = tiresCar;

        }
        public string Model { get; set; }

        public Engine EngineCar { get; set; }
        public Cargo CargoCar { get; set; }
        public List<Tire> TiresCar { get; set; }
    }
}
