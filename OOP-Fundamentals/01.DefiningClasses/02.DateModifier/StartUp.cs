using System;


class StartUp
{
    static void Main(string[] args)
    {
        var firstInput = DateTime.ParseExact(Console.ReadLine(),"yyyy MM dd",null);
        var secondInput = DateTime.ParseExact(Console.ReadLine(),"yyyy MM dd",null);

        var obj = new DateModifier(firstInput,secondInput);
        Console.WriteLine(obj.DateDiff());
    }
}

