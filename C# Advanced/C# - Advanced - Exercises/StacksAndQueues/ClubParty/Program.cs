using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] secondInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> leftSocks = new Stack<int>(firstInput);
            Queue<int> rightSocks = new Queue<int>(secondInput);
            List<int> pairs = new List<int>();

            while (leftSocks.Count > 0 && rightSocks.Count > 0)
            {
                int currLeftSock = leftSocks.Pop();
                int currRightSock = rightSocks.Peek();

                if (currLeftSock == currRightSock)
                {
                    currLeftSock++;
                    leftSocks.Push(currLeftSock);
                    rightSocks.Dequeue();
                }
                else if (currLeftSock > currRightSock)
                {
                    int pair = currRightSock + currLeftSock;
                    rightSocks.Dequeue();
                    pairs.Add(pair);
                }
            }
            int biggestPair = pairs.Max();
            Console.WriteLine(biggestPair);
            Console.WriteLine(string.Join(" ",pairs));
        }
    }
}
