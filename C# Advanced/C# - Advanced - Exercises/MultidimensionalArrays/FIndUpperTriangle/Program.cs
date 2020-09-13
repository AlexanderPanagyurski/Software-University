using System;

namespace FIndUpperTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix =
             {
                { 2, 3 },
                { 0, 6 },
            };
            bool hasUpperTriangle = true;
            int currIndex = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                currIndex++;
                if (matrix[row,currIndex]==0)
                {
                    hasUpperTriangle = false;
                    break;
                }
            }
            Console.WriteLine($"Has upper triangle: {hasUpperTriangle}");
        }
    }
}
