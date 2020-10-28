using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = ReadMatrix(n);

            int rowSnake = -1;
            int colSnake = -1;

            int barrelCount = 0;
            int foodEaten = 0;

            int[] barrels = new int[4];
            Dictionary<int, int[]> barrelss = new Dictionary<int, int[]>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 'S')
                    {
                        rowSnake = i;
                        colSnake = j;
                        matrix[i, j] = '.';
                    }
                    if (matrix[i, j] == 'B')
                    {
                        barrelCount++;

                        barrelss.Add(barrelCount, new int[] { i, j });
                       
                    }
                }
            }
            int rowBarrel1 = -1;
            int colBarrel1 = -1;
            int rowBarrel2 = -1;
            int colBarrel2 = -1;
            if (barrelCount == 2)
            {
                rowBarrel1 = barrelss[1][0];
                colBarrel1 = barrelss[1][1];
                rowBarrel2 = barrelss[2][0];
                colBarrel2 = barrelss[2][1];
            }
            bool dead = false;
            bool won = false;

            while (dead == false && won == false)
            {
                string command = Console.ReadLine();
                if (command == "left")
                {
                    colSnake--;
                }
                else if (command == "right")
                {
                    colSnake++;
                }
                else if (command == "up")
                {
                    rowSnake--;
                }
                else if (command == "down")
                {
                    rowSnake++;
                }

                if(rowSnake<0 || rowSnake>=n || colSnake<0 || colSnake>=n)
                {
                    dead = true;
                    break;
                }

                if (matrix[rowSnake, colSnake] == 'B')
                {
                    matrix[rowSnake, colSnake] = '.';
                
                    if (rowSnake == rowBarrel1)
                    {
                        rowSnake = rowBarrel2;
                        colSnake = colBarrel2;
                        matrix[rowSnake, colSnake] = '.';
                    }
                      
                    else if (rowSnake == rowBarrel2)
                        {
                            rowSnake = rowBarrel1;
                            colSnake = colBarrel1;
                        matrix[rowSnake, colSnake] = '.';
                        }
                    }
                
                if (matrix[rowSnake, colSnake] == '*')
                {
                    foodEaten++;
                    matrix[rowSnake, colSnake] = '.';
                }
                else if (matrix[rowSnake, colSnake] == '-')
                {
                    matrix[rowSnake, colSnake] = '.';
                }

                if (foodEaten == 10)
                {
                    matrix[rowSnake, colSnake] = 'S';
                    won = true;
                    break;
                }
            }


            if(dead== true)
            {
                Console.WriteLine("Game over!");
            }
            else if(won==true)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            Console.WriteLine($"Food eaten: {foodEaten}"); ;
            PrintMatrix(matrix);


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

        static bool CheckForEscaping( int Ypos, int Xpos, char[,] matrix)
        {
            if (Xpos < 0 || Xpos >= matrix.GetLength(1) || Ypos < 0 || Ypos >= matrix.GetLength(0))
            {
                return true;
            }
            else
            {
                return false;
            }
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
    }
}
