using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P02_CarsSalesman
{
   
    class CarSalesman
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            HashSet<Engine> engines = new HashSet<Engine>();
            
            int engineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < engineCount; i++)
            {
                string[] parametersEngine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                engines.Add(CreateEngine(parametersEngine));
            }

            int carCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carCount; i++)
            {
                string[] parametersCar = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                cars.Add(CreateCar(engines,parametersCar));
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static Car CreateCar(HashSet<Engine> engines, string[] parametersCar)
        {
            string model = parametersCar[0];
            string engineModel = parametersCar[1];
            Engine engine = engines.FirstOrDefault(x => x.Model == engineModel);

            int weight = -1;

            if (parametersCar.Length == 3 && int.TryParse(parametersCar[2], out weight))
            {
               return new Car(model, engine, weight);
            }
            else if (parametersCar.Length == 3)
            {
                string color = parametersCar[2];
                return new Car(model, engine, color);
            }
            else if (parametersCar.Length == 4)
            {
                string color = parametersCar[3];
                return new Car(model, engine, int.Parse(parametersCar[2]), color);
            }
            else
            {
                return new Car(model, engine);
            }
        }

        private static Engine CreateEngine(string[] parametersEngine)
        {

            string model = parametersEngine[0];
            int power = int.Parse(parametersEngine[1]);
            int displacement = -1;

            if (parametersEngine.Length == 3 && int.TryParse(parametersEngine[2], out displacement))
            {
                return new Engine(model, power, displacement);
            }
            else if (parametersEngine.Length == 3)
            {
                string efficiency = parametersEngine[2];
                return new Engine(model, power, efficiency);
            }
            else if (parametersEngine.Length == 4)
            {
                displacement = int.Parse(parametersEngine[2]);
                string efficiency = parametersEngine[3];
                return new Engine(model, power, displacement, efficiency);
            }
            else
            {
                return new Engine(model, power);
            }
        }
    }

}
