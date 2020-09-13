using System;

namespace InterchangeDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix =
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int col = row;
                var temp = matrix[row,col];
                matrix[row, col] = matrix[row, matrix.GetLength(0) - col - 1];
                matrix[row, matrix.GetLength(0) - col - 1] = temp;
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($" {matrix[row,col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
