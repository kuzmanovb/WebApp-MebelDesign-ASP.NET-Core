using DefiningClasses;
using System;

namespace Oldest_Family_Member
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int numberInput = int.Parse(Console.ReadLine());
            var members = new Family();

            for (int i = 0; i < numberInput; i++)
            {
                var curentInput = Console.ReadLine().Split();

                members.AddMember(new Person(curentInput[0], int.Parse(curentInput[1])));
            }

            Console.WriteLine(members.GetOldestMember());
        }
    }
}
