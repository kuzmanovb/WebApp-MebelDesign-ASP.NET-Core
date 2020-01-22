using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {

            var lenghtsNAndM = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var firstElemen = new HashSet<int>();

            for (int i = 0; i < lenghtsNAndM[0]; i++)
            {
                firstElemen.Add(int.Parse(Console.ReadLine()));
            }

            var secandElements = new HashSet<int>();

            for (int i = 0; i < lenghtsNAndM[1]; i++)
            {
                secandElements.Add(int.Parse(Console.ReadLine()));
            }

            foreach (var item in firstElemen)
            {
                if (secandElements.Contains(item))
                {
                    Console.Write(item + " ");
                }
            }

        }
    }
}
