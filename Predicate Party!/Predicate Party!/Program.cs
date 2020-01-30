using System;
using System.Collections.Generic;
using System.Linq;

namespace Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            var peopleInParty = Console.ReadLine().Split().ToList();

            var input = Console.ReadLine();

            while (input != "Party!")
            {
                var inputArr = input.Split();
                string removeOrDouble = inputArr[0];
                string command = inputArr[1];
                string filter = inputArr[2];

                switch (command)
                {
                    case "StartsWith":
                        RunningCommand(peopleInParty, removeOrDouble, filter, (s, f) => s.StartsWith(f));
                        break;
                    case "EndsWith":
                        RunningCommand(peopleInParty, removeOrDouble, filter, (s, f) => s.EndsWith(f));
                        break;
                    case "Length":
                        RunningCommand(peopleInParty, removeOrDouble, int.Parse(filter), (s, f) => s == f);
                        break;
                }

                input = Console.ReadLine();
            }

            PrintParty(peopleInParty);

        }


        static void RunningCommand(List<string> name, string command, string filter, Func<string, string, bool> check)
        {

            for (int i = 0; i < name.Count; i++)
            {
                if (check(name[i], filter))
                {
                    if (command == "Remove")
                    {
                        name.RemoveAt(i);
                        i -= 1;
                    }
                    else if (command == "Double")
                    {
                        name.Insert(i + 1, name[i]);
                        i += 1;
                    }
                }
            }
        }
        static void RunningCommand(List<string> name,string command, int filter, Func<int, int, bool> check)
        {

            for (int i = 0; i < name.Count; i++)
            {
                if (check(name[i].Length, filter))
                {
                    if (command == "Remove")
                    {
                        name.RemoveAt(i);
                        i -= 1;
                    }
                    else if (command == "Double")
                    {
                        name.Insert(i + 1, name[i]);
                        i += 1;
                    }
                }
            }
        }
        private static void PrintParty(List<string> peopleInParty)
        {
            if (peopleInParty.Any())
            {
                string people = string.Join(", ", peopleInParty);
                Console.WriteLine($"{people} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
