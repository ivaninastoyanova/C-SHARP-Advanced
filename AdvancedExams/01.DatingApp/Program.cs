using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int matchesCount = 0; 
            Stack<int> males = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Queue<int> females = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            while(males.Count>0 && females.Count>0)
            {
                int male = males.Peek();
                int female = females.Peek();
                if(male<=0 || female<0)
                {
                    if(male<=0)
                    {
                        males.Pop();
                    }
                    if(female<=0)
                    {
                        females.Dequeue();
                    }
                    continue;
                }
                if(male%25==0 || female%25==0)
                {
                    if(male%25==0)
                    {
                        males.Pop();
                        males.Pop();
                    }
                    if(female%25==0)
                    {
                        females.Dequeue();
                        females.Dequeue();
                    }
                    continue;
                }
                if(male==female)
                {
                    matchesCount++;
                    males.Pop();
                    females.Dequeue();
                }
                else
                {
                    females.Dequeue();
                    male -= 2;
                    males.Pop();
                    males.Push(male);
                }
            }
            Console.WriteLine($"Matches: {matchesCount}");
            if(males.Count>0)
            {
                Console.WriteLine($"Males left: {string.Join(", " , males)}");
            }
            else
            {
                Console.WriteLine("Males left: none");
            }
            if (females.Count > 0)
            {
                Console.WriteLine($"Females left: {string.Join(", ", females)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }
        }
    }
}
