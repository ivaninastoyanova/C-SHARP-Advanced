using System;
using System.Linq;

namespace _09.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split().ToArray();
            int commandsDone = 0; 
            char[,] matrix = new char[n, n];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowData = Console.ReadLine().Split(" ").Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            int collectedCoals = 0;
            int coalsCount = 0;
            int startRow = -1;
            int startCol = -1;
            int gameOverRow = -1;
            int gameOverCol = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if(matrix[row,col]=='s')
                    {
                        startRow = row;
                        startCol = col;
                    }
                    if(matrix[row, col] == 'c')
                    {
                        coalsCount++;
                    }
                    if(matrix[row, col] == 'e')
                    {
                        gameOverRow = row;
                        gameOverCol = col;
                    }
                } 
            }
            int currentPositionRow = startRow;
            int currentPositionCol = startCol;

            for (int i = 0; i < commands.Length; i++)
            {
                string command = commands[i];
                if (command == "left" && currentPositionRow>=0 && currentPositionCol-1>=0 && currentPositionRow<n && currentPositionCol-1<n)
                {
                    currentPositionCol = currentPositionCol - 1;
                    commandsDone++;
                }
                else if (command == "right" && currentPositionRow >= 0 && currentPositionCol + 1 >= 0 && currentPositionRow < n && currentPositionCol + 1 < n)
                {
                    currentPositionCol = currentPositionCol + 1;
                    commandsDone++;
                }
                else if (command == "up" && currentPositionRow-1 >= 0 && currentPositionCol >= 0 && currentPositionRow-1 < n && currentPositionCol  < n)
                {
                    currentPositionRow = currentPositionRow - 1;
                    commandsDone++;
                }
                else if(command=="down" && currentPositionRow +1 >= 0 && currentPositionCol >= 0 && currentPositionRow +1 < n && currentPositionCol < n)
                {
                    currentPositionRow = currentPositionRow + 1;
                    commandsDone++;
                }
                
                if(matrix[currentPositionRow,currentPositionCol]=='c')
                {
                    collectedCoals++;
                    matrix[currentPositionRow, currentPositionCol] = '*';
                    if(collectedCoals==coalsCount)
                    {
                        Console.WriteLine($"You collected all coals! ({ currentPositionRow}, { currentPositionCol})");
                        return;
                    }
                }
                else if(matrix[currentPositionRow, currentPositionCol] == 'e')
                {
                    Console.WriteLine($"Game over! ({currentPositionRow}, {currentPositionCol})");
                    return;
                }

            }
            Console.WriteLine($"{coalsCount-collectedCoals} coals left. ({currentPositionRow}, {currentPositionCol})");
        }
    }
}
