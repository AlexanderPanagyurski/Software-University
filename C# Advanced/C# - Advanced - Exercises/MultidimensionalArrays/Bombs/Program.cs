using System;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }
            string[] cordinates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            for (int i = 0; i < cordinates.Length; i++)
            {
                string[] currPair = cordinates[i]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                int currRow = int.Parse(currPair[0]);
                int currCol = int.Parse(currPair[1]);
                if (currRow >= 0 && currRow < matrix.GetLength(0) &&
                    currCol >= 0 && currCol < matrix.GetLength(1))
                {
                    int currElement = matrix[currRow, currCol];
                    if (currElement > 0)
                    {
                        if (currCol >= 0 && currCol < matrix.GetLength(1) - 1 &&
                            matrix[currRow, currCol + 1] > 0)
                        {
                            //int elementFromRight = matrix[currRow, currCol + 1];
                            matrix[currRow, currCol + 1] -= currElement;
                        }
                        if (currCol >= 1 && currCol < matrix.GetLength(1) &&
                            matrix[currRow, currCol - 1] > 0)
                        {
                            //int elementFromLeft = matrix[currRow, currCol - 1];
                            matrix[currRow, currCol - 1] -= currElement;
                        }
                        if (currRow >= 1 && currRow < matrix.GetLength(0) &&
                            matrix[currRow - 1, currCol] > 0)
                        {
                            //int elementAbove = matrix[currRow - 1, currCol];
                            matrix[currRow - 1, currCol] -= currElement;
                        }
                        if (currRow >= 0 && currRow < matrix.GetLength(0) - 1 &&
                            matrix[currRow + 1, currCol] > 0)
                        {
                            //int elementBelow = matrix[currRow + 1, currCol];
                            matrix[currRow + 1, currCol] -= currElement;
                        }
                        if (currRow >= 1 && currRow < matrix.GetLength(0) &&
                            currCol >= 1 && currCol < matrix.GetLength(1) &&
                            matrix[currRow - 1, currCol - 1] > 0)
                        {
                            //int elementMainDiagonalAbove = matrix[currRow - 1, currCol - 1];
                            matrix[currRow - 1, currCol - 1] -= currElement;
                        }
                        if (currRow >= 0 && currRow < matrix.GetLength(0) - 1 &&
                            currCol >= 0 && currCol < matrix.GetLength(1) - 1 &&
                            matrix[currRow + 1, currCol + 1] > 0)
                        {
                            //int elementMainDiagonalBelow = matrix[currRow + 1, currCol + 1];
                            matrix[currRow + 1, currCol + 1] -= currElement;
                        }
                        if (currRow >= 1 && currRow < matrix.GetLength(0) &&
                            currCol >= 0 && currCol < matrix.GetLength(1) - 1 &&
                            matrix[currRow - 1, currCol + 1] > 0)
                        {
                            //int elementSecondDiagonalAbove = matrix[currRow - 1, currCol + 1];
                            matrix[currRow - 1, currCol + 1] -= currElement;
                        }
                        if (currRow >= 0 && currRow < matrix.GetLength(0) - 1 &&
                            currCol >= 1 && currCol < matrix.GetLength(0) &&
                            matrix[currRow + 1, currCol - 1] > 0)
                        {
                            //int elementSecondDiagonalBelow = matrix[currRow + 1, currCol - 1];
                            matrix[currRow + 1, currCol - 1] -= currElement;
                        }
                        matrix[currRow, currCol] = 0;
                    }
                }
            }
            int aliveCellsCount = 0;
            int aliveCellsSum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCellsCount++;
                        aliveCellsSum += matrix[row, col];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {aliveCellsCount}");
            Console.WriteLine($"Sum: {aliveCellsSum}");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
