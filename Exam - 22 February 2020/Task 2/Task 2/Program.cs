using System;
using System.Linq;
using System.Collections.Generic;


namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var rowAndCol = int.Parse(Console.ReadLine());
            var countCommand = int.Parse(Console.ReadLine());

            var matrix = new char[rowAndCol, rowAndCol];

            var rowPlayer = 0;
            var colPlayer = 0;
            //Fill Matrix and find player
            for (int row = 0; row < rowAndCol; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < rowAndCol; col++)
                {
                    matrix[row, col] = input[col];

                    if (input[col] == 'f')
                    {
                        rowPlayer = row;
                        colPlayer = col;
                        matrix[row, col] = '-';
                    }
                }
            }

            var checkForWon = false;

            for (int i = 0; i < countCommand; i++)
            {
                var command = Console.ReadLine();
                var checkForOut = false;
                var oldRowPlayer = rowPlayer;
                var oldColPlayer = colPlayer;

                MovePlayer(rowAndCol, ref rowPlayer, ref colPlayer, command, ref checkForOut);

                if (matrix[rowPlayer, colPlayer] == 'F')
                {
                    checkForWon = true;
                    break;
                }
                else if (matrix[rowPlayer, colPlayer] == 'B')
                {
                    MovePlayer(rowAndCol, ref rowPlayer, ref colPlayer, command, ref checkForOut);
                }
                else if (matrix[rowPlayer, colPlayer] == 'T')
                {
                    rowPlayer = oldRowPlayer;
                    colPlayer = oldColPlayer;
                }

            }

            matrix[rowPlayer, colPlayer] = 'f';

            if (checkForWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }
            for (int row = 0; row < rowAndCol; row++)
            {
                for (int col = 0; col < rowAndCol; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }




        }

        private static void MovePlayer(int rowAndCol, ref int rowPlayer, ref int colPlayer, string command, ref bool checkForOut)
        {
            switch (command)
            {
                case "up":
                    if (rowPlayer - 1 >= 0)
                    {
                        rowPlayer -= 1;
                    }
                    else
                    {
                        rowPlayer = rowAndCol - 1;

                    }
                    break;
                case "down":
                    if (rowPlayer + 1 < rowAndCol)
                    {
                        rowPlayer += 1;
                    }
                    else
                    {
                        rowPlayer = 0;
                        checkForOut = true;
                    }
                    break;



                case "left":
                    if (colPlayer - 1 >= 0)
                    {
                        colPlayer -= 1;
                    }
                    else
                    {
                        colPlayer = rowAndCol - 1;
                        checkForOut = true;
                    }
                    break;
                case "right":
                    if (colPlayer + 1 < rowAndCol)
                    {
                        colPlayer += 1;
                    }
                    else
                    {
                        colPlayer = 0;
                        checkForOut = true;
                    }
                    break;

            }
        }
    }
}
