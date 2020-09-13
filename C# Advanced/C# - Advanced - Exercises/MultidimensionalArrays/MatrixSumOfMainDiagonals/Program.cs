using System;

namespace MatrixSumOfMainDiagonals
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix1 =
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            int sumMainDiagonal = 0;
            int position = 0;

            for (int row = 0; row < matrix1.GetLength(0); row++)
            {
                sumMainDiagonal += matrix1[row, position];
                position++;
            }
            Console.WriteLine($"Sum of the main diagonal = {sumMainDiagonal}");

        }
    }
}
