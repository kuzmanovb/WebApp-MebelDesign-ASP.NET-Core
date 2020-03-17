using System;
using System.Collections.Generic;

namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var collect = new List<IBirthdate>();

            var input = Console.ReadLine().Split();
            while (input[0] != "End")
            {
                if (input[0] == "Citizen")
                {
                    var name = input[1];
                    var age = input[2];
                    var id = input[3];
                    var birthdate = input[4];
                    
                    var curentCitizen = new Citizens(name, age, id, birthdate);
                    collect.Add(curentCitizen);
                }
                else if (input[0] == "Pet")
                {
                    var name = input[1];
                    var birthdate = input[2];
                    var curentPet = new Pet(name, birthdate);
                    collect.Add(curentPet);
                }

                input = Console.ReadLine().Split();
            }

            var filter = Console.ReadLine();
            
            foreach (var item in collect)
            {
                if (item.Birthdate.EndsWith(filter))
                {
                    Console.WriteLine(item.Birthdate);
                }
            }
        }
    }
}
