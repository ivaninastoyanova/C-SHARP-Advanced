using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestPass = new Dictionary<string, string>();
            string inputContests = Console.ReadLine();
            while(inputContests!= "end of contests")
            { 
                string[] splitted = inputContests.Split(":").ToArray();
                string contestName = splitted[0];
                string contestPassword = splitted[1];
                contestPass.Add(contestName, contestPassword);
                inputContests = Console.ReadLine();
            }

            Dictionary<string, Dictionary<string, int>> candidatesData = new Dictionary<string, Dictionary<string, int>>();
            string input = Console.ReadLine();
            while(input!= "end of submissions")
            {
                string[] splittedInput = input.Split("=>").ToArray();
                string contest = splittedInput[0];
                string password = splittedInput[1];
                string username = splittedInput[2];
                int points = int.Parse(splittedInput[3]);
                if(contestPass.ContainsKey(contest))
                {
                    if(contestPass[contest]==password)
                    {
                        if(!candidatesData.ContainsKey(username))
                        {
                            candidatesData.Add(username, new Dictionary<string, int>());
                            candidatesData[username].Add(contest, points);
                        }

                        else//ako sudurja kandidata
                        {
                            if(candidatesData[username].ContainsKey(contest))
                            {
                                if (candidatesData[username][contest] < points)
                                {
                                    candidatesData[username][contest] = points;
                                }
                            }
                            else
                            {
                                candidatesData[username].Add(contest, points);
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }

            candidatesData = candidatesData.OrderBy(x => x.Key).ToDictionary(x => x.Key,x => x.Value);

            var bestStudents = candidatesData.OrderByDescending(x => x.Value.Values.Sum()).ToDictionary(x => x.Key, x => x.Value);
            var bestPointsStudent = bestStudents.Take(1);
            foreach (var item in bestPointsStudent)
            {
                Console.WriteLine($"Best candidate is {item.Key} with total {item.Value.Values.Sum()} points.");
            }
            Console.WriteLine("Ranking:");
            
            foreach (var kvp in candidatesData)
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (var item in kvp.Value.OrderByDescending(x => x.Value))
                {
                    //#  {contest1} -> {points}
                    Console.WriteLine($"#  {item.Key} -> {item.Value}");
                }
            }
        }
    }
}
