using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var firstDate = Console.ReadLine();
            var secondDate = Console.ReadLine();

            var betweenDay = new DateModifier(firstDate, secondDate);
            Console.WriteLine(betweenDay.CalculateDifference());

        }
    }
}
