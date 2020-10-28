using System;
using System.Linq;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = ReadMatrix(n);
            int beeRow = -1;
            int beeCol = -1;
            int pollinatedFlowers = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(matrix[i,j]=='B')
                    {
                        beeRow = i;
                        beeCol = j;
                        matrix[i, j] = '.';
                    }
                }
            }
            string command = Console.ReadLine();
            while(command!="End")
            {
                if(command=="left")
                {
                    beeCol--;
                }
                else if(command=="right")
                {
                    beeCol++;
                }
                else if (command == "up")
                {
                    beeRow--;
                }
                else if (command == "down")
                {
                    beeRow++;
                }

                if(beeRow<0 || beeRow>=n || beeCol<0 || beeCol>=n)
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }
                
                if(matrix[beeRow,beeCol]== 'O')
                {
                    matrix[beeRow, beeCol] = '.';

                    if (command == "left")
                    {
                        beeCol--;
                    }
                    else if (command == "right")
                    {
                        beeCol++;
                    }
                    else if (command == "up")
                    {
                        beeRow--;
                    }
                    else if (command == "down")
                    {
                        beeRow++;
                    }
                }

                if(matrix[beeRow,beeCol]=='f')
                {
                    pollinatedFlowers++;
                    matrix[beeRow, beeCol] = '.';
                }
                command = Console.ReadLine();
            }
            if(command=="End")
            {
                matrix[beeRow, beeCol] = 'B';
            }
           

            if(pollinatedFlowers>=5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5-pollinatedFlowers} flowers more");
            }

            PrintMatrix(matrix);
        }


        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
        private static char[,] ReadMatrix(int n)
        {
            char[,] matrix = new char[n, n];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowData = Console.ReadLine().ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            return matrix;
        }
    }
}
