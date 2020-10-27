using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(orders);
            Console.WriteLine(queue.Max());
            while (queue.Count > 0)
            {
                if (queue.Peek() <= quantityOfFood)
                {
                    int food = queue.Peek();
                    quantityOfFood -= food;
                    queue.Dequeue();
                }
                else
                {
                    break;
                }
            }
            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.Write("Orders left: ");
                while (queue.Count > 1)
                {
                    Console.Write(queue.Dequeue() + " ");
                }
                Console.Write(queue.Dequeue());
            }
        }
    }
}
