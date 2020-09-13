using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            for (int i = 1; i <= input[1]; i++)
            {
                stack.Pop();
            }
            if (stack.Contains(input[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count > 0)
                {
                    int smallestNumber = int.MaxValue;
                    while (stack.Count > 0)
                    {
                        int currNumber = stack.Pop();
                        if (currNumber < smallestNumber)
                        {
                            smallestNumber = currNumber;
                        }
                    }
                    Console.WriteLine(smallestNumber);
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
