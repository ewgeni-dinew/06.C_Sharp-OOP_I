using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.EvenOdd
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var command = Console.ReadLine()
                .ToLower();

            var lowerBound = input[0];
            var upperBound = input[1];

            Predicate<int> predicate = (num) => num%2==0;

            switch (command)
            {
                case "even": PrintEvenNum(lowerBound,upperBound,predicate); break;
                case "odd": PrintOddNum(lowerBound,upperBound,predicate); break;
            }
        }

        private static void PrintOddNum(int lowerBound, int upperBound, Predicate<int> predicate)
        {
            for (int i = lowerBound; i <=upperBound; i++)
            {
                if (!predicate(i))
                {
                    Console.Write(i+" ");
                }
            }
        }

        private static void PrintEvenNum(int lowerBound, int upperBound, Predicate<int> predicate)
        {
            for (int i = lowerBound; i <= upperBound; i++)
            {
                if (predicate(i))
                {
                    Console.Write(i +" ");
                }
            }
        }
    }
}
