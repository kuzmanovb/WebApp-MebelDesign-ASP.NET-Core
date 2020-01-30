using System;
using System.Linq;

namespace Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            var input = Console.ReadLine();

            while (input != "end")
            {
                switch (input)
                {
                    case "add":
                            numbers = numbers.Select(n => n + 1).ToList();
                            break;
                    case "multiply":
                            numbers = numbers.Select(n => n * 2).ToList();
                            break;
                    case "subtract":
                            numbers = numbers.Select(n => n - 1).ToList();
                            break;
                    case "print":
                            numbers.ForEach(n => Console.Write(n + " "));
                            Console.WriteLine();
                            break;
                }
                input = Console.ReadLine();
            }
        }
    }
}
