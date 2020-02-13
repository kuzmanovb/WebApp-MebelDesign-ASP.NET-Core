using System;
using System.Collections.Generic;
using System.Linq;

namespace Spaceship_Crafting
{
    class Program
    {
        static void Main(string[] args)
        {
            var elements = new SortedDictionary<string, int>
            {
                { "Aluminium", 0},
                { "Carbon fiber", 0},
                { "Glass", 0},
                { "Lithium", 0}
            };

            var inputLiquids = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var inputItem = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            var queueLiquids = new Queue<int>(inputLiquids);
            var stackItem = new Stack<int>(inputItem);

            while (queueLiquids.Any() && stackItem.Any())
            {
                var curentItem = stackItem.Pop();
                var sumOfLiquidAndItem = queueLiquids.Dequeue() + curentItem;
                switch (sumOfLiquidAndItem)
                {
                    case 25:
                        elements["Glass"]++; 
                        break;
                    case 50:
                        elements["Aluminium"]++; 
                        break;
                    case 75:
                        elements["Lithium"]++; 
                        break;
                    case 100:
                        elements["Carbon fiber"]++; 
                        break;
                    default:
                        stackItem.Push(curentItem + 3);
                        break;
                }
            }

            var check = elements.Where(x => x.Value > 0).ToList();

            if (check.Count == 4)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }
            if (!queueLiquids.Any())
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                var liquidsLeft = string.Join(", ", queueLiquids);
                Console.WriteLine($"Liquids left: {liquidsLeft}");
            }
            if (!stackItem.Any())
            {
                Console.WriteLine("Physical items left: none");
            }
            else
            {
                var itemLeft = string.Join(", ", stackItem);
                Console.WriteLine($"Physical items left: {itemLeft}");
            }
            foreach (var (key, value) in elements)
            {
                Console.WriteLine($"{key}: {value}");
            }
        }

    }
}
