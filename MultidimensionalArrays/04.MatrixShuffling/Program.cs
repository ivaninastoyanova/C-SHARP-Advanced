using System;
using System.Linq;

namespace _04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowData = Console.ReadLine().Split(" ").ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] splitted = command.Split();
                if (splitted.Length == 5 && splitted[0] == "swap")
                {

                    int row1 = int.Parse(splitted[1]);
                    int col1 = int.Parse(splitted[2]);
                    int row2 = int.Parse(splitted[3]);
                    int col2 = int.Parse(splitted[4]);



                    if (row1 > rows || row2 > rows || col1 > cols || col2 > cols
                        || row1 < 0 || row2 < 0 || col1 < 0 || col2 < 0)
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                        string current = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = current;
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write(matrix[row, col] + " ");
                            }
                            Console.WriteLine();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                command = Console.ReadLine();
            }
        }
    }
}
