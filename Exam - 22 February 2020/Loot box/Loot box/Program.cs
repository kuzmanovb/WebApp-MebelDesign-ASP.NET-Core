using System;
using System.Linq;
using System.Collections.Generic;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {

            var firstBox = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var secondBox = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var firstQueue = new Queue<int>(firstBox);
            var secondStack = new Stack<int>(secondBox);

            var allSum = 0;

            while (firstQueue.Any() && secondStack.Any())
            {
                var curentFirst = firstQueue.Peek();
                var curentSecond = secondStack.Pop();
                var sum = curentFirst + curentSecond;

                if (sum % 2 == 0)
                {
                    allSum += sum;
                    firstQueue.Dequeue();
                }
                else
                {
                    firstQueue.Enqueue(curentSecond);
                }

            }

            if (!firstQueue.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (allSum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {allSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {allSum}");
            }
            
        }
    }
}
