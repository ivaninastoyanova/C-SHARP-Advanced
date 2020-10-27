using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.reverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List <int>numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            int devide = int.Parse(Console.ReadLine());
            numbers.Reverse();
            numbers = numbers.Where(n => n % devide != 0).ToList();
            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
