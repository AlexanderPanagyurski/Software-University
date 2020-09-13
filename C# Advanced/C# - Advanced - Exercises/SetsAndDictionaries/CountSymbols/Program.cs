using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text =Console.ReadLine();
            Dictionary<char, int> symbols = new Dictionary<char, int>();

            for (int index = 0; index < text.Length; index++)
            {
                char currSymbol = text[index];
                if (!symbols.ContainsKey(currSymbol))
                {
                    symbols.Add(currSymbol,0);
                }
                symbols[currSymbol]++;
            }
            foreach (var symbol in symbols.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
