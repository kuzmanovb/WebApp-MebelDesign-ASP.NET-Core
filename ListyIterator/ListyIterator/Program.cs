using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    class Program
    {
        static void Main(string[] args)
        {

            var command = Console.ReadLine();
            ListyIterator<string> newlistyIterator = null;
            while (command != "END")
            {
               
                if (command.StartsWith("Create"))
                {
                    var commandArr = command.Split();
                    var listForCreat = commandArr.TakeLast(commandArr.Length - 1).ToList();
                    newlistyIterator = new ListyIterator<string>(listForCreat);
                }

            }




            Console.WriteLine("Hello World!");
        }


    }
}
