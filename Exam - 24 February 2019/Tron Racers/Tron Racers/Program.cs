using System;

namespace Tron_Racers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            var fpRow = 0;
            var fpCol = 0;
            var spRow = 0;
            var spCol = 0;

            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'f')
                    {
                        fpRow = row;
                        fpCol = col;
                    }
                    if (input[col] == 's')
                    {
                        spRow = row;
                        spCol = col;
                    }
                }
            }

            while (true)
            {
                var command = Console.ReadLine().Split();
                var fpMove = command[0];
                var spMove = command[1];

                switch (fpMove)
                {
                    case "up": fpRow -= 1; if (fpRow < 0) fpRow = n - 1; break;
                    case "left": fpCol -= 1; if (fpCol < 0) fpCol = n - 1; break;
                    case "down": fpRow += 1; if (fpRow > n - 1) fpRow = 0; break;
                    case "right": fpCol += 1; if (fpCol > n - 1) fpCol = 0; break;
                }
                switch (spMove)
                {
                    case "up": spRow -= 1; if (spRow < 0) spRow = n - 1; break;
                    case "left": spCol -= 1; if (spCol < 0) spCol = n - 1; break;
                    case "down": spRow += 1; if (spRow > n - 1) spRow = 0; break;
                    case "right": spCol += 1; if (spCol > n - 1) spCol = 0; break;
                }

                if (matrix[fpRow, fpCol] == '*')
                {
                    matrix[fpRow, fpCol] = 'f';
                }
                else if (matrix[fpRow, fpCol] == 's')
                {
                    matrix[fpRow, fpCol] = 'x';
                    break;
                }

                if (matrix[spRow, spCol] == '*')
                {
                    matrix[spRow, spCol] = 's';
                }
                else if (matrix[spRow, spCol] == 'f')
                {
                    matrix[spRow, spCol] = 'x';
                    break;
                }

            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
