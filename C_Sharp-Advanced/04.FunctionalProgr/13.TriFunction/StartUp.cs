using System;
using System.Linq;

namespace _13.TriFunction
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var inputNum = int.Parse(Console.ReadLine());

            var inputNames = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Func<string, int> checkNum = (text) => text.ToCharArray().Sum(n => n);
            Func<string, int, bool> numIsValid = (text, num) => checkNum(text) >= num;

            var result = inputNames.FirstOrDefault(n => numIsValid(n, inputNum));

            Console.WriteLine(result);
        }
    }
}
