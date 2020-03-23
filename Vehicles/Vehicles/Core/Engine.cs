using System;
using System.Linq;

using Vehicles.Models;
using Vehicles.Interface;

namespace Vehicles.Core
{
    public class Engine
    {
        public Engine()
        {
        }

        public void Run()
        {
            var car = CreateVehicle();
            var truck = CreateVehicle();

            var numberInput = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberInput; i++)
            {
                var input = Console.ReadLine().Split().ToArray();

                var command = input[0];
                var type = input[1];
                var litersOrDistance = double.Parse(input[2]);

                if (command == "Refuel")
                {
                    if (type == "Car")
                    {
                        car.Refuel(litersOrDistance);
                    }
                    else
                    {
                        truck.Refuel(litersOrDistance);
                    }
                }
                else
                {

                    if (type == "Car")
                    {
                        Console.WriteLine(car.Drive(litersOrDistance));
                    }
                    else
                    {
                        Console.WriteLine(truck.Drive(litersOrDistance));
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }

        private static IVehicles CreateVehicle()
        {
            var vehicleInfo = Console.ReadLine().Split().ToArray();
            var model = vehicleInfo[0];
            var fuelQuantity = double.Parse(vehicleInfo[1]);
            var fuelForKm = double.Parse(vehicleInfo[2]);
            if (model == "Car")
            {
                return new Car(fuelQuantity, fuelForKm);
            }
            else
            {
                return new Truck(fuelQuantity, fuelForKm);
            }
        }
    }
}
