using System;
using System.Linq;

namespace BombTheBasement
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[][] basement = new int[dimensions[0]][];

            for (int row = 0; row < basement.Length; row++)
            {
                basement[row] = new int[dimensions[1]];
            }
            int[] cordinates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int targetRow = cordinates[0];
            int targetCol = cordinates[1];
            int radius = cordinates[2];

            for (int row = 0; row < basement.Length; row++)
            {
                for (int col = 0; col < basement[row].Length; col++)
                {
                    bool isInRadius = Math.Pow(row - targetRow, 2) + Math.Pow(col - targetCol, 2) <=
                        Math.Pow(radius, 2);
                    if (isInRadius)
                    {
                        basement[row][col] = 1;
                    }
                }
            }
            int counterOfCols = 0; 
            for (int col = 0; col < basement[0].Length; col++)
            {
                int counter = 0;

                for (int row = 0; row < basement.Length; row++)
                {
                    if (basement[row][col]==1)
                    {
                        counter++;
                        basement[row][col] = 0;
                    }
                }
                for (int row = 0; row < counter; row++)
                {
                    basement[row][col] = 1;
                }
            }
            foreach (var row in basement)
            {
                Console.WriteLine(string.Join("",row));
            }
        }
    }
}
