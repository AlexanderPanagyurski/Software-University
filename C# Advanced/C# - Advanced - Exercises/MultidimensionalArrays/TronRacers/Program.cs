
using System;

namespace TronRacers
{
    class Program
    {
        static void Main(string[] args)
        {
            int size =int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var currRowInput = Console.ReadLine().ToCharArray();
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {

                }
            }
        }
    }
}
