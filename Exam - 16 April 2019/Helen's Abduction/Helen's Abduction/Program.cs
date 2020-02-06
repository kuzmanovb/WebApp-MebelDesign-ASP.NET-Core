using System;

namespace Helen_s_Abduction
{
    class Program
    {
        static void Main(string[] args)
        {
            var energy = int.Parse(Console.ReadLine());
            var rowLength = int.Parse(Console.ReadLine());
            var colLength = 0;
            var matrix = new char[rowLength][];

            var rowParis = 0;
            var colParis = 0;

            // Fill matrix and find Paris
            for (int row = 0; row < rowLength; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                matrix[row] = new char[input.Length];
                colLength = input.Length;
                for (int col = 0; col < colLength; col++)
                {
                    matrix[row][col] = input[col];
                    if (input[col] == 'P')
                    {
                        rowParis = row;
                        colParis = col;
                        matrix[row][col] = '-';
                    }
                }
            }

            while (energy > 0)
            {
                var command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var move = command[0];
                var rowSpawn = int.Parse(command[1]);
                var colSpawn = int.Parse(command[2]);
                if (rowSpawn >= 0 && rowSpawn < rowLength && colSpawn >= 0 && colSpawn < colLength)
                {
                    matrix[rowSpawn][colSpawn] = 'S';
                }

                // Decreases energy and move Paris 
                energy--;
                switch (move)
                {
                    case "up":
                        if (rowParis > 0) rowParis--;
                        break;
                    case "down":
                        if (rowParis < rowLength - 1) rowParis++;
                        break;
                    case "left":
                        if (colParis > 0) colParis--;
                        break;
                    case "right":
                        if (colParis < colLength - 1) colParis++;
                        break;
                }

                //Check cell
                if (matrix[rowParis][colParis] == 'H')
                {
                    matrix[rowParis][colParis] = '-';
                    Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {energy}");
                    break;
                }
                else if (energy <= 0)
                {
                    matrix[rowParis][colParis] = 'X';
                    Console.WriteLine($"Paris died at {rowParis};{colParis}.");
                    break;
                }
                else if (matrix[rowParis][colParis] == 'S')
                {
                    energy -= 2;
                    if (energy > 0)
                    {
                        matrix[rowParis][colParis] = '-';
                    }
                    else
                    {
                        matrix[rowParis][colParis] = 'X';
                        Console.WriteLine($"Paris died at {rowParis};{colParis}.");
                        break;
                    }
                }
                
            }

            PrintMatrix(rowLength, colLength, matrix);

        }

        private static void PrintMatrix(int rowAndCol, int colLength, char[][] matrix)
        {
            for (int row = 0; row < rowAndCol; row++)
            {
                for (int col = 0; col < colLength; col++)
                {
                    Console.Write(matrix[row][col]);
                }
                Console.WriteLine();
            }
        }
    }
}
