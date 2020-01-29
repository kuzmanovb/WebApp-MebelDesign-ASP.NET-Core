using System;
using System.Collections.Generic;
using System.Linq;

namespace Socks
{
    class Program
    {
        static void Main(string[] args)
        {
            var leftSocksInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rightSocksInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var leftSocks = new Stack<int>(leftSocksInput);
            var rightSocks = new Queue<int>(rightSocksInput);

            var pairSocks = new List<int>();

            while (leftSocks.Any() && rightSocks.Any())
            {
                var curentLeftSock = leftSocks.Peek();
                var curentRightSock = rightSocks.Peek();

                if (curentLeftSock > curentRightSock)
                {
                    pairSocks.Add(leftSocks.Pop() + rightSocks.Dequeue());
                }
                else if (curentLeftSock < curentRightSock)
                {
                    leftSocks.Pop();
                }
                if (curentLeftSock == curentRightSock)
                {
                    rightSocks.Dequeue();
                    leftSocks.Push(leftSocks.Pop() + 1);
                }

            }

            Console.WriteLine(pairSocks.Max());
            Console.WriteLine(string.Join(" ", pairSocks));
        }
    }
}
