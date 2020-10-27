using System;
using System.Collections;
using System.Collections.Generic;

namespace _10.Crossroad
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> carQueue = new Queue<string>();
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            int counter = 0;
            
            while(true)
            {
                string input = Console.ReadLine();
                int greenLightSeconds = greenLightDuration;
                int passSeconds = freeWindowDuration;
                if (input=="END")
                {
                    Console.WriteLine("Everyone is safe.");
                    Console.WriteLine($"{counter} total cars passed the crossroads.");
                    return;
                }
                else if (input=="green")
                {
                    while (greenLightSeconds > 0 && carQueue.Count != 0)
                    {

                        string firstInQueue = carQueue.Dequeue();
                        greenLightSeconds -= firstInQueue.Length;
                        if (greenLightSeconds >= 0)
                        {
                            counter++;
                        }
                        else
                        {
                            passSeconds += greenLightSeconds;

                            if (passSeconds < 0)
                            {
                                Console.WriteLine($"A crash happened!{Environment.NewLine}" +
                                    $"{firstInQueue} was hit at" +
                                    $" {firstInQueue[firstInQueue.Length + passSeconds]}.");
                                return;
                            }
                            counter++;
                        }
                    }
                }
                else
                {
                    carQueue.Enqueue(input);
                }
            }
        }
    }
}
