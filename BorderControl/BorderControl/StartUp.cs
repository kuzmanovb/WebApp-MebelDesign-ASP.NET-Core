using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var collect = new List<IId>();

            var input = Console.ReadLine().Split();
            while (input[0] != "End")
            {
                if (input.Length == 3)
                {
                    var name = input[0];
                    var age = input[1];
                    var id = input[2];
                    var curentCitizen = new Citizens(name, age, id);
                    collect.Add(curentCitizen);
                }
                else
                {
                    var model = input[0];
                    var id = input[1];
                    var curentRobot = new Robots(model, id);
                    collect.Add(curentRobot);
                }

                input = Console.ReadLine().Split();
            }

            var filter = Console.ReadLine();
            
            foreach (var item in collect)
            {
                if (item.Id.EndsWith(filter))
                {
                    Console.WriteLine(item.Id);
                }
            }
        }
    }
}
