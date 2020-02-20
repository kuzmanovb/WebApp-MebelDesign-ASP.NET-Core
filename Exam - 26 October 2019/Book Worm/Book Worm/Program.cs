using System;
using System.Collections.Generic;
using System.Linq;

namespace Book_Worm
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputStartString = Console.ReadLine().ToCharArray();
            var rowAndCol = int.Parse(Console.ReadLine());
            var rowPlayer = 0;
            var colPlayer = 0;

            var matrix = new char[rowAndCol, rowAndCol];
            var collectedChar = new Stack<char>(inputStartString);

            FillMatrixAndFindPlayer(rowAndCol, ref rowPlayer, ref colPlayer, matrix);

            var command = Console.ReadLine();

            while (command != "end")
            {
                var checkForInside = false;
                MovePlayerAndCheckInsideOrOutside(rowAndCol, ref rowPlayer, ref colPlayer, command, ref checkForInside);

                if (checkForInside)
                {

                    if (matrix[rowPlayer, colPlayer] != '-')
                    {
                        collectedChar.Push(matrix[rowPlayer, colPlayer]);
                        matrix[rowPlayer, colPlayer] = '-';
                    }
                }
                else
                {
                    if (collectedChar.Any())
                    {
                        collectedChar.Pop();
                    }
                }

                command = Console.ReadLine();
            }

            matrix[rowPlayer, colPlayer] = 'P';

            Console.WriteLine(string.Join("", collectedChar.Reverse()));
            
            PrintMatrix(rowAndCol, matrix);

        }

        private static void PrintMatrix(int rowAndCol, char[,] matrix)
        {
            for (int row = 0; row < rowAndCol; row++)
            {
                for (int col = 0; col < rowAndCol; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void MovePlayerAndCheckInsideOrOutside(int rowAndCol, ref int rowPlayer, ref int colPlayer, string command, ref bool checkForInside)
        {
            switch (command)
            {
                case "up":
                    if (rowPlayer - 1 >= 0)
                    { rowPlayer = rowPlayer - 1; checkForInside = true; };
                    break;
                case "down":
                    if (rowPlayer + 1 < rowAndCol)
                    { rowPlayer = rowPlayer + 1; checkForInside = true; };
                    break;
                case "left":
                    if (colPlayer - 1 >= 0)
                    { colPlayer = colPlayer - 1; checkForInside = true; };
                    break;
                case "right":
                    if (colPlayer + 1 < rowAndCol)
                    { colPlayer = colPlayer + 1; checkForInside = true; };
                    break;
            }
        }


        private static void FillMatrixAndFindPlayer(int rowAndCol, ref int rowPlayer, ref int colPlayer, char[,] matrix)
        {
            for (int row = 0; row < rowAndCol; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < rowAndCol; col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == 'P')
                    {
                        rowPlayer = row;
                        colPlayer = col;
                        matrix[row, col] = '-';
                    }
                }

            }
        }
    }
}
