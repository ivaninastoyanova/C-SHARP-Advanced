using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            int wreathCount = 0;
            int storedFlowers = 0;
            while (lilies.Count!= 0 && roses.Count!=0)
            {
                int currentLili = lilies.Peek();
                int currentRose = roses.Peek();

                if(currentLili+currentRose==15)
                {
                    wreathCount++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if(currentLili + currentRose > 15)
                {
                    while(currentLili + currentRose > 15)
                    {
                        currentLili -= 2;
                        if(currentLili + currentRose == 15)
                        {
                            wreathCount++;
                            lilies.Pop();
                            roses.Dequeue();
                            break;
                        }
                    }
                    storedFlowers = storedFlowers + currentLili + currentRose;
                    lilies.Pop();
                    roses.Dequeue();

                }
                else if (currentLili + currentRose < 15)
                {
                    storedFlowers = storedFlowers + currentLili + currentRose;
                    lilies.Pop();
                    roses.Dequeue();
                }
            }
            int additionalWreathes = storedFlowers / 15;
            wreathCount = wreathCount + additionalWreathes;
            if(wreathCount>=5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathCount} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5-wreathCount} wreaths more!");
            }    
            
        }
    }
}
