using System;

namespace MultiplyTwoMatrices
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
            int[,] matrix2 =
            {
                { 9, 8, 7 },
                { 6, 5, 4 },
                { 3, 2, 1 }
            };
            int[,] matrix3 = new int[3, 3];
            int counter = 0; 

            for (int row = 0; row < matrix1.GetLength(0); row++)
            {
                for (int col = 0; col < matrix1.GetLength(1); col++)
                {
                    Console.Write($" {matrix1[row,col]} ");
                    counter++;
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-',counter));

            for (int row = 0; row < matrix2.GetLength(0); row++)
            {
                for (int col = 0; col < matrix2.GetLength(1); col++)
                {
                    Console.Write($" {matrix2[row,col]} "); 
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-',counter));

            for (int row = 0; row < matrix3.GetLength(0); row++)
            {
                for (int col = 0; col < matrix3.GetLength(1); col++)
                {
                    int sum = 0;
                    for (int i = 0; i < matrix3.GetLength(0); i++)
                    {
                        sum += matrix1[row, i] * matrix2[i, col];
                    }
                    matrix3[row, col] = sum;
                }
            }

            for (int row = 0; row < matrix3.GetLength(0); row++)
            {
                for (int col = 0; col < matrix3.GetLength(1); col++)
                {
                    Console.Write($" {matrix3[row,col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
