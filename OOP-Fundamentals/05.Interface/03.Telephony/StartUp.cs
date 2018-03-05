using System;

public class StartUp
{
    static void Main()
    {
        var numberList = Console.ReadLine()
            .Split();

        var urlList= Console.ReadLine()
            .Split();

        var smartPhone = new SmartPhone();

        foreach (var num in numberList)
            Console.WriteLine(smartPhone.Calling(num));

        foreach (var url in urlList)
            Console.WriteLine(smartPhone.Browsing(url));
    }
}

