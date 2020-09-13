using System;
using System.Linq;

namespace PointInRectangle
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] cordinates = ParseCordinates();
            Rectangle rectangle = new Rectangle(cordinates[0], cordinates[1], cordinates[2], cordinates[3]);
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int[] currCordinates = ParseCordinates();
                Point currPoint = new Point(currCordinates[0], currCordinates[1]);
                Console.WriteLine(rectangle.Contains(currPoint));
            }

        }

        private static int[] ParseCordinates()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
