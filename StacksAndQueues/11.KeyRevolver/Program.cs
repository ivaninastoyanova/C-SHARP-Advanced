using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _11.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> bulletsStack = new Stack<int>();
            Queue<int> locksQueue = new Queue<int>();
            int priceOfBullet = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());
            int[] bulletsSizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locksSizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int valueOfIntelligence = int.Parse(Console.ReadLine());

            int countOfBullets = 0; 

            foreach (var bullet in bulletsSizes)
            {
                bulletsStack.Push(bullet);
            }
            foreach (var lockk in locksSizes )
            {
                locksQueue.Enqueue(lockk);
            }


            while(true)
            {
                if (countOfBullets % sizeOfGunBarrel == 0 && countOfBullets != 0 && bulletsStack.Count!=0)
                {
                    Console.WriteLine("Reloading!");
                }
                if (locksQueue.Count == 0)
                {
                    Console.WriteLine($"{bulletsStack.Count} bullets left. Earned ${valueOfIntelligence - countOfBullets * priceOfBullet}");
                    return;
                }
                if (bulletsStack.Count == 0 )
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
                    return;
                }
               
                int currentBullet = bulletsStack.Pop();
                int currentLock = locksQueue.Peek();
                if(currentBullet<=currentLock)
                {
                    Console.WriteLine("Bang!");
                    locksQueue.Dequeue();
                   
                    countOfBullets++;
                }
                else
                {
                    Console.WriteLine("Ping!");
                    
                    countOfBullets++;
                }
            }
        }
    }
}
