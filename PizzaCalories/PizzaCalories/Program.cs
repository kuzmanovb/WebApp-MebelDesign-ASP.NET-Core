using System;

namespace PizzaCalories
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var pizzaName = Console.ReadLine().Split();
                var pizza = new Pizza(pizzaName[1]);

                pizza.Dough = MakeDough();

                var inputTopping = Console.ReadLine().Split();
                while (inputTopping[0] != "END")
                {
                    Topping curentTopping = MakeTopping(inputTopping);
                    pizza.addTopping(curentTopping);

                    inputTopping = Console.ReadLine().Split();
                }

                Console.WriteLine($"{pizzaName[1]} - {pizza.calculateCaloriesInPizza():f2} Calories.");

            }
            catch (ArgumentException e)
            {

                Console.WriteLine(e.Message);

            }


        }

        private static Topping MakeTopping(string[] inputTopping)
        {
            var nameTopping = inputTopping[1];
            var gramsTopping = double.Parse(inputTopping[2]);
            var curentTopping = new Topping(nameTopping, gramsTopping);
            return curentTopping;
        }

        private static Dough MakeDough()
        {
            var inputDough = Console.ReadLine().Split();
            var flour = inputDough[1];
            var baking = inputDough[2];
            var gramsDough = double.Parse(inputDough[3]);


            var doughForPizza = new Dough(flour, baking, gramsDough);
            return doughForPizza;
        }
    }
}
