using System;
using System.Linq;

namespace _02.KnightGame
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var boardSize = int.Parse(Console.ReadLine());
 
            var board = new char[boardSize][];

            for (int i = 0; i <boardSize; i++)
            {
                board[i] = Console.ReadLine()
                    .ToCharArray();
            }

            var maxRow = 0;
            var maxColumn = 0;
            var maxAttackedPositions = 0;
            var countRemoved = 0;

            do
            {
                if (maxAttackedPositions>0)
                {
                    board[maxRow][maxColumn] = '0';
                    maxAttackedPositions = 0;
                    countRemoved++;
                }

                var currentAttackPosition = 0;

                for (int i = 0; i <boardSize; i++)
                {
                    for (int j = 0; j < boardSize; j++)
                    {
                        if (board[i][j].Equals('K'))
                        {
                            currentAttackPosition = CalculateAttackedPositions(i, j, board);
                            if (currentAttackPosition>maxAttackedPositions)
                            {
                                maxAttackedPositions = currentAttackPosition;
                                maxRow =i;
                                maxColumn =j;
                            }
                        }
                    }
                }
            } while (maxAttackedPositions>0);

            Console.WriteLine(countRemoved);
        }

        static int CalculateAttackedPositions(int row,int column,char[][]board)
        {
            var currentAttackPosition = 0;
            if (IsPositionAttacked(row - 2, column + 1, board)) currentAttackPosition++;
            if (IsPositionAttacked(row - 2, column - 1, board)) currentAttackPosition++;
            if (IsPositionAttacked(row - 1, column - 2, board)) currentAttackPosition++;
            if (IsPositionAttacked(row - 1, column + 2, board)) currentAttackPosition++;
            if (IsPositionAttacked(row + 2, column + 1, board)) currentAttackPosition++;
            if (IsPositionAttacked(row + 2, column - 1, board)) currentAttackPosition++;
            if (IsPositionAttacked(row + 1, column - 2, board)) currentAttackPosition++;
            if (IsPositionAttacked(row + 1, column + 2, board)) currentAttackPosition++;

            return currentAttackPosition;
        }

        static bool IsPositionAttacked(int row, int column, char[][] board)
        {
            return IsPositionWithinBoard(row, column, board[0].Length) && board[row][column].Equals('K');
        }

        static bool IsPositionWithinBoard(int row,int column,int size)
        {
            return row >= 0 && row < size && column >= 0 && column < size;
        }
    }
}
