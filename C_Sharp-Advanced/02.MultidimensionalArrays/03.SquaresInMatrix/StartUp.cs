using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SquaresInMatrix
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var inputNums = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new char[inputNums[0]][];

            var count = 0;

            for (int i = 0; i < inputNums[0]; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            }

            for (int i = 0; i < inputNums[0]-1; i++)
            {
                for (int j = 0; j < inputNums[1]-1; j++)
                {                    
                    var currentMatrix = new char[2][];

                    currentMatrix[0] = matrix[i].Skip(j).Take(2).ToArray();
                    currentMatrix[1] = matrix[++i].Skip(j).Take(2).ToArray();
                    i -= 1;

                    if (currentMatrix[0][0].Equals(currentMatrix[0][1])
                        && currentMatrix[0][0].Equals(currentMatrix[1][0])
                        && currentMatrix[0][0].Equals(currentMatrix[1][1]))
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
