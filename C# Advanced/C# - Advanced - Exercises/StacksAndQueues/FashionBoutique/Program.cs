using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> clothesInBox = new Stack<int>(sequence.Reverse());
            int racksCount = 1;
            int rackCapacity = int.Parse(Console.ReadLine());
            int currRack = 0;

            while (clothesInBox.Count > 0)
            {
                int currClothes = clothesInBox.Pop();
                currRack += currClothes;
                if (currRack == rackCapacity && clothesInBox.Count > 0)
                {
                    currRack = 0;
                    racksCount++;
                }
                else if (currRack > rackCapacity)
                {
                    currRack = currClothes;
                    racksCount++;
                }
            }
            Console.WriteLine(racksCount);
        }
    }
}
