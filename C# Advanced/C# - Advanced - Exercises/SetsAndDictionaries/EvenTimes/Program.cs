using System;
using System.Collections.Generic;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> dct = new Dictionary<int, int>();
            int count =int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int number =int.Parse(Console.ReadLine());
                if (!dct.ContainsKey(number))
                {
                    dct.Add(number, 0);
                }
                dct[number]++;
            }
            foreach (var number in dct)
            {
                if (number.Value%2==0)
                {
                    Console.WriteLine(number.Key);
                }
            }
        }
    }
}
