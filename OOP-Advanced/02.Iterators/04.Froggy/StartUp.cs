using System;
using System.Linq;

class StartUp
{
    static void Main()
    {
        var input = Console.ReadLine()
            .Split(new[] { ' ', ','},StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var lake = new Lake(input);

        Console.WriteLine(string.Join(", ",lake));
    }
}

