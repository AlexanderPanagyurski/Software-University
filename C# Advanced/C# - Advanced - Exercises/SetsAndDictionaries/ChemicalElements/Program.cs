using System;
using System.Collections.Generic;
using System.Linq;

namespace ChemicalElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int count =int.Parse(Console.ReadLine());
            List<string> list = new List<string>();
            for (int i = 0; i < count-1; i++)
            {
                string[] line = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (i==0)
                {
                    for (int j = 0; j < line.Length; j++)
                    {
                        list.Add(line[j]);
                    }
                }
                else
                {
                    for (int k = 0; k < line.Length; k++)
                    {
                        if (!list.Contains(line[k]))
                        {
                            list.Add(line[k]);
                        }
                    }
                }
            }
            Console.WriteLine(string.Join(" ",list.OrderBy(x=>x)));
        }
    }
}
