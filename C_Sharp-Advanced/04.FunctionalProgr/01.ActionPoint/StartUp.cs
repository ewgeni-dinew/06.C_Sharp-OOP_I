using System;

namespace _01.ActionPoint
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = line => Console.WriteLine(line);

            foreach (var word in input)
            {
                print(word);
            }
        }
    }
}
