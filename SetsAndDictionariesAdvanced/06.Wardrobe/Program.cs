using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> dictionary = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ").ToArray();
                string color = input[0];
                string clothes = input[1];
                string[] splittedClothes = clothes.Split(",").ToArray();
                int splittedClothesCount = splittedClothes.Length;
                
                if(!dictionary.ContainsKey(color))
                {
                    dictionary.Add(color, new Dictionary<string, int>());
                }
                for (int j = 0; j <splittedClothesCount; j++)
                {
                    if (!dictionary[color].ContainsKey(splittedClothes[j]))
                    {
                        dictionary[color].Add(splittedClothes[j], 0);
                    }
                    dictionary[color][splittedClothes[j]]++;
                }
               
            }
            string[] toFind = Console.ReadLine().Split().ToArray(); ;
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var pair in item.Value)
                {
                    if (pair.Key == toFind[1] && item.Key== toFind[0])
                    {
                        Console.WriteLine($"* {pair.Key} - {pair.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {pair.Key} - {pair.Value}");
                    }
                }
            }   
        }
    }
}
