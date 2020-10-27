using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedSet<string> chemicals = new SortedSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                for (int j = 0; j < input.Length; j++)
                {
                    string name = input[j];
                    chemicals.Add(name);
                }
            }
            Console.WriteLine(string.Join(" ", chemicals));
        }
    }
}
