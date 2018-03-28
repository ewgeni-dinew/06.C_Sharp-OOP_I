using System;

namespace App
{
    public class Launcher
    {
        static void Main()
        {
            var lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                var element = Console.ReadLine();

                //var box = new Box<string>(element);

                var num = int.Parse(element);

                var box = new Box<int>(num);

                Console.WriteLine(box.ToString());
            }
        }
    }
}
