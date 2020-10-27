using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                string command = input[0];
                if (command == "1")
                {
                    int x = int.Parse(input[1]);
                    stack.Push(x);
                }
                else if (command == "2" && stack.Count > 0)
                {
                    stack.Pop();
                }
                else if (command == "3" && stack.Count > 0)
                {
                    Console.WriteLine(stack.Max());
                }
                else if (command == "4" && stack.Count > 0)
                {
                    Console.WriteLine(stack.Min());
                }
            }
            while (stack.Count > 1)
            {
                Console.Write(stack.Pop() + ", ");

            }
            Console.Write(stack.Pop());
        }
    }
}
