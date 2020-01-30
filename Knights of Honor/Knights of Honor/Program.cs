using System;
using System.Collections.Generic;
using System.Linq;

namespace Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Action<List<string>> printList = n => n.ForEach(n => Console.WriteLine($"Sir {n}"));

            printList(input);
        }
    }
}
