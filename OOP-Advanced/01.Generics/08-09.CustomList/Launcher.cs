using System;
using System.Collections.Generic;
using System.Linq;

namespace App
{
    public class Launcher
    {
        static void Main()
        {
            var list = new CustomList<string>();

            while (true)
            {
                var args = Console.ReadLine().Split();

                var command = args[0];

                if (command.Equals("END"))
                {
                    break;
                }

                switch (command)
                {
                    case "Add":
                        list.Add(args[1]);
                        break;
                    case "Remove":
                        list.Remove(int.Parse(args[1]));
                        break;
                    case "Contains":
                        Console.WriteLine(list.Contains(args[1]));
                        break;
                    case "Swap":
                        list.Swap(int.Parse(args[1]),int.Parse(args[2]));
                        break;
                    case "Greater":
                        Console.WriteLine(list.CountGreaterThan(args[1]));
                        break;
                    case "Max":
                        Console.WriteLine(list.Max());
                        break;
                    case "Min":
                        Console.WriteLine(list.Min());
                        break;
                    case "Print":
                        list.Print();
                        break;
                    case "Sort":
                        list.Sort();
                        break;
                }
            }
        }
    }
}
