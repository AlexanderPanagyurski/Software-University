using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SpaceshipCrafting
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] input2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> physicalItems = new Stack<int>(input2);
            Queue<int> chemicalLiquids = new Queue<int>(input1);
            var advanceMaterials = new Dictionary<string, int>();
            advanceMaterials.Add("Glass", 25);
            advanceMaterials.Add("Aluminium", 50);
            advanceMaterials.Add("Lithium", 75);
            advanceMaterials.Add("Carbon fiber", 100);
            var advanceMaterialsCount = new Dictionary<string, int>();
            advanceMaterialsCount.Add("Glass", 0);
            advanceMaterialsCount.Add("Aluminium", 0);
            advanceMaterialsCount.Add("Lithium", 0);
            advanceMaterialsCount.Add("Carbon fiber", 0);

            while (physicalItems.Count > 0 && chemicalLiquids.Count > 0)
            {
                int currPhysicalItem = physicalItems.Peek();
                int currChemicalLiquid = chemicalLiquids.Peek();
                int sum = currChemicalLiquid + currPhysicalItem;

                if (sum == advanceMaterials["Glass"])
                {
                    advanceMaterialsCount["Glass"]++;
                    physicalItems.Pop();
                    chemicalLiquids.Dequeue();
                }
                else if (sum == advanceMaterials["Aluminium"])
                {
                    advanceMaterialsCount["Aluminium"]++;
                    physicalItems.Pop();
                    chemicalLiquids.Dequeue();
                }
                else if (sum == advanceMaterials["Lithium"])
                {
                    advanceMaterialsCount["Lithium"]++;
                    physicalItems.Pop();
                    chemicalLiquids.Dequeue();
                }
                else if (sum == advanceMaterials["Carbon fiber"])
                {
                    advanceMaterialsCount["Carbon fiber"]++;
                    physicalItems.Pop();
                    chemicalLiquids.Dequeue();
                }
                else
                {
                    chemicalLiquids.Dequeue();
                    currPhysicalItem += 3;
                    physicalItems.Pop();
                    physicalItems.Push(currPhysicalItem);
                }
            }
            if (advanceMaterialsCount["Carbon fiber"] > 0
                && advanceMaterialsCount["Aluminium"] > 0
                && advanceMaterialsCount["Lithium"] > 0
                && advanceMaterialsCount["Glass"] > 0)
            {
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");

            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");
            }
            if (chemicalLiquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", chemicalLiquids)}");
            }
            if (physicalItems.Count == 0)
            {
                Console.WriteLine("Physical items left: none");
            }
            else
            {
                Console.WriteLine($"Physical items left: {string.Join(", ", physicalItems)}");
            }
            foreach (var item in advanceMaterialsCount.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
