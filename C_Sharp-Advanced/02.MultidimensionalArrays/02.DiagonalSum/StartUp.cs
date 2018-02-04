using System;
using System.Linq;

namespace _02.DiagonalSum
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var inputCount = int.Parse(Console.ReadLine());
            var matrix = new int[inputCount][];
            long leftDiagonal = 0;
            long rightDiagonal = 0;
            
            for (int i = 0; i < inputCount; i++)
            {
                var line = Console.ReadLine()
                    .Split(new [] { ' ' },StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[i] = line;

                leftDiagonal += matrix[i][i];
                rightDiagonal += matrix[i][inputCount-1-i];
            }

            Console.WriteLine(Math.Abs(leftDiagonal-rightDiagonal));
        }
    }
}
