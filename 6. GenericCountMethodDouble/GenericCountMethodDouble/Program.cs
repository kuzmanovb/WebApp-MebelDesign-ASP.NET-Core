using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCountMethodDouble
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<double> list = new List<double>();

            for (int i = 0; i < n; i++)
            {
                list.Add(double.Parse(Console.ReadLine()));
            }

            double element = double.Parse(Console.ReadLine());

            Console.WriteLine(CountOfGreaterThan(list, element));
        }

        public static int CountOfGreaterThan<T>(List<T> list, T element)
            where T : IComparable<T>
        {
            return list.Count(x => x.CompareTo(element) > 0);
        }
    }
}
