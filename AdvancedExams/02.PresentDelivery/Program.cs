using System;
using System.Linq;

namespace _02.PresentDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            if(m<=0)
            {
                return;
            }
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = ReadMatrix(n);

            int niceKidsCount = 0;
            int givenPresents = 0;
            int happyGiven = 0; 
            int santaRow = -1;
            int santaCol = -1;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 'S')
                    {
                        santaRow = i;
                        santaCol = j;
                        matrix[i, j] = '-';
                    }
                    if(matrix[i,j]=='V')
                    {
                        niceKidsCount++;
                    }
                }
            }

            string command = Console.ReadLine();
            while(m>0 && command!= "Christmas morning" )
            {
                if (command == "left")
                {
                    santaCol--;
                }
                else if (command == "right")
                {
                    santaCol++;
                }
                else if (command == "up")
                {
                    santaRow--;
                }
                else if (command == "down")
                {
                    santaRow++;
                }

                if (santaRow < 0 || santaRow >= n || santaCol < 0 || santaCol >= n)
                {
                    return;
                }


                if (matrix[santaRow,santaCol]=='V')
                {
                    matrix[santaRow, santaCol] = '-';
                    m--;
                    givenPresents++;
                    happyGiven++;
                }
                if (m <= 0)
                {
                    Console.WriteLine("Santa ran out of presents!");
                    break;
                }
                else if( matrix[santaRow,santaCol]== 'X')
                {
                    matrix[santaRow, santaCol] = '-';
                }
                else if (matrix[santaRow, santaCol] == 'C')
                {
                    matrix[santaRow, santaCol] = '-';
                    //lqvo
                    if(matrix[santaRow, santaCol-1] == 'X')
                    {
                        m--;
                        givenPresents++;
                        matrix[santaRow, santaCol - 1] = '-';
                    }
                    else if (matrix[santaRow, santaCol - 1] == 'V')
                    {
                        m--;
                        givenPresents++;
                        happyGiven++;
                        matrix[santaRow, santaCol - 1] = '-';
                    }
                    if(m<=0)
                    {
                        Console.WriteLine("Santa ran out of presents!");
                        break;
                    }
                    if (m <= 0)
                    {
                        Console.WriteLine("Santa ran out of presents!");
                        break;
                    }
                    //dqsno
                    if (matrix[santaRow, santaCol +1] == 'X')
                    {
                        m--;
                        givenPresents++;
                        matrix[santaRow, santaCol +1] = '-';
                    }
                    else if (matrix[santaRow, santaCol +1] == 'V')
                    {
                        m--;
                        givenPresents++;
                        happyGiven++;
                        matrix[santaRow, santaCol +1] = '-';
                    }
                    if (m <= 0)
                    {
                        Console.WriteLine("Santa ran out of presents!");
                        break;
                    }
                    //gore
                    if (matrix[santaRow-1, santaCol ] == 'X')
                    {
                        m--;
                        givenPresents++;
                        matrix[santaRow-1, santaCol] = '-';
                    }
                    else if (matrix[santaRow-1, santaCol] == 'V')
                    {
                        m--;
                        givenPresents++;
                        happyGiven++;
                        matrix[santaRow-1, santaCol ] = '-';
                    }
                    if (m <= 0)
                    {
                        Console.WriteLine("Santa ran out of presents!");
                        break;
                    }
                    //dolu
                    if (matrix[santaRow + 1, santaCol] == 'X')
                    {
                        m--;
                        givenPresents++;
                        matrix[santaRow + 1, santaCol] = '-';
                    }
                    else if (matrix[santaRow + 1, santaCol] == 'V')
                    {
                        m--;
                        givenPresents++;
                        happyGiven++;
                        matrix[santaRow + 1, santaCol] = '-';
                    }
                    if (m <= 0)
                    {
                        Console.WriteLine("Santa ran out of presents!");
                        break;
                    }
                }
               
                command = Console.ReadLine();
            }


            matrix[santaRow, santaCol] = 'S';

            PrintMatrix(matrix);
            if(niceKidsCount==happyGiven)
            {
                Console.WriteLine($"Good job, Santa! {niceKidsCount} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {niceKidsCount-happyGiven} nice kid/s.");
            }

        }


        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " "); ;
                }
                Console.WriteLine();
            }
        }
        private static char[,] ReadMatrix(int n)
        {
            char[,] matrix = new char[n, n];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var rowData = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            return matrix;
        }
    }
}
