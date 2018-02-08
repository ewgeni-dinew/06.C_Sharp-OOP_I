using System;
using System.Linq;

namespace _10.PredicateParty
{
    class StartUp
    {
        static void Main()
        {
            var inputNames = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string line;

            do
            {
                line = Console.ReadLine();

                var args=line
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var command = args[0];
                var specifier = args[1];

                switch (command)
                {
                    case "Remove":
                        switch (specifier)
                        {
                            case "EndsWith":inputNames = inputNames.Where(p => !p.EndsWith(args[2])).ToList();
                                break;
                            case "StartsWith":inputNames = inputNames.Where(p => !p.StartsWith(args[2])).ToList();
                                break;
                            case "Length":inputNames = inputNames.Where(p => p.Length != int.Parse(args[2])).ToList();
                                break;
                        };
                        break;

                    case "Double":
                        switch (specifier)
                        {
                            case "EndsWith":
                                var currentName = inputNames.Where(p => p.EndsWith(args[2])).ToList();
                                inputNames.AddRange(currentName);
                                break;
                            case "StartsWith":
                                currentName= inputNames.Where(p => p.StartsWith(args[2])).ToList();
                                inputNames.AddRange(currentName);
                                break;
                            case "Length":
                                currentName= inputNames.Where(p => p.Length == int.Parse(args[2])).ToList();
                                inputNames.AddRange(currentName);
                                break;
                        }; 
                        break;
                }

            } while (line!="Party!");

            if (inputNames.Count!=0)
                Console.WriteLine(string.Join(", ", inputNames) + " are going to the party!");
            else
                Console.WriteLine("Nobody is going to the party!");
        }
    }
}
