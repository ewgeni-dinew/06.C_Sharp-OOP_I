using System;
using System.Linq;

namespace _02.Sneaking
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var matrixSize = ushort.Parse(Console.ReadLine());
            var matrix = new char[matrixSize][];

            for (int i = 0; i <matrixSize; i++)
            {
                matrix[i] = Console.ReadLine()
                    .ToCharArray();
            }

            var moves = Console.ReadLine();

            for (int i = 0; i < moves.Length; i++)
            {
                var command = moves[i];
                bool nickIsKilled = false;

                //find coordinates S
                var tempRow = 0;
                for (int j = 0; j < matrixSize; j++)
                {
                    if (matrix[j].Contains('S'))
                    {
                        tempRow = j;
                        break;
                    }
                }
                var findIndexS = 0;
                for (int j = 0; j < matrix[tempRow].Length; j++)
                {
                    if (matrix[tempRow][j] == 'S')
                    {
                        findIndexS = j;
                        break;
                    }
                }

                //Chech if both S and N are on the same line
                for (int j = 0; j < matrixSize; j++)
                {
                    if (matrix[j].Contains('S') && matrix[j].Contains('N'))
                    {
                        var indexN = 0;
                        for (int m = 0; m < matrix[j].Length; i++)
                        {
                            if (matrix[j][m] == 'N')
                            {
                                indexN = m;
                                break;
                            }
                        }
                        nickIsKilled = true;
                        matrix[j][indexN] = 'X';
                        Console.WriteLine("Nikoladze killed!");
                        break;
                    }
                }
                if (nickIsKilled)
                {
                    break;
                }

                //Move 'b' && 'd'
                MoveBandD(matrixSize, matrix,findIndexS);

                //CheckIf Sam dies
                if (IsSamDead(matrixSize, matrix))
                    break;


                switch (command)
                {
                    case 'W':
                        break;
                    case 'U':
                        matrix[tempRow][findIndexS] = '.';
                        matrix[tempRow-1][findIndexS] = 'S';
                        break;
                    case 'D':
                        matrix[tempRow][findIndexS] = '.';
                        matrix[tempRow + 1][findIndexS] = 'S';
                        break;
                    case 'L':
                        matrix[tempRow][findIndexS] = '.';
                        matrix[tempRow][findIndexS-1] = 'S';
                        break;
                    case 'R':
                        matrix[tempRow][findIndexS] = '.';
                        matrix[tempRow][findIndexS + 1] = 'S';
                        break;
                }
                
            }

            for (int i = 0; i < matrixSize; i++)
            {
                Console.WriteLine(string.Join("", matrix[i]));
            }
        }

        private static bool IsSamDead(ushort matrixSize, char[][] matrix)
        {
            bool samDied = false;
            for (int j = 1; j < matrixSize - 1; j++)
            {
                var indexB = 0;
                var indexD = 0;
                var indexS = 0;
                
                for (int m = 0; m < matrix[j].Length; m++)
                {
                    if (matrix[j][m] == 'b')
                    {
                        indexB = m;
                    }
                    else if (matrix[j][m] == 'd')
                    {
                        indexD = m;
                    }
                    if (matrix[j][m] == 'S')
                    {
                        indexS = m;
                    }
                }
                if (indexD > indexS && matrix[j].Contains('S')&&matrix[j].Contains('d'))
                {
                    matrix[j][indexS] = 'X';
                    Console.WriteLine($"Sam died at {j}, {indexS}");
                    samDied = true;
                    break;
                }
                else if (indexB < indexS && matrix[j].Contains('S') && matrix[j].Contains('b'))
                {
                    matrix[j][indexS] = 'X';
                    Console.WriteLine($"Sam died at {j}, {indexS}");
                    samDied = true;
                    break;
                }
            }
            return samDied;
        }

        private static void MoveBandD(ushort matrixSize, char[][] matrix,int indexS)
        {
            for (int j = 0; j < matrixSize; j++)
            {
                //var charIsMoved = false;

                for (int m = 0; m < matrix[j].Length; m++)
                {
                    if (matrix[j][m] == 'b' && m != matrix[j].Length - 2)
                    {
                        if (matrix[j].Contains('S')&&m<indexS)
                        {
                            break;
                        }
                        else
                        {
                            matrix[j][m] = '.';
                            matrix[j][m + 1] = 'b';
                            break;
                        }
                        
                    }
                    else if (matrix[j][m] == 'b' && m == matrix[j].Length - 2)
                    {
                        if (matrix[j].Contains('S')&&m<indexS)
                        {
                            break;
                        }
                        else
                        {
                            matrix[j][m] = '.';
                            matrix[j][m + 1] = 'd';
                            break;
                        }
                    }
                    else if (matrix[j][m] == 'd' && m != 1)
                    {
                        if (matrix[j].Contains('S')&&m>indexS)
                        {
                            break;
                        }
                        else
                        {
                            matrix[j][m] = '.';
                            matrix[j][m - 1] = 'd';
                            break;
                        } 
                    }
                    else if (matrix[j][m] == 'd' && m == 1)
                    {
                        if (matrix[j].Contains('S')&&m>indexS)
                        {
                            break;
                        }
                        else
                        {
                            matrix[j][m] = '.';
                            matrix[j][0] = 'b';
                            break;
                        }
                    }
                }
            }
        }
    }
}
