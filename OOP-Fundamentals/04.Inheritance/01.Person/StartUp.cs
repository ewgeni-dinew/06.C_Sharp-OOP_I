using System;

public class StartUp
{
    static void Main(string[] args)
    {
        var inputName = Console.ReadLine();
        var inputAge = int.Parse(Console.ReadLine());

        try
        {
            var child = new Child(inputName,inputAge);
            Console.WriteLine(child.ToString());
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

