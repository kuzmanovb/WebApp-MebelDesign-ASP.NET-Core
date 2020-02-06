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

            var plates = Console.ReadLine().Split().Select(int.Parse).ToList();
            var wavesStack = new Stack<int>();


            for (int i = 1; i <= wavesNumber; i++)
            {
                if (plates.Count == 0)
                {
                    break;
                }

                var wavesInput = Console.ReadLine().Split().Select(int.Parse).ToList();
                AddWaves(wavesStack, wavesInput);

                if (i % 3 == 0)
                {
                    plates.Add(int.Parse(Console.ReadLine()));
                }


                while (wavesStack.Count > 0 && plates.Count > 0)
                {
                    int curentWaves = wavesStack.Pop();
                    int curentPlate = plates[0];

                    if (curentPlate > curentWaves)
                    {
                        plates[0] = curentPlate - curentWaves;

                    }
                    else if (curentWaves > curentPlate)
                    {
                        wavesStack.Push(curentWaves - curentPlate);
                        plates.RemoveAt(0);
                    }
                    else if (curentPlate == curentWaves)
                    {
                        plates.RemoveAt(0);
                    }
                }
            }

            if (wavesStack.Any())
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(", ", wavesStack)}");
            }
            else if (plates.Any())
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
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
