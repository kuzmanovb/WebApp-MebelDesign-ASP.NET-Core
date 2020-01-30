using System;
using System.Linq;

namespace Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputNumber = Console.ReadLine().Split().Select(int.Parse).ToList();
            var divisibleNumber = int.Parse(Console.ReadLine());

            inputNumber.Where(n => n % divisibleNumber != 0).Reverse().ToList().ForEach(n => Console.Write(n + " "));
        }
    }
}
