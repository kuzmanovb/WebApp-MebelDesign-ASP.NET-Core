using System;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputOne = Console.ReadLine().Split();
            string fullName= $"{inputOne[0]} {inputOne[1]}";
            string address = inputOne[2];
            var newTupleOne = new Tuple<string, string>(fullName, address);
            Console.WriteLine(newTupleOne);

            var inputTwo = Console.ReadLine().Split();
            string name = inputTwo[0];
            int liters = int.Parse(inputTwo[1]);
            var newTupleTwo = new Tuple<string, int>(name, liters);
            Console.WriteLine(newTupleTwo);

            var inputThree = Console.ReadLine().Split();
            int intNumber = int.Parse(inputThree[0]);
            double doubleNumber = double.Parse(inputThree[1]);
            var newTupleThree = new Tuple<int, double>(intNumber, doubleNumber);
            Console.WriteLine(newTupleThree);

        }
    }
}
