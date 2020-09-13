using System;

namespace EqualMatrices
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
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 3, 2, 1 }
            };
            int[,] matrix3 = new int[3, 3];
            int counter = 0;

            for (int row = 0; row < matrix1.GetLength(0); row++)
            {
                for (int col = 0; col < matrix1.GetLength(1); col++)
                {
                    Console.Write($" {matrix1[row, col]} ");
                    counter++;
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', counter));

            for (int row = 0; row < matrix2.GetLength(0); row++)
            {
                for (int col = 0; col < matrix2.GetLength(1); col++)
                {
                    Console.Write($" {matrix2[row, col]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', counter));
            bool areEqual = true;
            string position = string.Empty;

            for (int row = 0; row < matrix2.GetLength(0); row++)
            {
                for (int col = 0; col < matrix2.GetLength(1); col++)
                {
                    if (matrix1[row,col]!=matrix2[row,col])
                    {
                        areEqual = false;
                        position = $"[{row+1},{col+1}]";
                        break;
                    }
                }
            }
            if (areEqual)
            {
                Console.WriteLine($"Equal");
            }
            else
            {
                Console.WriteLine($"Not equal, difference: {position}");
            }

        }
    }
}
