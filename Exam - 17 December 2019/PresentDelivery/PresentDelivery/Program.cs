using System;
using System.Linq;

namespace PresentDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputPresent = int.Parse(Console.ReadLine());
            int rowAndCol = int.Parse(Console.ReadLine());
            int curentPresent = 0;

            var matrix = new char[rowAndCol, rowAndCol];
            int santaRow = 0;
            int santaCol = 0;
            int allNiceKids = 0;
            FillMatrixAndFindSantaAndNiceKids(rowAndCol, matrix, ref santaRow, ref santaCol, ref allNiceKids);


            string command = Console.ReadLine();

            while (command != "Christmas morning" && curentPresent < inputPresent)
            {
                // Move Santa
                switch (command)
                {
                    case "up": santaRow--; break;
                    case "down": santaRow++; break;
                    case "left": santaCol--; break;
                    case "right": santaCol++; break;
                }



                // Action depending symbol
                if (matrix[santaRow, santaCol] == 'V')
                {
                    matrix[santaRow, santaCol] = '-';
                    curentPresent++;

                }
                else if (matrix[santaRow, santaCol] == 'C')
                {
                    matrix[santaRow, santaCol] = '-';


                    if (matrix[santaRow, santaCol - 1] != '-')
                    {
                        matrix[santaRow, santaCol - 1] = '-';
                        curentPresent++;
                    }
                    if (matrix[santaRow, santaCol + 1] != '-')
                    {
                        matrix[santaRow, santaCol + 1] = '-';
                        curentPresent++;
                    }
                    if (matrix[santaRow - 1, santaCol] != '-')
                    {
                        matrix[santaRow - 1, santaCol] = '-';
                        curentPresent++;
                    }
                    if (matrix[santaRow + 1, santaCol] != '-')
                    {
                        matrix[santaRow + 1, santaCol] = '-';
                        curentPresent++;
                    }
                }
                else
                {
                    matrix[santaRow, santaCol] = '-';
                }

                // Check available gifts
                if (curentPresent < inputPresent)
                {
               
                //if (curentPresent < inputPresent)
                //{
                    command = Console.ReadLine();
                }
               //}
            }


            matrix[santaRow, santaCol] = 'S';


            //Check for children without gifts
            var checkForLeftNiceKid = 0;
            for (int row = 0; row < rowAndCol; row++)
            {
                for (int col = 0; col < rowAndCol; col++)
                {
                    if (matrix[row, col] == 'V')
                    {
                        checkForLeftNiceKid++;
                    }
                }
            }
           
            if (command != "Christmas morning" && curentPresent == inputPresent)// or (curentPresent == inputPresent && checkForLeftNiceKid > 0)
            {
                Console.WriteLine("Santa ran out of presents!");
            }

            PrintMatrix(rowAndCol, matrix);


            if(checkForLeftNiceKid == 0)
            {
                Console.WriteLine($"Good job, Santa! {allNiceKids} happy nice kid/s.");
            }
            else 
            {
                Console.WriteLine($"No presents for {checkForLeftNiceKid} nice kid/s.");
            }

        }

        private static void PrintMatrix(int rowAndCol, char[,] matrix)
        {
            for (int row = 0; row < rowAndCol; row++)
            {
                for (int col = 0; col < rowAndCol; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }


        private static void FillMatrixAndFindSantaAndNiceKids(int rowAndCol, char[,] matrix, ref int santaRow, ref int santaCol, ref int allNiceKids)
        {
            for (int row = 0; row < rowAndCol; row++)
            {
                var input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < rowAndCol; col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 'S')
                    {
                        santaRow = row;
                        santaCol = col;
                        matrix[row, col] = '-';
                    }
                    if (input[col] == 'V')
                    {
                        allNiceKids++;
                    }
                }
            }
        }
    }
}
