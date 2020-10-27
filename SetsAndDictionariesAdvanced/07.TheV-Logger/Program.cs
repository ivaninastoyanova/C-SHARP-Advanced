using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> data = new Dictionary<string, Dictionary<string, SortedSet<string>>>();
            string input = Console.ReadLine();
            while(input!= "Statistics")
            {
                string[] splitted = input.Split().ToArray();
                string vloggerName = splitted[0];
                string command = splitted[1];
                if(command== "joined")
                {
                    if(!data.ContainsKey(vloggerName))
                    {
                        data.Add(vloggerName, new Dictionary<string, SortedSet<string>>());
                        data[vloggerName].Add("followers", new SortedSet<string>());
                        data[vloggerName].Add("following", new SortedSet<string>());
                    }
                }
                else if(command=="followed")
                {
                    string vloggerName2 = splitted[2];
                    if(data.ContainsKey(vloggerName)&& data.ContainsKey(vloggerName2) && vloggerName!=vloggerName2)
                    {
                        data[vloggerName]["following"].Add(vloggerName2);
                        data[vloggerName2]["followers"].Add(vloggerName);
                    }
                }
                input = Console.ReadLine();
            }

            data = data.OrderByDescending(x => x.Value["followers"].Count()).ThenBy(x => x.Value["following"].Count()).ToDictionary(x => x.Key, x => x.Value);
            var firstVlogger = data.Take(1);
            var app = data.TakeLast(data.Keys.Count - 1);
            Console.WriteLine($"The V-Logger has a total of {data.Keys.Count} vloggers in its logs.");
            foreach (var kvp in firstVlogger)
            {
                Console.WriteLine($"1. { kvp.Key} : { kvp.Value["followers"].Count} followers, {kvp.Value["following"].Count} following");
                foreach (var item in kvp.Value["followers"])
                {
                    Console.WriteLine($"*  {item}");
                }
            }
            int count = 2;
            foreach (var kvp in app)
            {
                Console.WriteLine($"{count}. {kvp.Key} : {kvp.Value["followers"].Count} followers, {kvp.Value["following"].Count} following");
                count++;
            }
        }
    }
}
