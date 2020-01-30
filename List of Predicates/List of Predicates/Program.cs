using System;
using System.Collections.Generic;
using System.Linq;

namespace List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int endNumber = int.Parse(Console.ReadLine());
            var numberForDivisible = Console.ReadLine().Split().Select(int.Parse).ToList();


            for (int i = 1; i <= endNumber; i++)
            {
                if (CheckNumber(numberForDivisible, i))
                {
                    Console.Write(i + " ");
                }
            }
        }

        static bool CheckNumber(List<int> divisibel, int number)
        {
            var flag = true;
            foreach (var numb in divisibel)
            {
                var result = number * 1.0 % numb;
                if (result != 0)
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }
    }
}
