using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lengths = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Dictionary<int, List<int>> setsOfElements = new Dictionary<int, List<int>>();
            setsOfElements.Add(1, new List<int>());
            setsOfElements.Add(2, new List<int>());
            setsOfElements.Add(3, new List<int>());
            for (int i = 0; i < lengths[0]; i++)
            {
                int number =int.Parse(Console.ReadLine());
                setsOfElements[1].Add(number);
            }
            for (int i = 0; i < lengths[1]; i++)
            {
                int number =int.Parse(Console.ReadLine());
                setsOfElements[2].Add(number);
            }
            if (setsOfElements[1].Count>=setsOfElements[2].Count)
            {
                for (int i = 0; i < setsOfElements[1].Count; i++)
                {
                    int number = setsOfElements[1][i];
                    if (setsOfElements[2].Contains(number))
                    {
                        if (!setsOfElements[3].Contains(number))
                        {
                            setsOfElements[3].Add(number);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < setsOfElements[2].Count-setsOfElements[1].Count; i++)
                {
                    int number = setsOfElements[1][i];
                    if (setsOfElements[2].Contains(number))
                    {
                        if (!setsOfElements[3].Contains(number))
                        {
                            setsOfElements[3].Add(number);
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ",setsOfElements[3]));
        }
    }
}
