using System;
using System.Linq;

namespace _01.PolindromesMatrix
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var inputCommands = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var first = 97;
            var second = 97;
            var third = 97;

            var result = new string[inputCommands[0],inputCommands[1]];

            for (int i = 0; i < inputCommands[0]; i++)
            {
                for (int j = 0; j < inputCommands[1]; j++)
                {
                    result[i, j] = $"{(char)first}"+$"{(char)second}"+$"{(char)third}";
                    second++;
                }
                first++;
                third++;
                second = first;
            }

            for (int i = 0; i < inputCommands[0]; i++)
            {
                for (int j = 0; j < inputCommands[1]; j++)
                {
                    Console.Write(result[i,j]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
