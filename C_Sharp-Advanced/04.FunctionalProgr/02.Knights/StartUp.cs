using System;

namespace _02.Knights
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = (line) => Console.WriteLine($"Sir {line}");

            foreach (var word in input)
            {
                print(word);
            }
        }
    }
}
