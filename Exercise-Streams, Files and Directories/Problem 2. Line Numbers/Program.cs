using System;
using System.Collections.Generic;
using System.IO;

namespace Problem_2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var stream = File.ReadAllLines("text.txt");

            var outputStream = new List<string>();

            var count = 1;
            foreach (var item in stream)
            {
                var letterInItem = 0;
                var punctuationInItem = 0;

                foreach (var charSymbol in item)
                {
                    if (char.IsLetter(charSymbol))
                    {
                        letterInItem++;
                    }
                    if (char.IsPunctuation(charSymbol))
                    {
                        punctuationInItem++;
                    }
                }
                
                outputStream.Add($"Line {count}: {item} ({letterInItem})({punctuationInItem})");
                count++;
            }


            File.WriteAllLines("output.txt", outputStream);

        }
    }
}
