using System;
using System.Collections.Generic;
using System.Linq;

namespace TrojanInvasion
{
    class Program
    {
        static void Main(string[] args)
        {
            int wavesCount = int.Parse(Console.ReadLine());
            var inputPlates = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> queueOfPlates = new Queue<int>(inputPlates);
            List<int> remaining = new List<int>();

            for (int i = 1; i <= wavesCount; i++)
            {
                var inputWave = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                Stack<int> stackOfCurrWarriors = new Stack<int>(inputWave);
                if (i % 3 == 0)
                {
                    int anotherPlate = int.Parse(Console.ReadLine());
                    queueOfPlates.Enqueue(anotherPlate);
                }
                int currPlate = queueOfPlates.Peek();

                while (stackOfCurrWarriors.Count > 0 && queueOfPlates.Count > 0)
                {

                    int currWarrior = stackOfCurrWarriors.Pop();

                    if (currWarrior > currPlate)
                    {
                        currWarrior -= currPlate;
                        stackOfCurrWarriors.Push(currWarrior);
                        queueOfPlates.Dequeue();
                    }
                    else if (currWarrior < currPlate)
                    {
                        currPlate -= currWarrior;
                        queueOfPlates.Dequeue();
                        var copyPlates = new List<int>();
                        copyPlates.Add(currPlate);
                        copyPlates.InsertRange(1,queueOfPlates);
                        queueOfPlates = new Queue<int>(copyPlates);
                    }
                    else if (currPlate == currWarrior)
                    {
                        queueOfPlates.Dequeue();
                    }
                    if (queueOfPlates.Count > 0)
                    {
                        currPlate = queueOfPlates.Peek();
                    }
                }
                if (queueOfPlates.Count == 0)
                {
                    remaining.AddRange(stackOfCurrWarriors);
                    break;
                }
            }

            if (queueOfPlates.Count > 0)
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", queueOfPlates)}");
            }
            else
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(", ", remaining)}");
            }
        }
    }
}
