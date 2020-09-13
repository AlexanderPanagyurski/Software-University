using System;
using System.Collections.Generic;

namespace HelensAbduction
{
    class Program
    {
        static void Main(string[] args)
        {
            long parisEnergy = long.Parse(Console.ReadLine());
            int rowsCount = int.Parse(Console.ReadLine());
            char[][] matrix = new char[rowsCount][];
            int currRow = -1;
            int currCol = -1;
            bool isDead = false;

            for (int rows = 0; rows < matrix.Length; rows++)
            {
                var currRowInput = Console.ReadLine().ToCharArray();
                matrix[rows] = new char[currRowInput.Length];
                for (int cols = 0; cols < matrix[rows].Length; cols++)
                {
                    matrix[rows][cols] = currRowInput[cols];
                    if (matrix[rows][cols] == 'P')
                    {
                        currRow = rows;
                        currCol = cols;
                    }
                }
            }
            while (true)
            {
                string[] currCommand = Console.ReadLine()
                     .Split();
                int spawnRow = int.Parse(currCommand[1]);
                int spawnCol = int.Parse(currCommand[2]);
                parisEnergy--;
                string direction = currCommand[0];
                if (spawnRow >= 0 && spawnRow < matrix.Length &&
                    spawnCol >= 0 && spawnCol < matrix[spawnRow].Length && matrix[spawnRow][spawnCol] == '-')
                {
                    matrix[spawnRow][spawnCol] = 'S';
                }
                if (direction == "up" && currRow - 1 >= 0
                    && currRow - 1 < matrix.GetLength(0))
                {
                    if (currRow != spawnRow || currCol != spawnCol)
                    {
                        matrix[currRow][currCol] = '-';
                    }
                    --currRow;

                    if (matrix[currRow][currCol] == '-')
                    {
                        matrix[currRow][currCol] = 'P';
                    }

                    else if (matrix[currRow][currCol] == 'S')
                    {
                        parisEnergy -= 2;
                        if (parisEnergy <= 0)
                        {
                            isDead = true;
                            matrix[currRow][currCol] = 'X';
                            break;
                        }
                    }
                    else if (matrix[currRow][currCol] == 'H')
                    {
                        matrix[currRow][currCol] = '-';
                        break;
                    }
                }
                else if (direction == "down" && currRow + 1 >= 0
                    && currRow + 1 < matrix.GetLength(0))
                {
                    if (currRow != spawnRow || currCol != spawnCol)
                    {
                        matrix[currRow][currCol] = '-';
                    }
                    ++currRow;

                    if (matrix[currRow][currCol] == '-')
                    {
                        matrix[currRow][currCol] = 'P';
                    }

                    else if (matrix[currRow][currCol] == 'S')
                    {
                        parisEnergy -= 2;
                        if (parisEnergy <= 0)
                        {
                            isDead = true;
                            matrix[currRow][currCol] = 'X';
                            break;
                        }
                    }
                    else if (matrix[currRow][currCol] == 'H')
                    {
                        matrix[currRow][currCol] = '-';
                        isDead = false;
                        break;
                    }
                }
                else if (direction == "left" && currCol - 1 >= 0
                    && currCol - 1 < matrix.Length)
                {
                    if (currRow != spawnRow || currCol != spawnCol)
                    {
                        matrix[currRow][currCol] = '-';
                    }
                    --currCol;

                    if (matrix[currRow][currCol] == '-')
                    {
                        matrix[currRow][currCol] = 'P';
                    }

                    else if (matrix[currRow][currCol] == 'S')
                    {
                        parisEnergy -= 2;
                        if (parisEnergy <= 0)
                        {
                            isDead = true;
                            matrix[currRow][currCol] = 'X';
                            break;
                        }
                    }
                    else if (matrix[currRow][currCol] == 'H')
                    {
                        matrix[currRow][currCol] = '-';
                        isDead = false;
                        break;
                    }
                }
                else if (direction == "right" && currCol + 1 >= 0
                    && currCol + 1 < matrix[currRow].Length)
                {
                    if (currRow != spawnRow || currCol != spawnCol)
                    {
                        matrix[currRow][currCol] = '-';
                    }
                    ++currCol;

                    if (matrix[currRow][currCol] == '-')
                    {
                        matrix[currRow][currCol] = 'P';
                    }

                    else if (matrix[currRow][currCol] == 'S')
                    {
                        parisEnergy -= 2;
                        if (parisEnergy <= 0)
                        {
                            isDead = true;
                            matrix[currRow][currCol] = 'X';
                            break;
                        }
                    }
                    else if (matrix[currRow][currCol] == 'H')
                    {
                        matrix[currRow][currCol] = '-';
                        isDead = false;
                        break;
                    }
                }
                //--------------------------------------------------------
                if (parisEnergy <= 0)
                {
                    isDead = true;
                    matrix[currRow][currCol] = 'X';
                    break;
                }
            }
            if (isDead)
            {
                Console.WriteLine($"Paris died at {currRow};{currCol}.");
            }
            else
            {
                Console.WriteLine($"Paris has successfully abducted Helen! Energy left: {parisEnergy}");
            }

            for (int rows = 0; rows < matrix.Length; rows++)
            {
                for (int cols = 0; cols < matrix[rows].Length; cols++)
                {
                    Console.Write(matrix[rows][cols]);
                }
                Console.WriteLine();
            }
        }
    }
}
