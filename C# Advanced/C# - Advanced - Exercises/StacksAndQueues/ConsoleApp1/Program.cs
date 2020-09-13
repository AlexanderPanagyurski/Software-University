namespace _10_Simple_Text_Editor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SimpleTextEditor
    {
        public static void Main(string[] args)
        {
            int quantityOfTheFood = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> ordersQueue = new Queue<int>(orders);
            int biggestOrder = ordersQueue.Max();

            while (ordersQueue.Count > 0 && quantityOfTheFood - ordersQueue.Peek() >= 0)
            {
                int currOrder = ordersQueue.Dequeue();
                if (currOrder > biggestOrder)
                {
                    biggestOrder = currOrder;
                }
                quantityOfTheFood -= currOrder;
            }
            Console.WriteLine(biggestOrder);
            if (ordersQueue.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(" ", ordersQueue)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}