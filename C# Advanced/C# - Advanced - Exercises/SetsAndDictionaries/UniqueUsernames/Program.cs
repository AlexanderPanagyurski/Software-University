using System;
using System.Collections.Generic;
using System.Linq;

namespace Vloggers
{
    class Program
    {
        static void Main(string[] args)
        {
            var vloggerCollection = new Dictionary<string, Dictionary<string,string[,]>>();

            string input = Console.ReadLine();

            while (input?.ToLower() != "Statistics")
            {
                if (input.Contains("joined"))
                {
                    string[] splitInput = input
                        .Split(" joined ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                    var vloggerName = splitInput[0];
                    if (!vloggerCollection.ContainsKey(vloggerName))
                    {
                        vloggerCollection.Add(vloggerName, new Dictionary<string,string[,]>());
                    }
                }
                else if (input.Contains("followed"))
                {
                    string[] splitInput = input
                        .Split(" followed ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                    var vloggerName1 = splitInput[0];
                    var vloggerName2 = splitInput[1];
                    var collection = new string[2, 2];
                    vloggerCollection[vloggerName1].Add(vloggerName1,collection);
                }
                input = Console.ReadLine();
            }
        }
    }
}
