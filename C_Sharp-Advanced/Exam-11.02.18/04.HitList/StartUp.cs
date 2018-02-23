using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.HitList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string, Dictionary<string, string>>();
            var targetInfoIndes = int.Parse(Console.ReadLine());

            var line = Console.ReadLine();
            while (line!= "end transmissions")
            {
                var elements = line.Split(new char[] { '=', ':', ';' });

                var name = elements[0];
                var firstInfo = elements[1];
                var secondInfo = elements[2];

                if (!dictionary.ContainsKey(name))
                {
                    dictionary[name] = new Dictionary<string, string>();
                }
                dictionary[name][firstInfo] = secondInfo;

                for (int i = 3; i <elements.Length; i++)
                {
                    firstInfo = elements[i];
                    i++;
                    secondInfo = elements[i];
                    dictionary[name][firstInfo] = secondInfo;
                }


                line = Console.ReadLine();
            }

            var killCommand = Console.ReadLine().Split(' ');
            var killName = killCommand[1];

            var infoIndex = 0;

            Console.WriteLine($"Info on {killName}:");
            foreach (var kvp in dictionary[killName].OrderBy(e=>e.Key))
            {
                infoIndex += kvp.Key.Length;
                infoIndex += kvp.Value.Length;
                Console.WriteLine($"---{kvp.Key}: {kvp.Value}");
            }
            Console.WriteLine($"Info index: {infoIndex}");
            if (infoIndex>=targetInfoIndes)
                Console.WriteLine($"Proceed");
            else
                Console.WriteLine($"Need {targetInfoIndes-infoIndex} more info.");
        }
    }
}
