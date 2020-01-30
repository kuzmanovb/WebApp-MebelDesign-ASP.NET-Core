using System;
using System.Collections.Generic;
using System.Linq;

namespace Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToList();

            Func<List<int>, int> minNumber = n => n.Min();

            Console.WriteLine(minNumber(input));
        }
    }
}
