using System;

namespace P06_Sneaking
{
    class Sneaking
    {
        static char[][] room;
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            room = new char[n][];
            FillRoom(n);

            var samRow = 0;
            var samCol = 0;
            FindSamPosition(ref samRow, ref samCol);
            
            var commandsForMove = Console.ReadLine().ToCharArray();
            
            for (int i = 0; i < commandsForMove.Length; i++)
            {
                MoveEnemies();

                var enemyRow = 0;
                var enemyCol = 0;
                FindEnemyInSamRow(samRow, ref enemyRow, ref enemyCol);

                CheckForKilledSam(samRow, samCol, enemyRow, enemyCol);

                room[samRow][samCol] = '.';

                MoveSamNextPosition(ref samRow, ref samCol, commandsForMove, i);

                room[samRow][samCol] = 'S';

                FindEnemyInSamRow(samRow, ref enemyRow, ref enemyCol);

                CheckForNikoladzeInSamRow(samRow, enemyRow, enemyCol);
            }
        }

        private static void CheckForNikoladzeInSamRow(int samRow, int enemyRow, int enemyCol)
        {
            if (room[enemyRow][enemyCol] == 'N' && samRow == enemyRow)
            {
                room[enemyRow][enemyCol] = 'X';
                Console.WriteLine("Nikoladze killed!");
                for (int row = 0; row < room.Length; row++)
                {
                    for (int col = 0; col < room[row].Length; col++)
                    {
                        Console.Write(room[row][col]);
                    }
                    Console.WriteLine();
                }
                Environment.Exit(0);
            }
        }

        private static void CheckForKilledSam(int samRow, int samCol, int enemyRow, int enemyCol)
        {
            if (samCol < enemyCol && room[enemyRow][enemyCol] == 'd' && enemyRow == samRow)
            {
                room[samRow][samCol] = 'X';
                Console.WriteLine($"Sam died at {samRow}, {samCol}");
                for (int row = 0; row < room.Length; row++)
                {
                    for (int col = 0; col < room[row].Length; col++)
                    {
                        Console.Write(room[row][col]);
                    }
                    Console.WriteLine();
                }
                Environment.Exit(0);
            }
            else if (enemyCol < samCol && room[enemyRow][enemyCol] == 'b' && enemyRow == samRow)
            {
                room[samRow][samCol] = 'X';
                Console.WriteLine($"Sam died at {samRow}, {samCol}");
                for (int row = 0; row < room.Length; row++)
                {
                    for (int col = 0; col < room[row].Length; col++)
                    {
                        Console.Write(room[row][col]);
                    }
                    Console.WriteLine();
                }
                Environment.Exit(0);
            }
        }

        private static void MoveSamNextPosition(ref int samRow, ref int samCol, char[] commandsForMove, int i)
        {
            switch (commandsForMove[i])
            {
                case 'U':
                    samRow--;
                    break;
                case 'D':
                    samRow++;
                    break;
                case 'L':
                    samCol--;
                    break;
                case 'R':
                    samCol++;
                    break;
                default:
                    break;
            }
        }

        private static void FindEnemyInSamRow(int samRow, ref int enemyRow, ref int enemyCol)
        {
            for (int j = 0; j < room[samRow].Length; j++)
            {
                if (room[samRow][j] != '.' && room[samRow][j] != 'S')
                {
                    enemyRow = samRow;
                    enemyCol = j;
                }
            }
        }

        private static void MoveEnemies()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            room[row][col] = 'd';
                        }
                    }
                    else if (room[row][col] == 'd')
                    {
                        if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        else
                        {
                            room[row][col] = 'b';
                        }
                    }
                }
            }
        }

        private static void FindSamPosition(ref int samRow, ref int samCol)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        samRow = row;
                        samCol = col;
                    }
                }
            }
        }

        private static void FillRoom(int n)
        {
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                room[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    room[row][col] = input[col];
                }
            }
        }
    }
}
