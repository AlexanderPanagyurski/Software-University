using System;
using System.Collections.Generic;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> reversedString = new Stack<char>(input);

            while (reversedString.Count>0)
            {
                Console.Write(reversedString.Pop());
            }
            Console.WriteLine();
        }
    }
}
