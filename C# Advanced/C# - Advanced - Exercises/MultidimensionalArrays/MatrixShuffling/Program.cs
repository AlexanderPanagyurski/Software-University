using System;
using System.Linq;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string[,] matrix = new string[input[0], input[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] currRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currRow[col];
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                var splitCommand = command
                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                     .ToArray();
                if (splitCommand.Contains("swap") && splitCommand.Length < 6)
                {
                    int row1 = int.Parse(splitCommand[1]);
                    int col1 = int.Parse(splitCommand[2]);
                    int row2 = int.Parse(splitCommand[3]);
                    int col2 = int.Parse(splitCommand[4]);
                    if (row1 >= 0 && row1 < matrix.GetLength(0)
                        && row2 >= 0 && row2 < matrix.GetLength(0)
                        && col1 >= 0 && col1 < matrix.GetLength(1)
                        && col2 >= 0 && col2 < matrix.GetLength(1))
                    {
                        string element1 = matrix[row1, col1];
                        string element2 = matrix[row2, col2];
                        matrix[row2, col2] = element1;
                        matrix[row1, col1] = element2;
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write($"{matrix[row, col]} ");
                            }
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                command = Console.ReadLine();
            }
        }
    }
}
