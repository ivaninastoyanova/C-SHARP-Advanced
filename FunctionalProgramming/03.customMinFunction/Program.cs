using System;
using System.Linq;

namespace _03.customMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int[], int> smallestNumPrint = nums =>
            {
                int minNum = Int32.MaxValue;
                foreach (var num in nums)
                {
                    if (num < minNum)
                    {
                        minNum = num;
                    }
                }
                return minNum;
            };
            Console.WriteLine(smallestNumPrint(numbers));

        }
    }
}
