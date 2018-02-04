using System;
using System.Collections.Generic;

namespace _09.FibunacciStack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());

            var stack = new Stack<long>();
            stack.Push(1);
            stack.Push(1);

            for (int i = 2; i < num; i++)
            {
                var first = stack.Pop();
                var second = stack.Peek();
                var third = first + second;

                stack.Push(first);
                stack.Push(third);
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
