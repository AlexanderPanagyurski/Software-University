using System;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] line = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = line[0];
                string[] items = line[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                for (int j = 0; j < items.Length; j++)
                {
                    if (!wardrobe[color].ContainsKey(items[j]))
                    {
                        wardrobe[color].Add(items[j], 1);
                    }
                    else
                    {
                        wardrobe[color][items[j]]++;
                    }
                }
            }
            string[] outfit = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                var clothes = color.Value;
                if (color.Key == outfit[0])
                {
                    foreach (var item in clothes)
                    {
                        if (item.Key == outfit[1])
                        {
                            Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                        }
                        else
                        {
                            Console.WriteLine($"* {item.Key} - {item.Value}");
                        }
                    }
                }
                else
                {
                    foreach (var item in clothes)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
