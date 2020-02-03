using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main(string[] args)
    {
        var members = new List<Person>();
        int inputNumber = int.Parse(Console.ReadLine());

        for (int i = 0; i < inputNumber; i++)
        {
            var input = Console.ReadLine().Split();

            if (int.Parse(input[1]) > 30)
            {
                members.Add(new Person(input[0], int.Parse(input[1])));
            }
        }

        foreach (var person in members.OrderBy(x => x.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }

    }
}

