using System;
using System.Collections.Generic;
using System.Linq;

namespace setsAndDictionariesAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();
            for (int i = 0; i < input[0]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                first.Add(num);
            }
            for (int i = 0; i < input[1]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                second.Add(num);
            }
            var third = first.Intersect(second);
            foreach (var item in third)
            {
                Console.Write(item + " ");
            }
        }
    }
}
