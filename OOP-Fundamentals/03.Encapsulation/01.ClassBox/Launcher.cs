using System;

public class Launcher
{
    static void Main(string[] args)
    {
        var length = double.Parse(Console.ReadLine());
        var width = double.Parse(Console.ReadLine());
        var height = double.Parse(Console.ReadLine());

        try
        {
            var box = new Box(length, width, height);
            Console.WriteLine(box.ToString());
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

