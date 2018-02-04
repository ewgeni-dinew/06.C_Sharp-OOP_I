using System;
using System.Linq;

namespace _04.RubiksMatrix
{
    class StartUp
    {
        private static int[,] matrix;
        private static int rows;
        private static int columns;

        static void Main(string[] args)
        {
            var inputNums = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var lineCount = int.Parse(Console.ReadLine());

            rows = inputNums[0];
            columns = inputNums[1];

            matrix = new int[rows,columns];

            var num = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = ++num;
                }
            }

            for (int i = 0; i < lineCount; i++)
            {
                var line = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var command = line[1];
                var index = int.Parse(line[0]);
                var rotations = int.Parse(line[2]);

                switch (command)
                {
                    case "up":MoveColumn(index,rows-rotations);
                        break;
                    case "down":MoveColumn(index,rotations);
                        break;
                    case "left":MoveRow(index, columns - rotations);
                        break;
                    case "right":MoveRow(index, rotations);
                        break;

                }

            }
        }

        private static void MoveRow(int index, int rot)
        {
            rot %= columns;

            var tempArr = new int[columns];

            for (int i = 0; i < columns; i++)
            {
                tempArr[i] = matrix[index, i];
            }
        }

        private static void MoveColumn(int index, int rot)
        {
            throw new NotImplementedException();
        }
    }
}
