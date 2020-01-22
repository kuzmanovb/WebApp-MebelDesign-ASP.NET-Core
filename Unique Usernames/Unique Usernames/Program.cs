using System;
using System.Collections.Generic;

namespace Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                names.Add(input);
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            
        }
    }
}
