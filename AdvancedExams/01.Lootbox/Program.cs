using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            Queue<int> firstBox = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> secondtBox = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            while(firstBox.Count!=0 && secondtBox.Count!=0)
            {
                int firstElement = firstBox.Peek();
                int secondElement = secondtBox.Peek();
                int currentSum = firstElement+secondElement;
                if(currentSum%2==0)
                {
                    sum += currentSum;
                    firstBox.Dequeue();
                    secondtBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondElement);
                    secondtBox.Pop();
                }

            }
            if(firstBox.Count==0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if(secondtBox.Count==0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if(sum>=100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sum }");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sum}");
            }
        }
    }
}
