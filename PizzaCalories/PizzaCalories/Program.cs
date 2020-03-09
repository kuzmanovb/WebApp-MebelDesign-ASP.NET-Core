using System;

namespace PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            var dough = new Dough(input[1], input[2], double.Parse(input[3]));

        }
    }
}
