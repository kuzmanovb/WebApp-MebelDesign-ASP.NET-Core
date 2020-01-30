using System;
using System.Collections.Generic;
using System.Linq;

namespace Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine().Split().ToList(); ;

            var listCommands = new List<string>();
            FillListCommands(listCommands);


            for (int i = 0; i < listCommands.Count; i++)
            {
                var commandArr = listCommands[i].Split(';');
                var filter = commandArr[1];
                switch (commandArr[0])
                {
                    case "Starts with":
                        ChackName(name, filter, (n, f) => n.StartsWith(f));
                        break;
                    case "Ends with":
                        ChackName(name, filter, (n, f) => n.EndsWith(f));
                        break;
                    case "Length":
                        ChackName(name, int.Parse(filter), (n, l) => n == l);
                        break;
                    case "Contains":
                        ChackName(name, filter, (n, c) => n.Contains(c));
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", name));
        }

        static void ChackName(List<string> name, string filter, Func<string, string, bool> find)
        {
            for (int i = 0; i < name.Count; i++)
            {
                if (find(name[i], filter))
                {
                    name.RemoveAt(i);
                    i -= 1;
                }
            }
        }
        static void ChackName(List<string> name, int filter, Func<int, int, bool> find)
        {
            for (int i = 0; i < name.Count; i++)
            {
                if (find(name[i].Length, filter))
                {
                    name.RemoveAt(i);
                    i -= 1;
                }
            }
        }

        private static void FillListCommands(List<string> listCommands)
        {
            var commandArr = Console.ReadLine().Split(';');

            while (commandArr[0] != "Print")
            {
                if (commandArr[0] == "Add filter")
                {
                    listCommands.Add(commandArr[1] + ";" + commandArr[2]);
                }
                else if (commandArr[0] == "Remove filter")
                {
                    if (listCommands.Contains(commandArr[1] + ";" + commandArr[2]))
                    {
                        listCommands.Remove(commandArr[1] + ";" + commandArr[2]);
                    }
                }
                commandArr = Console.ReadLine().Split(';');
            }
        }
    }
}
