using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicOps
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var inputCommand = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var result = new Stack<int>();

            var stackPush = inputCommand[0];
            var stackPop = inputCommand[1];
            var specialNum = inputCommand[2];

            int minNum = int.MaxValue;
            var found = false;

            for (int i = 0; i <stackPush ; i++)
            {
                result.Push(numbers[i]);
            }

            for (int i = 0; i < stackPop; i++)
            {
                result.Pop();
            }

            foreach (var num in result)
            {
                if (num==specialNum)
                {
                    found = true;
                    Console.WriteLine("true");
                }
                else if (num<minNum)
                {
                    minNum = num;
                }
            }

            if (found==false)
            {
                if (minNum==int.MaxValue)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(minNum);
                }
            }
        }
    }
}
