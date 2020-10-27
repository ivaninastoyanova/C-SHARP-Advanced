using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
       
            int start = input[0];
            int end = input[1];
            string criteria = Console.ReadLine();
            Func<int, int, List<int>> generateList = (start, end) =>
           {
               List<int> nums = new List<int>();
               for (int i = start; i <= end; i++)
               {
                   nums.Add(i);
               }
               
               return nums;
           };
            List<int> numbers = generateList(start, end);
            if (criteria == "odd")
            {
                numbers = numbers.Where(x => x % 2 != 0).ToList();
            }
            else if (criteria == "even")
            {
                numbers = numbers.Where(x => x % 2 == 0).ToList();
            }
            Console.WriteLine(string.Join(" ",numbers));
           
        }
    }
}
