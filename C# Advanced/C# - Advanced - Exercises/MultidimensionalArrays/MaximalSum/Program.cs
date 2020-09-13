using System;
using System.Linq;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[input[0], input[1]];
            int maxSum = int.MinValue;
            int[,] matrixToPrint = new int[3, 3];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currCol = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currCol[col];
                }
            }
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currMaxSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                        + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                        + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (currMaxSum > maxSum)
                    {
                        maxSum = currMaxSum;
                        int currRow = row;
                        int currCol = col;
                        for (int i = 0; i < matrixToPrint.GetLength(0); i++)
                        {
                            for (int j = 0; j < matrixToPrint.GetLength(1); j++)
                            {
                                matrixToPrint[i, j] = matrix[currRow, currCol];
                                currCol++;
                            }
                            currRow++;
                            currCol = col;
                        }
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int i = 0; i < matrixToPrint.GetLength(0); i++)
            {
                for (int j = 0; j < matrixToPrint.GetLength(1); j++)
                {
                    Console.Write($"{matrixToPrint[i,j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
