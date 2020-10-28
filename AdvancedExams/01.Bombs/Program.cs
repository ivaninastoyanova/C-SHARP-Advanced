using System;
using System.Collections.Generic;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            using System;
            using System.Collections.Generic;
            using System.Linq;

namespace AdvancedExam_28June2020
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[] effectsInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] casingsInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                if (effectsInput.Length == 0 || casingsInput.Length == 0)
                {
                    return;
                }

                Queue<int> bombsEffects = new Queue<int>(effectsInput);
                Stack<int> bombsCasings = new Stack<int>(casingsInput);
                int daturaCounter = 0;
                int cherryCounter = 0;
                int smokeCounter = 0;

                while (bombsEffects.Count > 0 && bombsCasings.Count > 0)
                {
                    if (smokeCounter >= 3 && cherryCounter >= 3 && daturaCounter >= 3)
                    {
                        break;
                    }

                    int currentEffect = bombsEffects.Peek();
                    int currentCasing = bombsCasings.Peek();
                    if (currentCasing + currentEffect == 40)
                    {
                        daturaCounter++;
                        bombsCasings.Pop();
                        bombsEffects.Dequeue();
                    }
                    else if (currentEffect + currentCasing == 60)
                    {
                        cherryCounter++;
                        bombsCasings.Pop();
                        bombsEffects.Dequeue();
                    }
                    else if (currentEffect + currentCasing == 120)
                    {
                        smokeCounter++;
                        bombsCasings.Pop();
                        bombsEffects.Dequeue();
                    }
                    else
                    {
                        currentCasing = currentCasing - 5;
                        if (currentCasing >= 0)
                        {
                            bombsCasings.Pop();
                            bombsCasings.Push(currentCasing);
                        }
                        else
                        {
                            bombsCasings.Pop();
                        }
                    }
                }

                if (smokeCounter >= 3 && cherryCounter >= 3 && daturaCounter >= 3)
                {
                    Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
                    //Console.WriteLine("Bomb Effects: " + String.Join(", ", bombsEffects));
                    //Console.WriteLine("Bomb Casings: " + String.Join(", ", bombsCasings));
                }
                else
                {
                    Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
                }


                if (bombsEffects.Count == 0)
                {
                    Console.WriteLine("Bomb Effects: empty");
                }
                else
                {
                    Console.WriteLine("Bomb Effects: " + String.Join(", ", bombsEffects));
                }

                if (bombsCasings.Count == 0)
                {
                    Console.WriteLine("Bomb Casings: empty");
                }
                else
                {
                    Console.WriteLine("Bomb Casings: " + String.Join(", ", bombsCasings));
                }

                Console.WriteLine($"Cherry Bombs: {cherryCounter}");
                Console.WriteLine($"Datura Bombs: {daturaCounter}");
                Console.WriteLine($"Smoke Decoy Bombs: {smokeCounter}");
            }
        }
    }

}
    }
}
