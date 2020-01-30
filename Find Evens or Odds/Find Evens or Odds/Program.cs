using System;
using System.Collections.Generic;
using System.Linq;

namespace Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputRangeNumber = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            var oddOrEven = Console.ReadLine();


            Console.WriteLine(string.Join(" ", FindOddsOrEvansNumber(inputRangeNumber, oddOrEven)));

        }
        static List<int> FindOddsOrEvansNumber(List<int> numbers, string oddOrEvens)
        {

            var selectedNumber = new List<int>();

            for (int i = numbers[0]; i <= numbers[1]; i++)
            {
                if (oddOrEvens == "odd" && i % 2 != 0)
                {
                    selectedNumber.Add(i);
                }
                else if (oddOrEvens == "even" && i % 2 == 0)
                {
                    selectedNumber.Add(i);
                }
               
            }

            return selectedNumber;
        }
    }
}
