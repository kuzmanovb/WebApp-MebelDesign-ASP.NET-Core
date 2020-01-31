using System;
using System.Collections.Generic;
using System.Linq;

namespace Trojan_Invasion
{
    class Program
    {
        static void Main(string[] args)
        {
            int wavesNumber = int.Parse(Console.ReadLine());

            var platesInput = Console.ReadLine().Split().Select(int.Parse).ToList();
            var platesQueue = new Queue<int>(platesInput);
            var wavesStack = new Stack<int>();

            int curentPlate = 0;

            for (int i = 1; i <= wavesNumber; i++)
            {
                var wavesInput = Console.ReadLine().Split().Select(int.Parse).ToList();
                if (i % 3 == 0)
                {
                    var newPlate = int.Parse(Console.ReadLine());
                    platesQueue.Enqueue(newPlate);
                }
                if (platesQueue.Any())
                {
                    AddWaves(wavesStack, wavesInput);
                }

                while (wavesStack.Any())
                {
                    if (!platesQueue.Any())
                    {
                        break;
                    }
                    if (curentPlate == 0 && platesQueue.Any())
                    {
                        curentPlate = platesQueue.Dequeue();
                    }
                    int curentWaves = wavesStack.Pop();
                    if (curentPlate > curentWaves)
                    {
                        curentPlate -= curentWaves;
                    }
                    else if (curentPlate < curentWaves)
                    {
                        var plateForReturn = curentWaves - curentPlate;

                        wavesStack.Push(plateForReturn);
                        curentPlate = 0;
                    }
                    else if (curentPlate == curentWaves)
                    {
                        curentPlate = 0;
                    }
                }
            }

            if (wavesStack.Any())
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(", ", wavesStack)}");
            }
            else if (platesQueue.Any())
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", platesQueue)}");
            }

        }

        private static void AddWaves(Stack<int> wavesStack, List<int> wavesInput)
        {
            foreach (var item in wavesInput)
            {
                wavesStack.Push(item);

            }
        }
    }
}
