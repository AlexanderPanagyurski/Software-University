using System;

namespace MatrixSumOfColAndRow
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix =
            {
                { 1, 2, 3, 4 },
                { 4, 5, 6, 5 },
                { 7, 8, 9, 6 },
                { 11, 12, 14, 6}
            };
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int sum = 0;
                for (int position = 0; position < matrix.GetLength(0); position++)
                {
                    sum += matrix[row, position];
                }
                Console.WriteLine($"Sum of row {row + 1}: {sum}");
            }
            int index = 0;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sum += matrix[row, index];
                }
                index++;

                Console.WriteLine($"Sum of col {col + 1}: {sum}");
            }
        }
    }
}
