using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaxNum
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();

            for (int i = 0; i < input; i++)
            {
                var line = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                switch (line[0])
                {
                    case 1:
                        stack.Push(line[1]);
                        break;
                    case 2:
                        stack.Pop();break;
                    case 3:
                        var maxNum = stack.Max();
                        Console.WriteLine(maxNum);
                        break;

                }
            }
        }
    }
}
