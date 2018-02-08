using System;
using System.Linq;

namespace _07.PredicateNames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var inputLength = int.Parse(Console.ReadLine());

            var inputNames = Console.ReadLine()
               .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .ToList();

            Predicate<string> isValid = (name) => (name).Length <= inputLength;

            foreach (var name in inputNames)
            {
                if (isValid(name))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
