using System;
using System.Linq;
using System.Collections.Generic;

namespace Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberInput = int.Parse(Console.ReadLine());

            var numbers = new Dictionary<int, int>();

            for (int i = 0; i < numberInput; i++)
            {
                var curentNumber = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(curentNumber))
                {
                    numbers.Add(curentNumber, 0);
                }
                numbers[curentNumber]++;
            }
            foreach (var item in numbers)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                    break;
                }
            }

        }
    }
}
