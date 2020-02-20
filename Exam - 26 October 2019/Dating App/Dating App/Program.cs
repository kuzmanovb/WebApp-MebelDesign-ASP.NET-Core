using System;
using System.Collections.Generic;
using System.Linq;

namespace Dating_App
{
    class Program
    {
        static void Main(string[] args)
        {

            var males = Console.ReadLine().Split().Select(int.Parse).ToList();
            var females = Console.ReadLine().Split().Select(int.Parse).ToList();

            var queueFemales = new Queue<int>(females);
            var stackMales = new Stack<int>(males);
            var matches = 0;

            while (queueFemales.Any() && stackMales.Any())
            {

                var curentFemale = queueFemales.Peek();
                if (curentFemale <= 0)
                {
                    queueFemales.Dequeue();
                    continue;
                }
                else if (curentFemale % 25 == 0)
                {
                    queueFemales.Dequeue();

                    if (queueFemales.Any())
                    {
                        queueFemales.Dequeue();
                    }
                    continue;

                }
                var curentMale = stackMales.Peek();
                if (curentMale <= 0)
                {
                    stackMales.Pop();
                    continue;
                }
                else if (curentMale % 25 == 0)
                {
                    stackMales.Pop();

                    if (stackMales.Any())
                    {
                        stackMales.Pop();
                    }
                    continue;
                }

                curentFemale = queueFemales.Dequeue();
                curentMale = stackMales.Pop();

                if (curentFemale != curentMale)
                {
                    stackMales.Push(curentMale - 2);
                }
                else
                {
                    matches++;
                }

            }

            Console.WriteLine($"Matches: {matches}");

            var textForPrintMales = stackMales.Count > 0 ? string.Join(", ", stackMales) : "none";
            var textForPrintFemales = queueFemales.Count > 0 ? string.Join(", ", queueFemales) : "none";

            Console.WriteLine($"Males left: {textForPrintMales}");
            Console.WriteLine($"Females left: {textForPrintFemales}");

        }
    }
}
