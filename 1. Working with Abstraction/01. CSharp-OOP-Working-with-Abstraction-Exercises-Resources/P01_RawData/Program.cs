using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_RawData
{
   
    class RawData
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < lines; i++)
            {
                string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string model = parameters[0];
                var curentEngine = CreateEngine(parameters);
                var curentCargo = CreateCargo(parameters);
                var curentTires = CreateTires(parameters);

                cars.Add(new Car(model, curentEngine, curentCargo, curentTires));
            }

            string command = Console.ReadLine();


            if (command == "fragile")
            {
                List<string> fragile = cars
                    .Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(y => y.TirePressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                List<string> flamable = cars
                    .Where(x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }

        private static List<Tire> CreateTires(string[] parameters)
        {
            var collectTires = new List<Tire>();
            
            var tire1Pressure = double.Parse(parameters[5]);
            var tire1age = int.Parse(parameters[6]);
            collectTires.Add(new Tire(tire1Pressure, tire1age));
            
            var tire2Pressure = double.Parse(parameters[7]);
            var tire2age = int.Parse(parameters[8]);
            collectTires.Add(new Tire(tire2Pressure, tire2age));
            
            var tire3Pressure = double.Parse(parameters[9]);
            var tire3age = int.Parse(parameters[10]);
            collectTires.Add(new Tire(tire3Pressure, tire3age));
            
            var tire4Pressure = double.Parse(parameters[11]);
            var tire4age = int.Parse(parameters[12]);
            collectTires.Add(new Tire(tire4Pressure, tire4age));

            return collectTires;
        }

        private static Cargo CreateCargo(string[] parameters)
        {
            var cargoWeight = int.Parse(parameters[3]);
            var cargoType = parameters[4];
            return new Cargo(cargoWeight, cargoType);
        }

        private static Engine CreateEngine(string[] parameters)
        {
            var engineSpeed = int.Parse(parameters[1]);
            var enginePower = int.Parse(parameters[2]);
            return new Engine(engineSpeed, enginePower);
        }
    }
}
