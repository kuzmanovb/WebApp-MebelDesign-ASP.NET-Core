using System;
using System.Linq;
using System.IO;
using System.Text;

namespace Problem_1._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            var stream = new StreamReader("text.txt");

            var counter = 0;

            var curentLine = stream.ReadLine();
            while (curentLine != null)
            {
                if (counter % 2 == 0)
                {
                    var sb = new StringBuilder();
                    char[] symbolsForChange = { '-', ',', '.', '!', '?' };

                    for (int i = 0; i < curentLine.Length; i++)
                    {
                        if (symbolsForChange.Contains(curentLine[i]))
                        {
                            sb.Append('@');
                        }
                        else
                        {
                            sb.Append(curentLine[i]);
                        }
                    }
                    var replaceLine = sb.ToString().Split().Reverse().ToArray();
                    Console.WriteLine(string.Join(" ", replaceLine));
                }

                counter++;

                curentLine = stream.ReadLine();
            }


        }
    }
}
