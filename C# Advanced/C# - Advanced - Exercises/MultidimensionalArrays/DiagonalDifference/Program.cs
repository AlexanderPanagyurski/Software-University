using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n =int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int sumPrimaryDiagonal = 0;
            int sumSecondaryDiagonal = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row,col] = currRow[col];
                }
            }
            int currCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sumPrimaryDiagonal += matrix[row, currCol];
                currCol++;
            }
            currCol = matrix.GetLength(0)-1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                sumSecondaryDiagonal += matrix[row, currCol];
                currCol--;
            }
            Console.WriteLine(Math.Abs(sumPrimaryDiagonal-sumSecondaryDiagonal));
        }
    }
}
