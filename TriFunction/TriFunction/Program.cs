using System;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split();
            
            Func<string, int, bool> findName = (s, l) =>
            {
                var sum = 0;
                foreach (var ch in s)
                {
                    sum += (int)ch;
                }
                return sum >= l;
            };


            foreach (var name in names)
            {
                if (findName(name, length))
                {
                    Console.WriteLine(name);
                    break;
                }
            }

        }
    }
}
        
