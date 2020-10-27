using System;
using System.Collections.Generic;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbersCount = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());
                if(!numbersCount.ContainsKey(currentNum))
                {
                    numbersCount.Add(currentNum, 0);
                }
                numbersCount[currentNum]++;

            }
            foreach (var item in numbersCount)
            {
                if (item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                    break;
                }
            }
        }
    }
}
