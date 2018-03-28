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
            var boxList = new List<Box<int>>();

            for (int i = 0; i < lines; i++)
            {
                //var element = Console.ReadLine();
                var element = int.Parse(Console.ReadLine());

                //var box = new Box<string>(element);
                var box = new Box<int>(element);

                boxList.Add(box);
            }

            var tokens = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var firstElement = boxList.ElementAt(tokens[0]);
            var secondElement = boxList.ElementAt(tokens[1]);

            boxList[tokens[0]] = secondElement;
            boxList[tokens[1]] = firstElement;

            foreach (var item in boxList)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
