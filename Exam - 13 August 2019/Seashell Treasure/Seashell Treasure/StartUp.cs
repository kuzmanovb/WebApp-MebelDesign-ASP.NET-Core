using System;
using System.Collections.Generic;
using System.Linq;

namespace Seashell_Treasure
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var inputRow = int.Parse(Console.ReadLine());

            var jaggedArray = new string[inputRow][];
            FillArray(inputRow, jaggedArray);

            var collection = new List<string>();
            int stolen = 0;

            var command = Console.ReadLine().Split();

            while (command[0] != "Sunset")
            {
                var curentRow = int.Parse(command[1]);
                var curentCol = int.Parse(command[2]);

                var validIndexs = CheckIndexs(inputRow, jaggedArray, curentRow, curentCol);

                if (command[0] == "Collect" && validIndexs)
                {

                    if (jaggedArray[curentRow][curentCol] != "-")
                    {
                        collection.Add(jaggedArray[curentRow][curentCol]);
                        jaggedArray[curentRow][curentCol] = "-";
                    }

                }
                else if (command[0] == "Steal" && validIndexs)
                {
                    if (jaggedArray[curentRow][curentCol] != "-")
                    {
                        stolen++;
                        jaggedArray[curentRow][curentCol] = "-";

                        for (int i = 0; i < 3; i++)
                        {
                            switch (command[3])
                            {
                                case "up": curentRow -= 1; break;
                                case "down": curentRow += 1; break;
                                case "left": curentCol -= 1; break;
                                case "right": curentCol += 1; break;
                            }

                            if (CheckIndexs(inputRow, jaggedArray, curentRow, curentCol))
                            {
                                if (jaggedArray[curentRow][curentCol] != "-")
                                {
                                    stolen++;
                                    jaggedArray[curentRow][curentCol] = "-";
                                }
                            }
                            else
                            {
                                break;
                            }

                        }

                    }
                }

                command = Console.ReadLine().Split();
            }


            for (int row = 0; row < inputRow; row++)
            {
                var length = jaggedArray[row].Length;
                for (int col = 0; col < length; col++)
                {
                    Console.Write(jaggedArray[row][col] + " ");
                }
                Console.WriteLine();
            }

            var collectionToString = string.Join(", ", collection);
            if (!collection.Any())
            {
                Console.WriteLine($"Collected seashells: 0");
            }
            else
            {
                Console.WriteLine($"Collected seashells: {collection.Count} -> {collectionToString}");
            }

            Console.WriteLine($"Stolen seashells: {stolen}");


        }

        static bool CheckIndexs(int inputRow, string[][] jaggedArray, int curentRow, int curentCol)
        {
            if (curentRow >= 0 && curentRow < inputRow)
            {
                if (curentCol >= 0 && curentCol < jaggedArray[curentRow].Length)
                {
                    return true;
                }
            }

            return false;
        }

        private static void FillArray(int inputRow, string[][] jaggedArray)
        {
            for (int row = 0; row < inputRow; row++)
            {
                var input = Console.ReadLine().Split().ToArray();

                jaggedArray[row] = new string[input.Length];

                for (int col = 0; col < input.Length; col++)
                {
                    jaggedArray[row][col] = input[col];
                }
            }
        }
    }
}
