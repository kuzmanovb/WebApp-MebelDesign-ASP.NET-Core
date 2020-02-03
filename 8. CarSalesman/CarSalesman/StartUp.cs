using System;
using System.Collections.Generic;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var numberEngines = int.Parse(Console.ReadLine());
            var enginesModels = new Dictionary<string, Engine>();
            FillEngineModels(numberEngines, enginesModels);

            var numberCar = int.Parse(Console.ReadLine());
            var listCars = new List<Car>();
            FillCars(enginesModels, numberCar, listCars);

            foreach (var car in listCars)
            {
                Console.WriteLine(car);
            }

        }

        private static void FillCars(Dictionary<string, Engine> enginesModels, int numberCar, List<Car> listCars)
        {
            for (int i = 0; i < numberCar; i++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var model = input[0];
                var engine = enginesModels[input[1]];

                Car newCar = null;

                if (input.Length == 2)
                {
                    newCar = new Car(model, engine);
                }
                else if (input.Length == 3)
                {
                    int weight;

                    var chack = int.TryParse(input[2], out weight);
                    if (chack)
                    {
                        newCar = new Car(model, engine, weight);
                    }
                    else
                    {
                        newCar = new Car(model, engine, input[2]);
                    }
                }
                else if (input.Length == 4)
                {
                    int weight = int.Parse(input[2]);
                    newCar = new Car(model, engine, weight, input[3]);

                }

                listCars.Add(newCar);

            }
        }

        private static void FillEngineModels(int numberEngines, Dictionary<string, Engine> enginesModels)
        {
            for (int i = 0; i < numberEngines; i++)
            {
                var curentEngine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var model = curentEngine[0];
                var power = int.Parse(curentEngine[1]);
                Engine newEngine = null;

                if (curentEngine.Length == 2)
                {
                    newEngine = new Engine(model, power);
                }
                else if (curentEngine.Length == 3)
                {
                    int displacement;
                    bool check = int.TryParse(curentEngine[2], out displacement);
                    if (check)
                    {
                        newEngine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        newEngine = new Engine(model, power, curentEngine[2]);
                    }
                }
                else if (curentEngine.Length == 4)
                {
                    int displacement = int.Parse(curentEngine[2]);
                    newEngine = new Engine(model, power, displacement, curentEngine[3]);
                }

                enginesModels.Add(model, newEngine);
            }
        }
    }
}
