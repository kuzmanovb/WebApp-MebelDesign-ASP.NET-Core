using System;
using System.Collections.Generic;
using System.Linq;

namespace Raw_Data
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var cars = new List<Car>();
            FillCarsList(n, cars);

            var command = Console.ReadLine();

            if (command == "fragile")
            {
                cars = cars.Where(c => c.CargoCar.Type == "fragile" && c.TiresCar.Any(t => t.Pressure < 1)).ToList();
                foreach (var car in cars)
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (command == "flamable")
            {
                cars = cars.Where(c => c.CargoCar.Type == "flamable" && c.EngineCar.EnginePower > 250).ToList();
                foreach (var car in cars)
                {
                    Console.WriteLine(car.Model);
                }
            }


        }

        private static void FillCarsList(int n , List<Car> cars)
        {
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                var speed = int.Parse(input[1]);
                var power = int.Parse(input[2]);
                var newEngine = new Engine(speed, power);

                var cargoWeight = int.Parse(input[3]);
                var cargoType = input[4];
                var newCargo = new Cargo(cargoWeight, cargoType);

                var listTires = new List<Tire>();

                for (int t = 5; t < input.Length; t += 2)
                {
                    var curentPressure = double.Parse(input[t]);
                    var curentAge = int.Parse(input[t + 1]);
                    var tire = new Tire(curentPressure, curentAge);
                    listTires.Add(tire);
                }

                var newCar = new Car(input[0], newEngine, newCargo, listTires);
                cars.Add(newCar);
            }
        }
    }
}
