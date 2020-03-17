using System;
using System.Linq;
using System.Collections.Generic;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var collect = new List<IBuyer>();

            var numberInput = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberInput; i++)
            {
                var input = Console.ReadLine().Split();
                if (input.Length == 4)
                {
                    var name = input[0];
                    var age = input[1];
                    var id = input[2];
                    var birthdate = input[3];

                    var curentCitizen = new Citizens(name, age, id, birthdate);
                    collect.Add(curentCitizen);
                }
                else if (input.Length == 3)
                {
                    var name = input[0];
                    var age = input[1];
                    var group = input[2];

                    var curentRebel = new Rebel(name, age, group);
                    collect.Add(curentRebel);
                }
            }
            
           
            
            var nameInput = Console.ReadLine();
            while (nameInput != "End")
            {
                foreach (var item in collect)
                {
                    if (item.Name == nameInput)
                    {
                        item.BuyFood();
                    }
                }
                nameInput = Console.ReadLine();
            }

            Console.WriteLine(collect.Sum(x => x.Food));
           
        }
    }
}
