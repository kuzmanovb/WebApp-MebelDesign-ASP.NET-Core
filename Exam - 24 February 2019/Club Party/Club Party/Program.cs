using System;
using System.Linq;
using System.Collections.Generic;

namespace Club_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            var capacityHall = int.Parse(Console.ReadLine());

            var inputArr = Console.ReadLine().Split();
            var stackInput = new Stack<string>(inputArr);

            var hallsName = new Queue<string>();
            var peopleInHall = new Queue<string>();

            var count = capacityHall;
            foreach (var item in stackInput)
            {
                if (char.IsLetter(item[0]))
                {
                    hallsName.Enqueue(item);
                }
                else
                {
                    if (hallsName.Any())
                    {

                        count -= int.Parse(item);
                        if (count >= 0)
                        {
                            peopleInHall.Enqueue(item);
                        }
                        else
                        {
                            var name = hallsName.Dequeue();
                            var reservation = string.Join(", ", peopleInHall);
                            Console.WriteLine($"{name} -> {reservation}");

                            peopleInHall.Clear();
                            count = capacityHall;
                            if (hallsName.Any())
                            {
                                peopleInHall.Enqueue(item);
                                count -= int.Parse(item);
                            }
                        }
                    }
                }
            }
        }
    }
}
