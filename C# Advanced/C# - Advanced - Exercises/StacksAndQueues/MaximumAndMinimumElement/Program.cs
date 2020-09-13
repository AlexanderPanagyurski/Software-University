using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                int queryType = int.Parse(input[0]);
                if (queryType == 1)
                {
                    int element = int.Parse(input[1]);
                    stack.Push(element);
                }
                else if (queryType == 2)
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                }
                else if (queryType == 3)
                {
                    if (stack.Count>0)
                    {
                        var listOfStack = stack.ToList();
                        Console.WriteLine(listOfStack.Max());
                    }
                }
                else if (queryType == 4)
                {
                    if (stack.Count>0)
                    {
                        var listOfStack = stack.ToList();
                        Console.WriteLine(listOfStack.Min());
                    }
                }
            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
