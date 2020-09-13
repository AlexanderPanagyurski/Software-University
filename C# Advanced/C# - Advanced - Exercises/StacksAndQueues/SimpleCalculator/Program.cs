using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>(input.Reverse());

            while (stack.Count != 1)
            {
                int operand1 = int.Parse(stack.Pop());
                string sign = stack.Pop();
                int operand2 = int.Parse(stack.Pop());
                if (sign == "+")
                {
                    stack.Push($"{operand1 + operand2}");
                }
                else if (sign == "-")
                {
                    stack.Push($"{operand1 - operand2}");
                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
