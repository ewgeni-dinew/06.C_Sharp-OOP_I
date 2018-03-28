using System;
using System.Collections.Generic;
using System.Linq;

namespace App
{
    public class Launcher
    {
        static void Main()
        {
            var lines = int.Parse(Console.ReadLine());

            //var boxList = new List<Box<string>>();
            var boxList = new List<Box<double>>();


            for (int i = 0; i < lines; i++)
            {
                //var element = Console.ReadLine();
                var element = double.Parse(Console.ReadLine());

                //var box = new Box<string>(element);
                var box = new Box<double>(element);

                boxList.Add(box);
            }

            //var compareString = Console.ReadLine();
            var compareNum = double.Parse(Console.ReadLine());
            int count = 0;

            foreach (var item in boxList)
            {
                //var isGreater=item.Compare(compareString);

                if (item.Element>compareNum)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
