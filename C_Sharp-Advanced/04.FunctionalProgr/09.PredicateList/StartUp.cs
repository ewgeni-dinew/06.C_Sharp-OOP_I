using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PredicateList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var upperBound = int.Parse(Console.ReadLine());

            var inputNums = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .Distinct()
               .OrderByDescending(n=>n)
               .ToList();

            var result = new List<int>();

            for (int i = 1; i <=upperBound; i++)
            {
                bool isValid = true;

                foreach (var num in inputNums)
                {
                    Predicate<int> isNotDivisible = n => i % n != 0;

                    if (isNotDivisible(num))
                    {
                        isValid = false;
                        break;
                    }
                }
                if (isValid)
                    result.Add(i);
            }

            Console.WriteLine(string.Join(" ",result));
        }
    }
}
