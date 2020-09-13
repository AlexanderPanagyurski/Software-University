using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());
            int[] sequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Queue<int> orders = new Queue<int>(sequence);
            int biggestOrder = 1;

            while (orders.Count > 0)
            {
                int currOrder = orders.Peek();
                if (biggestOrder < currOrder)
                {
                    biggestOrder = currOrder;
                }
                if (quantityOfFood >= currOrder)
                {
                    quantityOfFood -= currOrder;
                    orders.Dequeue();
                }
                else
                {
                    break;
                }
            }
            if (orders.Count == 0)
            {
                Console.WriteLine(biggestOrder);
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine(biggestOrder);
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
        }
    }
}
