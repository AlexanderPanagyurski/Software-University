using System;

namespace SumOfMinorDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix1 =
            {
                { 1, 2, 2 },
                { 4, 4, 6 },
                { 4, 8, 9 }
            };
            int position = matrix1.GetLength(0)-1;
            int sum = 0;

            for (int row = 0; row < matrix1.GetLength(0); row++)
            {
                sum += matrix1[row, position];
                position--;
            }
            Console.WriteLine(sum);
        }
    }
}
