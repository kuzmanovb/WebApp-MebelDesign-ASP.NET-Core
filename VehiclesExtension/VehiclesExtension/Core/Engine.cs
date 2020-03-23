using System;
using System.Linq;

using VehiclesExtension.Models;
using VehiclesExtension.Interface;

namespace VehiclesExtension.Core
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
            var bus = (Bus)CreateVehicle();

            var numberInput = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberInput; i++)
            {
                var input = Console.ReadLine().Split().ToArray();

                var command = input[0];
                var type = input[1];
                var litersOrDistance = double.Parse(input[2]);

                try
                {
                    if (command == "Refuel")
                    {
                        if (type == "Car")
                        {
                            car.Refuel(litersOrDistance);
                        }
                        else if (type == "Truck")
                        {
                            truck.Refuel(litersOrDistance);
                        }
                        else if (type == "Bus")
                        {
                            bus.Refuel(litersOrDistance);
                        }
                    }
                    else if(command == "Drive")
                    {

                        if (type == "Car")
                        {
                            Console.WriteLine(car.Drive(litersOrDistance));
                        }
                        else if (type == "Truck")
                        {
                            Console.WriteLine(truck.Drive(litersOrDistance));
                        }
                        else if(type == "Bus")
                        {
                            Console.WriteLine(bus.Drive(litersOrDistance));
                        }
                    }
                    else if (command == "DriveEmpty")
                    {
                        Console.WriteLine(bus.DriveEmpty(litersOrDistance));
                    }
                }
                catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
        }

        private static IVehicles CreateVehicle()
        {
            var vehicleInfo = Console.ReadLine().Split().ToArray();
            var model = vehicleInfo[0];
            var fuelQuantity = double.Parse(vehicleInfo[1]);
            var fuelForKm = double.Parse(vehicleInfo[2]);
            var tankCapacity = double.Parse(vehicleInfo[3]);
            if (model == "Car")
            {
                return new Car(fuelQuantity, fuelForKm, tankCapacity);
            }
            else if (model == "Truck")
            {
                return new Truck(fuelQuantity, fuelForKm, tankCapacity);
            }
            else
            {
                return new Bus(fuelQuantity, fuelForKm, tankCapacity);
            }
        }
    }
}
