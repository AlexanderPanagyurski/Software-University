using System;

namespace RhombusStars
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 1; i <= count; i++)
            {
                PrintRow(i, count);
            }
            for (int i = count - 1; i >= 1; i--)
            {
                PrintRow(i, count);
            }
        }

        private static void PrintRow(int i, int count)
        {
            Console.Write(new string(' ', count - i));
            for (int j = 1; j <= i; j++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }
    }
}
