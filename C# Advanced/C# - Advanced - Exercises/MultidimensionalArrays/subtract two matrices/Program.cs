using System;

namespace subtract_two_matrices
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix1 =
            {
                { 1, 2 ,3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            int[,] matrix2 =
            {
                { 9, 8, 7 },
                { 6, 5, 4 },
                { 3, 2, 1 }
            };
            int[,] matrix3 = new int[3, 3];
            for (int row = 0; row < matrix1.GetLength(0); row++)
            {
                for (int col = 0; col < matrix1.GetLength(1); col++)
                {
                    Console.Write($" {matrix1[row,col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-',8));

            for (int row = 0; row < matrix2.GetLength(0); row++)
            {
                for (int col = 0; col < matrix2.GetLength(1); col++)
                {
                    Console.Write($" {matrix2[row,col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', 8));

            for (int row = 0; row < matrix3.GetLength(0); row++)
            {
                for (int col = 0; col < matrix3.GetLength(0); col++)
                {
                    matrix3[row, col] = matrix1[row, col] - matrix2[row, col];
                    Console.Write($" {matrix3[row,col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
