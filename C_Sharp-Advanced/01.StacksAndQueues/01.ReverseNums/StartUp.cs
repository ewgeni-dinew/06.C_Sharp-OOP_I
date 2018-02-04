using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ReverseNums
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var stack = new Stack<int>();

            foreach (var num in input)
            {
                stack.Push(num);
            }

            Console.WriteLine(string.Join(" ",stack));
        }
    }
}
