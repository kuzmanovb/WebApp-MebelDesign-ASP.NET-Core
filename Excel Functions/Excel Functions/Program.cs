using System;
using System.Collections.Generic;
using System.Linq;

namespace Excel_Functions
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberInput = int.Parse(Console.ReadLine());

            var headerInputData = new List<string>();
            var containInputData = new List<List<string>>();
            for (int i = 0; i < numberInput; i++)
            {
                var input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
                if (i == 0)
                {
                    headerInputData = input;
                }
                else
                {
                    containInputData.Add(input);
                }
            }

            var command = Console.ReadLine().Split();

            if (command[0] == "hide")
            {
                HideHeader(containInputData, headerInputData, command);
            }
            else if (command[0] == "sort")
            {
                containInputData = SortByHeader(containInputData, headerInputData, command);
            }
            else if (command[0] == "filter")
            {
                FilterByHeader(containInputData, headerInputData, command);
            }

            PrintContainInputData(containInputData, headerInputData);

        }

        private static void PrintContainInputData(List<List<string>> containInputData, List<string> header)
        {
            Console.WriteLine(string.Join(" | ", header));
            foreach (var item in containInputData)
            {
                Console.WriteLine(string.Join(" | ", item));
            }
        }

        private static void FilterByHeader(List<List<string>> containInputData, List<string> header, string[] command)
        {
            var curentHeader = command[1];
            var value = command[2];
            var indexColumb = FindIndexColumb(header, curentHeader); ;

            for (int i = 0; i < containInputData.Count; i++)
            {
                if (!containInputData[i][indexColumb].Contains(value))
                {
                    containInputData.RemoveAt(i);
                    i -= 1;
                }
            }
        }

        private static List<List<string>> SortByHeader(List<List<string>> containInputData, List<string> header, string[] command)
        {
            var curentHeader = command[1];
            var indexColumb = FindIndexColumb(header, curentHeader);

            if (indexColumb >= 0)
            {
                containInputData = containInputData.OrderBy(x => x[indexColumb]).ToList();
            }
            return containInputData;
        }

        private static void HideHeader(List<List<string>> containInputData, List<string> header, string[] command)
        {
            var curentHeader = command[1];
            var indexColumb = FindIndexColumb(header, curentHeader);
            header.RemoveAt(indexColumb);
            foreach (var item in containInputData)
            {
                item.RemoveAt(indexColumb);
            }
        }

        private static int FindIndexColumb(List<string> header, string curentHeader)
        {
            var index = -1;
            for (int i = 0; i < header.Count; i++)
            {
                if (header[i] == curentHeader)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
    }
}
