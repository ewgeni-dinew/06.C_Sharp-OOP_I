using System;

public class Launcher
{
    static void Main(string[] args)
    {
        var inputName = Console.ReadLine();
        var inputAge = int.Parse(Console.ReadLine());

        try
        {
            var chicken = new Chicken(inputName, inputAge);
            Console.WriteLine(chicken.ToString());
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

