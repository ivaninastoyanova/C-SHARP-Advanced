using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.knightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            string[] result = names.Select(n => $"Sir {n}").ToArray();
            Action<string[]> printingPlusSir = s => Console.WriteLine(string.Join(Environment.NewLine, s));
            printingPlusSir(result);
        }
    }
}
