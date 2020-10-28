using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BookWorm
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringg = Console.ReadLine();
            List<char> stringToChar = stringg.ToList();
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = ReadMatrix(n);
            int playerRow = -1;
            int playerCol = -1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 'P')
                    {
                        playerRow = i;
                        playerCol = j;
                        matrix[i, j] = '-';
                    }
                }
            }
            string command = Console.ReadLine();
            while(command!="end")
            {
                if (command == "left")
                {
                    playerCol--;
                }
                else if (command == "right")
                {
                    playerCol++;
                }
                else if (command == "up")
                {
                    playerRow--;
                }
                else if (command == "down")
                {
                    playerRow++;
                }

                if (playerRow < 0 || playerRow >= n || playerCol < 0 || playerCol >= n)
                {
                    if (stringToChar.Count>0)
                    {
                        // stringg.Remove(stringg.Length - 1);
                        stringToChar.RemoveAt(stringToChar.Count - 1) ;
                    }

                    if (command == "left")
                    {
                        playerCol++;
                    }
                    else if (command == "right")
                    {
                        playerCol--;
                    }
                    else if (command == "up")
                    {
                        playerRow++;
                    }
                    else if (command == "down")
                    {
                        playerRow--;
                    }
                }
                else if(matrix[playerRow,playerCol]!='-')
                {
                    var currentChar = matrix[playerRow, playerCol];
                    //stringg.Append(currentChar);
                    stringToChar.Add(currentChar);
                    matrix[playerRow, playerCol] = '-';
                }
                command = Console.ReadLine();
            }
            matrix[playerRow, playerCol] = 'P';
            Console.WriteLine(string.Join("" , stringToChar));
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
