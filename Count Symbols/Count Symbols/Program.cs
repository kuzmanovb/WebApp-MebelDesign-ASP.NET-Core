using System;
using System.Collections.Generic;

namespace Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputString = Console.ReadLine().ToCharArray();

            var symbols = new SortedDictionary<char, int>();

            foreach (var item in inputString)
            {
                if (!symbols.ContainsKey(item))
                {
                    symbols.Add(item, 0);
                }
                symbols[item]++;
            }

            foreach (var (key, value) in symbols)
            {
                Console.WriteLine($"{key}: {value} time/s");
            }

        }
    }
}
