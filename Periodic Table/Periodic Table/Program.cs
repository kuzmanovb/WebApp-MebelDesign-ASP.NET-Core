using System;
using System.Collections.Generic;

namespace Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {

            var numberInput = int.Parse(Console.ReadLine());

            var table = new SortedSet<string>();

            for (int i = 0; i < numberInput; i++)
            {
                var curentInput = Console.ReadLine().Split();

                foreach (var element in curentInput)
                {
                    table.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", table));
        }
    }
}
