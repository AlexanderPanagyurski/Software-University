using System;
using System.Collections.Generic;
using System.Linq;

namespace Vloggers
{
    class Program
    {
        static void Main(string[] args)
        {
            var vloggerCollection = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string input = Console.ReadLine();

            while (input?.ToLower() != "statistics")
            {
                if (input.Contains("joined"))
                {
                    string[] splitInput = input
                        .Split(" joined ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                    var vloggerName = splitInput[0];
                    if (!vloggerCollection.ContainsKey(vloggerName))
                    {
                        vloggerCollection.Add(vloggerName, new Dictionary<string, HashSet<string>>());
                        vloggerCollection[vloggerName].Add("followings", new HashSet<string>());
                        vloggerCollection[vloggerName].Add("followers", new HashSet<string>());
                    }
                }
                else if (input.Contains("followed"))
                {
                    string[] splitInput = input
                        .Split(" followed ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
                    var vloggerName1 = splitInput[0];
                    var vloggerName2 = splitInput[1];
                    if (vloggerCollection.ContainsKey(vloggerName2)
                        && vloggerCollection.ContainsKey(vloggerName1) && vloggerName1 != vloggerName2)
                    {
                        vloggerCollection[vloggerName2]["followers"].Add(vloggerName1);
                        vloggerCollection[vloggerName1]["followings"].Add(vloggerName2);
                    }

                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"The V-Logger has a total of {vloggerCollection.Count} vloggers in its logs.");
            int count = 1;
            var sortedVloggers = vloggerCollection.OrderByDescending(f => f.Value["followers"].Count)
                .ThenBy(f => f.Value["followings"].Count)
                .ToDictionary(k => k.Key, y => y.Value);

            foreach (var (username, value) in sortedVloggers)
            {
                int followersCount = sortedVloggers[username]["followers"].Count;
                int followingsCount = sortedVloggers[username]["followings"].Count;

                Console.WriteLine($"{count}. {username} : {followersCount} followers, {followingsCount} following");
                if (count == 1)
                {
                    foreach (var currUsername in value["followers"].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {currUsername}");
                    }
                }
                count++;
            }
        }
    }
}
