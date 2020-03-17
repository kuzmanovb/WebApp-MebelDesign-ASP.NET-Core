using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var inputPhonNumber = Console.ReadLine().Split();
            for (int i = 0; i < inputPhonNumber.Length; i++)
            {
                try { Console.WriteLine(new StationaryPhone(inputPhonNumber[i]).PrintNumber()); }
                catch (ArgumentException e) { Console.WriteLine(e.Message); }
            }

            var inputURL = Console.ReadLine().Split();
            for (int i = 0; i < inputURL.Length; i++)
            {
                try { Console.WriteLine(new Smartphone(inputURL[i]).PrintURL()); }
                catch (ArgumentException e) { Console.WriteLine(e.Message); }
            }
        }
    }
}
