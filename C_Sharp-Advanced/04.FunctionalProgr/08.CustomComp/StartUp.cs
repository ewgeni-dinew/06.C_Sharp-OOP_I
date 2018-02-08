using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CustomComp
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var inputNums = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            Predicate<int> isEven = (num) => num % 2 == 0;

            var evenNums = inputNums
                .Where(n=>isEven(n))
                .OrderBy(n=>n)
                .ToList();

            var oddNums = inputNums.
                Where(n => !isEven(n))
                .OrderBy(n => n)
                .ToList();

            var result = new List<int>();
            result.AddRange(evenNums);
            result.AddRange(oddNums);

            Console.WriteLine(string.Join(" ",result));
        }
    }
}
