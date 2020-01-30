using System;
using System.Linq;

namespace Predicate_for_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthWord = int.Parse(Console.ReadLine());
            var word = Console.ReadLine().Split().ToList();

            word.Where(n => n.Length <= lengthWord).ToList().ForEach(Console.WriteLine);

        }
    }
}
