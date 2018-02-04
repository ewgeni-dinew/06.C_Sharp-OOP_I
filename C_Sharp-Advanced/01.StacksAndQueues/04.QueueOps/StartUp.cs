using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.QueueOps
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
                .ToArray();

            var enque = inputCommand[0];
            var deque = inputCommand[1];
            var specialNum = inputCommand[2];

            var queue = new Queue<int>();

            for (int i = 0; i < enque; i++)
            {
                queue.Enqueue(numbers[i]);
            }
            for (int i = 0; i <deque; i++)
            {
                queue.Dequeue();
            }

            if (queue.Any(n=>n==specialNum))
            {
                Console.WriteLine("true");
            }
            else if(queue.Count!=0)
            {
                Console.WriteLine(queue.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
