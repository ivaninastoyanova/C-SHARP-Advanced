using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            SortedDictionary<char, int> symbolsCount = new SortedDictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if(!symbolsCount.ContainsKey(currentChar))
                {
                    symbolsCount.Add(currentChar, 0);
                }
                symbolsCount[currentChar]++;
            }
            
            foreach (var pair in symbolsCount)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value} time/s");
            }
        }
    }
}
