using System;
using System.Collections.Generic;
using System.Linq;

namespace Summer_Cocktails
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputIngredients = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var inputFreshness = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var ingredientsQueue = new Queue<int>(inputIngredients);
            var freshnessStack = new Stack<int>(inputFreshness);

            var coctails = new Dictionary<string, int>()
            {
                {"Daiquiri",0},{"Mimosa",0},{"Mojito",0},{"Sunshine",0} 
            };

            MakeCoctails(ingredientsQueue, freshnessStack, coctails);

            coctails = coctails.Where(c => c.Value > 0).ToDictionary(k => k.Key, v => v.Value);
           
            PrintOutput(ingredientsQueue, coctails);

        }

        private static void PrintOutput(Queue<int> ingredientsQueue, Dictionary<string, int> coctails)
        {
            if (coctails.Count == 4)
            {
                Console.WriteLine("It's party time! The cocktails are ready!");
            }
            else
            {
                Console.WriteLine("What a pity! You didn't manage to prepare all cocktails.");
            }
            if (ingredientsQueue.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredientsQueue.Sum()}");
            }
            foreach (var coctail in coctails)
            {
                Console.WriteLine($" # {coctail.Key} --> {coctail.Value}");
            }
        }

        private static void MakeCoctails(Queue<int> ingredientsQueue, Stack<int> freshnessStack, Dictionary<string, int> coctails)
        {
            while (ingredientsQueue.Any() && freshnessStack.Any())
            {
                var curentIngredient = ingredientsQueue.Dequeue();
                if (curentIngredient == 0)
                {
                    continue;
                }

                var curentFreshness = freshnessStack.Pop();

                var result = curentIngredient * curentFreshness;

                switch (result)
                {
                    case 150:
                        coctails["Mimosa"]++;
                        break;
                    case 250:
                        coctails["Daiquiri"]++;
                        break;
                    case 300:
                        coctails["Sunshine"]++;
                        break;
                    case 400:
                        coctails["Mojito"]++;
                        break;
                    default:
                        ingredientsQueue.Enqueue(curentIngredient + 5);
                        break;
                }

            }
        }
    }
}
