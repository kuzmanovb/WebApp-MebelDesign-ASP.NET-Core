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
            var plateQueue = new Queue<int>(platesInput);
            var wavesStack = new Stack<int>();

            for (int i = 1; i <= wavesNumber; i++)
            {
                var curentWaves = Console.ReadLine().Split().Select(int.Parse).ToList();
                AddWaves(wavesStack, curentWaves);
                if (i % 3 == 0)
                {
                    plateQueue.Enqueue(int.Parse(Console.ReadLine()));
                }

                while (plateQueue.Any())
                {
                    int attckPlate = plateQueue.Dequeue();

                    
                    if (wavesStack.Any())
                    {

                    }

                }








            }







        }

        private static void AddWaves(Stack<int> wavesStack, List<int> curentWaves)
        {
            foreach (var item in curentWaves)
            {
                wavesStack.Push(item);

            }
        }
    }
}
