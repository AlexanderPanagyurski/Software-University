using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            Stack<string> stack = new Stack<string>(input);
            Queue<string> queueHalls = new Queue<string>();
            List<int> list = new List<int>();
            int currCapacity = 0;
            while (stack.Count > 0)
            {
                string currElement = stack.Pop();

                bool isNumber = int.TryParse(currElement, out int result);

                if (!isNumber)
                {
                    queueHalls.Enqueue(currElement);
                }
                else
                {
                    if (queueHalls.Count == 0)
                    {
                        continue;
                    }
                    if (currCapacity + result > maxCapacity)
                    {
                        Console.WriteLine($"{queueHalls.Dequeue()} -> {string.Join(", ", list)}");
                        currCapacity = 0;
                        list.Clear();
                    }
                    if (queueHalls.Count > 0)
                    {
                        currCapacity += result;
                        list.Add(result);
                    }

                }
            }

        }
    }
}
