using System;
using System.Collections.Generic;

namespace Speed_Racing
{
    public class StarUp
    {
        static void Main(string[] args)
        {
            int numberCars = int.Parse(Console.ReadLine());

            var cars = new Dictionary<string, Car>();
            AddCarToCars(numberCars, cars);

            var command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                var carModel = command[1];
                var distance = double.Parse(command[2]);

                bool checkForMove = cars[carModel].CalculateMoveDistance(distance);

                if (!checkForMove)
                {
                    Console.WriteLine("Insufficient fuel for the drive") ;
                }

                command = Console.ReadLine().Split();
            }

            foreach (var (key, value) in cars)
            {
                Console.WriteLine($"{key} {value.FuelAmount:f2} {value.TravelledDistance}");
            }
        }

        private static void AddCarToCars(int numberCars, Dictionary<string, Car> cars)
        {
            for (int i = 0; i < numberCars; i++)
            {
                var inputCarData = Console.ReadLine().Split();
                var model = inputCarData[0];
                var fuelAmount = double.Parse(inputCarData[1]);
                var fuelFor1Km = double.Parse(inputCarData[2]);

                if (!cars.ContainsKey(model))
                {
                    var carForAdd = new Car(model, fuelAmount, fuelFor1Km);
                    cars.Add(model, carForAdd);
                }
            }
        }
    }
}
