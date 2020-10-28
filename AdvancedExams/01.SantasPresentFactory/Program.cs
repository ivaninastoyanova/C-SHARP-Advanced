using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SantasPresentFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int doll = 0;
            int woodenTrain = 0;
            int teddyBear = 0;
            int bicycle = 0;
            Stack<int> materials = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Queue<int> magics = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            while(materials.Count>0 && magics.Count>0)
            {
                int material = materials.Peek();
                int magic = magics.Peek();
                if(material==0 || magic==0)
                {
                    if(material==0 )
                    {
                        materials.Pop();
                    }
                    if(magic==0 )
                    {
                        magics.Dequeue();
                    }
                    continue;
                }
                int multiplied = material * magic;

                if (multiplied < 0)
                {
                    int sum = material + magic;
                    materials.Pop();
                    magics.Dequeue();
                    materials.Push(sum);
                }
                
                if (multiplied==150)
                {
                    doll++;
                    materials.Pop();
                    magics.Dequeue();
                }
                else if(multiplied==250)
                {
                    woodenTrain++;
                    materials.Pop();
                    magics.Dequeue();
                }
                else if (multiplied == 300)
                {
                    teddyBear++;
                    materials.Pop();
                    magics.Dequeue();
                }
                else if (multiplied == 400)
                {
                    bicycle++;
                    materials.Pop();
                    magics.Dequeue();
                }
              
                else if(multiplied>0)
                {
                    magics.Dequeue();
                    material += 15;
                    materials.Pop();
                    materials.Push(material);
                }
            }


            if((doll>=1 && woodenTrain>=1) || (teddyBear>=1 && bicycle>=1))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }
            if(materials.Count>0)
            {
                Console.WriteLine("Materials left: " + string.Join(", " , materials));
            }
            if (magics.Count > 0)
            {
                Console.WriteLine("Materials left: " + string.Join(", ", magics));
            }


            if(bicycle>0)
            {
                Console.WriteLine($"Bicycle: {bicycle}");
            }
            if (doll > 0)
            {
                Console.WriteLine($"Doll: {doll}");
            }
            if (teddyBear > 0)
            {
                Console.WriteLine($"Teddy bear: {teddyBear}");
            }
            if (woodenTrain > 0)
            {
                Console.WriteLine($"Wooden train: {woodenTrain}");
            }
        }
    }
}
