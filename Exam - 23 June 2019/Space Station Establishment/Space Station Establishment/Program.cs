using System;
using System.Linq;

namespace Space_Station_Establishment
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];
            int stefansRow = 0;
            int stefansCol = 0;
            // Fill matrix and find Stefan
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'S')
                    {
                        stefansRow = row;
                        stefansCol = col;
                        matrix[row, col] = '-';
                    }
                }
            }

            double starPower = 0;
            var inside = true;

            while (starPower < 50 && inside)
            {
                var command = Console.ReadLine();

                switch (command)
                {
                    case "up":
                        stefansRow--; 
                        if (stefansRow < 0) inside = false;
                        else manipulationMatrix(n, matrix, ref stefansRow, ref stefansCol, ref starPower);
                        break;
                    case "down":
                        stefansRow++; 
                        if (stefansRow >= n) inside = false;
                        else manipulationMatrix(n, matrix, ref stefansRow, ref stefansCol, ref starPower);
                        break;
                    case "left":
                        stefansCol--;
                        if (stefansCol < 0) inside = false;
                        else manipulationMatrix(n, matrix, ref stefansRow, ref stefansCol, ref starPower);
                        break;
                    case "right":
                        stefansCol++;
                        if (stefansCol >= n) inside = false;
                        else manipulationMatrix(n, matrix, ref stefansRow, ref stefansCol, ref starPower);
                        break;

                }
            }

            if (inside)
            {
                Console.WriteLine("Good news! Stephen succeeded in collecting enough star power!");
                matrix[stefansRow, stefansCol] = 'S';
            }
            else
            {
                Console.WriteLine("Bad news, the spaceship went to the void.");
            }

            Console.WriteLine($"Star power collected: {starPower}");
            
            PrintMatrix(n, matrix);

        }

        private static void PrintMatrix(int n, char[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void manipulationMatrix(int n, char[,] matrix, ref int stefansRow, ref int stefansCol, ref double starPower)
        {
            if (char.IsDigit(matrix[stefansRow, stefansCol]))
            {
                starPower += char.GetNumericValue(matrix[stefansRow, stefansCol]);
                matrix[stefansRow, stefansCol] = '-';
            }
            else if (matrix[stefansRow, stefansCol] == 'O')
            {
                matrix[stefansRow, stefansCol] = '-';
                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (matrix[row, col] == 'O')
                        {
                            matrix[row, col] = '-';
                            stefansRow = row;
                            stefansCol = col;
                        }
                    }
                }
            }
        }
    }
}
