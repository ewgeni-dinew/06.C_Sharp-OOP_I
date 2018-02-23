using System;
using System.Linq;

public class Sneaking
{
    static char[][] matrix;

    static void Main()
    {
        var inputNum = int.Parse(Console.ReadLine());

        matrix=InitializeMatrix(inputNum);

        var moves = Console.ReadLine()
            .ToCharArray();

        var samPosition = new int[2];
        FindSamPosition(samPosition);

        for (int i = 0; i < moves.Length; i++)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'b')
                    {
                        if (row >= 0 && row < matrix.Length && col + 1 >= 0 && col + 1 < matrix[row].Length)
                        {
                            matrix[row][col] = '.';
                            matrix[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            matrix[row][col] = 'd';
                        }
                    }
                    else if (matrix[row][col] == 'd')
                    {
                        if (row >= 0 && row < matrix.Length && col - 1 >= 0 && col - 1 < matrix[row].Length)
                        {
                            matrix[row][col] = '.';
                            matrix[row][col - 1] = 'd';
                        }
                        else
                        {
                            matrix[row][col] = 'b';
                        }
                    }
                }
            }

            var getEnemy = new int[2];

            for (int j = 0; j < matrix[samPosition[0]].Length; j++)
            {
                if (matrix[samPosition[0]][j] != '.' && matrix[samPosition[0]][j] != 'S')
                {
                    getEnemy[0] = samPosition[0];
                    getEnemy[1] = j;
                }
            }

            if (samPosition[1] < getEnemy[1] && matrix[getEnemy[0]][getEnemy[1]] == 'd' && getEnemy[0] == samPosition[0])
            {
                matrix[samPosition[0]][samPosition[1]] = 'X';
                Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        Console.Write(matrix[row][col]);
                    }
                    Console.WriteLine();
                }
                Environment.Exit(0);
            }
            else if (getEnemy[1] < samPosition[1] && matrix[getEnemy[0]][getEnemy[1]] == 'b' && getEnemy[0] == samPosition[0])
            {
                matrix[samPosition[0]][samPosition[1]] = 'X';
                Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        Console.Write(matrix[row][col]);
                    }
                    Console.WriteLine();
                }
                Environment.Exit(0);
            }


            matrix[samPosition[0]][samPosition[1]] = '.';
            switch (moves[i])
            {
                case 'U':
                    samPosition[0]--;
                    break;
                case 'D':
                    samPosition[0]++;
                    break;
                case 'L':
                    samPosition[1]--;
                    break;
                case 'R':
                    samPosition[1]++;
                    break;
                default:
                    break;
            }
            matrix[samPosition[0]][samPosition[1]] = 'S';

            for (int j = 0; j < matrix[samPosition[0]].Length; j++)
            {
                if (matrix[samPosition[0]][j] != '.' && matrix[samPosition[0]][j] != 'S')
                {
                    getEnemy[0] = samPosition[0];
                    getEnemy[1] = j;
                }
            }
            if (matrix[getEnemy[0]][getEnemy[1]] == 'N' && samPosition[0] == getEnemy[0])
            {
                matrix[getEnemy[0]][getEnemy[1]] = 'X';
                Console.WriteLine("Nikoladze killed!");
                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        Console.Write(matrix[row][col]);
                    }
                    Console.WriteLine();
                }
                Environment.Exit(0);
            }
        }
    }

    private static void FindSamPosition(int[] samPosition)
    {
        for (int row = 0; row < matrix.Length; row++)
        {
            for (int col = 0; col < matrix[row].Length; col++)
            {
                if (matrix[row][col].Equals('S'))
                {
                    samPosition[0] = row;
                    samPosition[1] = col;
                    break;
                }
            }
        }
    }

    private static char[][] InitializeMatrix(int inputNum)
    {
        var tempMatrix = new char[inputNum][];

        for (int i = 0; i < inputNum; i++)
        {
            tempMatrix[i] = Console.ReadLine()
                .ToCharArray();
        }
        return tempMatrix;
    }
}

