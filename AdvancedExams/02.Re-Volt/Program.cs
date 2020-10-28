using System;
using System.Linq;

namespace _02.Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int turns = int.Parse(Console.ReadLine());
            char[,] matrix = ReadMatrix(n);

            int personRow = -1;
            int personCol = -1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 'f')
                    {
                        personRow = i;
                        personCol = j;
                        matrix[i, j] = '-';
                    }
                }
            }


            for (int i = 0; i < turns; i++)
            {
                string command = Console.ReadLine();
                if (command == "left")
                {
                    personCol--;
                }
                else if (command == "right")
                {
                    personCol++;
                }
                else if (command == "up")
                {
                    personRow--;
                }
                else if (command == "down")
                {
                    personRow++;
                }


                if (personRow < 0 || personRow >= n || personCol < 0 || personCol >= n)
                {
                    if (command == "left")
                    {
                        personCol = n - 1;
                    }
                    else if (command == "right")
                    {
                        personCol = 0;
                    }
                    else if (command == "up")
                    {
                        personRow = n - 1;
                    }
                    else if (command == "down")
                    {
                        personRow = 0;
                    }
                    matrix[personRow, personCol] = '-';
                }


                if (matrix[personRow, personCol] == 'F')
                {
                    matrix[personRow, personCol] = 'f';
                    Console.WriteLine("Player won!");
                    PrintMatrix(matrix);
                    return;
                }
                else if (matrix[personRow, personCol] == 'B')
                {

                    if (command == "left")
                    {
                        personCol--;
                    }
                    else if (command == "right")
                    {
                        personCol++;
                    }
                    else if (command == "up")
                    {
                        personRow--;
                    }
                    else if (command == "down")
                    {
                        personRow++;
                    }

                    if (personRow < 0 || personRow >= n || personCol < 0 || personCol >= n)
                    {
                        if (command == "left")
                        {
                            personCol = n - 1;
                        }
                        else if (command == "right")
                        {
                            personCol = 0;
                        }
                        else if (command == "up")
                        {
                            personRow = n - 1;
                        }
                        else if (command == "down")
                        {
                            personRow = 0;
                        }

                    }
                    if (matrix[personRow, personCol] == 'F')
                    {
                        matrix[personRow, personCol] = 'f';
                        Console.WriteLine("Player won!");
                        PrintMatrix(matrix);
                        return;
                    }
                    matrix[personRow, personCol] = '-';
                }

                else if (matrix[personRow, personCol] == 'T')
                {
                    if (command == "left")
                    {
                        personCol++;
                    }
                    else if (command == "right")
                    {
                        personCol--;
                    }
                    else if (command == "up")
                    {
                        personRow++;
                    }
                    else if (command == "down")
                    {
                        personRow--;
                    }
                }
                matrix[personRow, personCol] = '-';

            }
            matrix[personRow, personCol] = 'f';
            Console.WriteLine("Player lost!");
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
