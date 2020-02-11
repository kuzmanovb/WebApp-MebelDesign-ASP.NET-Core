using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodStrings
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> list = new List<string>();

            for (int i = 0; i < n; i++)
            {
                list.Add(Console.ReadLine());
            }

            string element = Console.ReadLine();

            Console.WriteLine(CountOfGreaterThan(list, element));
        }

        public static int CountOfGreaterThan<T>(List<T> list, T element)
            where T : IComparable<T>
        {
            return list.Count(x => x.CompareTo(element) > 0);
        }

    }
}
