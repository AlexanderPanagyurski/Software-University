using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
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

            Queue<int> queue = new Queue<int>(numbers);

            for (int i = 0; i < input[1]; i++)
            {
                queue.Dequeue();
            }
            if (queue.Contains(input[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queue.Count > 0)
                {
                    int smallestNumber = int.MaxValue;
                    while (queue.Count > 0)
                    {
                        int currNumber = queue.Dequeue();
                        if (currNumber<smallestNumber)
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
