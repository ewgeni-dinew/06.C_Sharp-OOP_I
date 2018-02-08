using System;
using System.Linq;

namespace _06.Reverse
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .Reverse()
               .ToList();

            var divisor = int.Parse(Console.ReadLine());

            Predicate<int> isDivisible = (n) => n % divisor == 0;

            var numbers = input
                .Where(n => !isDivisible(n))
                .ToList();

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
