using System;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowInMatrix = int.Parse(Console.ReadLine());
            double[][] matrix = new double[rowInMatrix][];

            ReadJaggedMatrix(rowInMatrix, matrix);

            for (int i = 0; i < rowInMatrix - 1; i++)
            {
                if (matrix[i].Count() == matrix[i + 1].Count())
                {
                    matrix[i] = matrix[i].Select(x => x * 2).ToArray();
                    matrix[i + 1] = matrix[i + 1].Select(x => x * 2).ToArray();
                }
                else
                {
                    matrix[i] = matrix[i].Select(x => x / 2).ToArray();
                    matrix[i + 1] = matrix[i + 1].Select(x => x / 2).ToArray();
                }
            }
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }
                else
                {
                    string[] splitted = command.Split();
                    int row = int.Parse(splitted[1]);
                    int col = int.Parse(splitted[2]);
                    double value = double.Parse(splitted[3]);
                    if (splitted[0] == "Add")
                    {

                        if (row >= 0 && row < matrix.Length)
                        {
                            if (col >= 0 && col < matrix[row].Length)
                            {
                                matrix[row][col] += value;
                            }
                        }
                    }
                    else if (splitted[0] == "Subtract")
                    {
                        if (row >= 0 && row < matrix.Length)
                        {
                            if (col >= 0 && col < matrix[row].Length)
                            {
                                matrix[row][col] -= value;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < rowInMatrix; i++)
            {
                Console.WriteLine(string.Join(" ", matrix[i]));
            }
        }

        private static void ReadJaggedMatrix(int rowInMatrix, double[][] matrix)
        {
            for (int i = 0; i < rowInMatrix; i++)
            {
                double[] currentRowValue = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

                matrix[i] = currentRowValue;
            }
        }
    }
}
