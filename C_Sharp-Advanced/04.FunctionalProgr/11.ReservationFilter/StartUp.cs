using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ReservationFilter
{
    class StartUp
    {
        static void Main()
        {
            var names = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var temp = new List<string>(names);

            string line;

            while (true)
            {
                line = Console.ReadLine();
                if (line == "Print")
                    break;

                var args = line
                .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                var command = args[0];
                var specifier = args[1];
                var param = args[2];

                switch (command)
                {
                    case "Add filter":
                        switch (specifier)
                        {
                            case "Starts with":
                                temp = temp.Where(n => !n.StartsWith(param)).ToList();
                                break;
                            case "Ends with":
                                temp = temp.Where(n => !n.EndsWith(param)).ToList();
                                break;
                            case "Length":
                                temp = temp.Where(n => n.Length != int.Parse(param)).ToList();
                                break;
                            case "Contains":
                                temp = temp.Where(n => !n.Contains(param)).ToList();
                                break;
                        }
                        ; break;
                    case "Remove filter":
                        switch (specifier)
                        {
                            case "Starts with":
                                var currentFilter = names.Where(n => n.StartsWith(param)).ToList();
                                temp.AddRange(currentFilter);
                                break;
                            case "Ends with":
                                currentFilter = names.Where(n => n.EndsWith(param)).ToList();
                                temp.AddRange(currentFilter);
                                break;
                            case "Length":
                                currentFilter = names.Where(n => n.Length == int.Parse(param)).ToList();
                                temp.AddRange(currentFilter);
                                break;
                            case "Contains":
                                currentFilter = names.Where(n => n.Contains(param)).ToList();
                                temp.AddRange(currentFilter);
                                break;
                        }
                        ; break;
                }
            }
            Console.WriteLine(string.Join(" ",temp));
        }
    }
}
