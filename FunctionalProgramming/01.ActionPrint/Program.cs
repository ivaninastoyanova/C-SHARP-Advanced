﻿using System;
using System.Linq;

namespace _01.ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();
            Action<string[]> printNames = n => Console.WriteLine(string.Join(Environment.NewLine, n));
            printNames(input);
        }
    }
}
