using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                list.Add(input);
            }

            var indexForSwap = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Swap(list, indexForSwap[0], indexForSwap[1]);

            foreach (var item in list)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }
                
        }
        static void Swap<T>(List<T> list, int indexOne, int indexTwo)
        {
            T firstValue = list[indexOne];
            list[indexOne] = list[indexTwo];
            list[indexTwo] = firstValue;
            
        }
    }
}
