using System;
using System.Collections.Generic;
using System.Linq;

namespace Santa_s_Present_Factory
{
    class Program
    {
        static void Main(string[] args)
        {

            var materials = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var magic = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var products = new SortedDictionary<string, int>()
            {
                {"Doll", 0},
                {"Wooden train", 0 },
                {"Teddy bear", 0 },
                { "Bicycle", 0 }
            };

            var stackMaterials = new Stack<int>(materials);
            var queueMagic = new Queue<int>(magic);

            while (stackMaterials.Any() && queueMagic.Any())
            {
                var flag = false;
                var curentMaterial = stackMaterials.Peek();
                if (curentMaterial == 0)
                {
                    stackMaterials.Pop();
                    flag = true;
                }
               
                var curentMagic = queueMagic.Peek();
                if (curentMagic == 0)
                {
                    queueMagic.Dequeue();
                    flag = true;
                }

                if (flag)
                {
                    continue;
                }

                curentMaterial = stackMaterials.Pop();
                curentMagic = queueMagic.Dequeue();

                var result = curentMaterial * curentMagic;

                if (result < 0)
                {
                    result = curentMaterial + curentMagic;
                    stackMaterials.Push(result);
                }
                else if (result == 150)
                {
                    products["Doll"]++;
                } 
                else if (result == 250)
                {
                    products["Wooden train"]++;
                }
                else if (result == 300)
                {
                    products["Teddy bear"]++;
                }
                else if (result == 400)
                {
                    products["Bicycle"]++;
                }
                else
                {
                    stackMaterials.Push(curentMaterial += 15);
                }

            }

            if (products["Doll"] > 0 && products["Wooden train"] > 0 || products["Teddy bear"] > 0 && products["Bicycle"] > 0)
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }

            if (stackMaterials.Any())
            {
                Console.WriteLine($"Materials left: {string.Join(", ", stackMaterials)}");
            }
            if (queueMagic.Any())
            {
                Console.WriteLine($"Magic left: {string.Join(", ", queueMagic)}");
            }

            foreach (var (key, value) in products)
            {
                if (value > 0)
                {
                    Console.WriteLine($"{key}: {value}");
                }
            }
        }
    }
}
