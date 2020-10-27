using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int capacity = int.Parse(Console.ReadLine());
            int cap = capacity;
            Stack<int> stack = new Stack<int>(array);
            int rackNumber = 1;
            while (stack.Count > 0)
            {
                if (stack.Peek() <= capacity)
                {
                    capacity -= stack.Peek();
                    stack.Pop();
                }
                else
                {
                    rackNumber++;
                    capacity = cap;
                    capacity -= stack.Peek();
                    stack.Pop();
                }
            }
            Console.WriteLine(rackNumber);
        }
    }
}
