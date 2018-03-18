using System;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        var dm = new DraftManager();

        while (true)
        {
            var line = Console.ReadLine()
                .Split(' ');

            if (line[0].Equals("Shutdown"))
            {
                Console.WriteLine(dm.ShutDown());
                break;
            }

            var message = string.Empty;

            switch (line[0])
            {
                case "RegisterHarvester":
                    message=dm.RegisterHarvester(line.Skip(1).ToList());
                    break;
                case "RegisterProvider":
                    message = dm.RegisterProvider(line.Skip(1).ToList());
                    break;
                case "Day":
                    message = dm.Day();
                    break;
                case "Mode":
                    message = dm.Mode(line.Skip(1).ToList());
                    break;
                case "Check":
                    message = dm.Check(line.Skip(1).ToList());
                    break;
            }
            Console.WriteLine(message);
        }
    }
}

