using System;

public class Launcher
{
    static void Main()
    {
        var driverName = Console.ReadLine();

        var ferrari = new Ferrari(driverName);

        Console.WriteLine($"{ferrari.Model}/{ferrari.UseBrakes()}/{ferrari.Gas()}/{ferrari.Driver}");
    }
}

