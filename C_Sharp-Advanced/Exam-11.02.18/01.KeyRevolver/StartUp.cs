using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.KeyRevolver
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var bulletPrice = short.Parse(Console.ReadLine());
            var barrelSize = int.Parse(Console.ReadLine());

            var bullets = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var locks = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var intlgValue = int.Parse(Console.ReadLine());

            var bulletStack = new Stack<int>(bullets);

            locks.Reverse();
            var lockStack = new Stack<int>(locks);
            locks.Reverse();

            var moneySpent = 0;
            var currentSeriesCount = 0;

            while (true)
            {
                if (currentSeriesCount == barrelSize&&bulletStack.Count>0)
                {
                    currentSeriesCount = 0;
                    Console.WriteLine("Reloading!");
                }
                if (bulletStack.Count ==0)
                    break;
                if (lockStack.Count == 0)
                    break;
                


                if (bulletStack.Peek()<=lockStack.Peek())
                {
                    Console.WriteLine("Bang!");
                    lockStack.Pop();
                }
                else
                    Console.WriteLine("Ping!");

                moneySpent += bulletPrice;
                bulletStack.Pop();
                currentSeriesCount++;
            }

            if (bulletStack.Count==0&&lockStack.Count>0)
                Console.WriteLine($"Couldn't get through. Locks left: {lockStack.Count}");
            else
                Console.WriteLine($"{bulletStack.Count} bullets left. Earned ${intlgValue-moneySpent}");
        }
    }
}
