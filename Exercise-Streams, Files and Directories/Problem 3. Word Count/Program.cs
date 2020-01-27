using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace Problem_3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {

            var wordsForChack = File.ReadAllLines("words.txt");

            var textForChack = File.ReadAllText("text.txt").Split(new char[] {' ', '-', '?', '.', ','});

            var actualResult = new Dictionary<string, int>();

            foreach (var word in textForChack)
            {
                if (wordsForChack.Contains(word.ToLower()))
                {
                    if (!actualResult.ContainsKey(word.ToLower()))
                    {
                        actualResult.Add(word.ToLower(), 0);
                    }
                    actualResult[word.ToLower()]++;
                }
            }

        }
    }
}
