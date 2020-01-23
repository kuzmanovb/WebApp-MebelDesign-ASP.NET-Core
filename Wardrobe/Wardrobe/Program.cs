using System;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberInput = int.Parse(Console.ReadLine());

            var wardrobe = new Dictionary<string, Dictionary<string, int>>();
            FillWardrobe(numberInput, wardrobe);

            var dressForCheck = Console.ReadLine().Split();
           
            PrintWardrobe(wardrobe, dressForCheck);
        }

        private static void PrintWardrobe(Dictionary<string, Dictionary<string, int>> wardrobe, string[] dressForCheck)
        {
            foreach (var (key, value) in wardrobe)
            {
                Console.WriteLine($"{key} clothes:");
                foreach (var item in value)
                {
                    if (key == dressForCheck[0] && item.Key == dressForCheck[1])
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }

        private static void FillWardrobe(int numberInput, Dictionary<string, Dictionary<string, int>> wardrobe)
        {
            for (int i = 0; i < numberInput; i++)
            {
                var input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                var color = input[0];
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                var clothes = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in clothes)
                {
                    if (!wardrobe[input[0]].ContainsKey(item))
                    {
                        wardrobe[input[0]].Add(item, 0);
                    }
                    wardrobe[input[0]][item]++;
                }
            }
        }

    }
}
