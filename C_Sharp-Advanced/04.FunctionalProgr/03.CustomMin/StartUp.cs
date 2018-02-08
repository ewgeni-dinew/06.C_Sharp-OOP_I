using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CustomMin
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input=Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Func<List<int>, int> minNum = (list) => list.Min();

            Console.WriteLine(minNum(input));
        }
    }
}
