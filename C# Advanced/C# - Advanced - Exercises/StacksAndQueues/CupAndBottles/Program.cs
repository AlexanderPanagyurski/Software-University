using System;
using System.Collections.Generic;
using System.Linq;

namespace CupAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] input2 = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> cupsCapacity = new Queue<int>(input1);
            Stack<int> filledBottles = new Stack<int>(input2);
            int wastedWater = 0;
            while (cupsCapacity.Count > 0 && filledBottles.Count > 0)
            {
                int currCup = cupsCapacity.Peek();

                while (currCup > 0 && filledBottles.Count > 0)
                {
                    int currWater = filledBottles.Pop();
                    currCup -= currWater;
                }
                if (currCup <= 0)
                {
                    cupsCapacity.Dequeue();
                }
                if (currCup < 0)
                {
                    int wastedCurrWater = Math.Abs(currCup);
                    wastedWater+=wastedCurrWater;
                }
            }
            if (cupsCapacity.Count == 0)
            {
                Console.WriteLine($"Bottles: {string.Join(" ",filledBottles)}");
            }
            else if (filledBottles.Count == 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cupsCapacity)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
