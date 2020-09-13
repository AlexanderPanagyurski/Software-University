using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MakeASalad
{
    class Program
    {
        static void Main(string[] args)
        {
            var vegetables = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var saladsCalories = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> stackOfSaladsCalories = new Stack<int>(saladsCalories);
            Queue<string> queueOfVegetables = new Queue<string>(vegetables);
            List<int> finishedSaladsCalories = new List<int>();

            while (stackOfSaladsCalories.Count > 0 && queueOfVegetables.Count > 0)
            {
                int currSalad = stackOfSaladsCalories.Peek();
                while (currSalad > 0 && queueOfVegetables.Count > 0)
                {
                    string currVegetable = queueOfVegetables.Dequeue();
                    if (currVegetable == "tomato")
                    {
                        currSalad -= 80;
                    }
                    else if (currVegetable == "carrot")
                    {
                        currSalad -= 136;
                    }
                    else if (currVegetable == "lettuce")
                    {
                        currSalad -= 109;
                    }
                    else if (currVegetable == "potato")
                    {
                        currSalad -= 215;
                    }
                    //currVegetable = queueOfVegetables.Dequeue();
                }
                finishedSaladsCalories.Add(stackOfSaladsCalories.Pop());
            }
            Console.WriteLine(string.Join(" ", finishedSaladsCalories));
            if (stackOfSaladsCalories.Count>0)
            {
                Console.WriteLine(string.Join(" ", stackOfSaladsCalories));
            }
            if (queueOfVegetables.Count>0)
            {
                Console.WriteLine(string.Join(" ", queueOfVegetables));

            }
        }
    }
}
