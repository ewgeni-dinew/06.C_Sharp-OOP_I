using System;
using System.Collections.Generic;
using System.Linq;

namespace App
{
    class StartUp
    {
        static void Main()
        {
            var nameComparator = new SortedSet<Person>(new NameComparator());
            var ageComparator = new SortedSet<Person>(new AgeComparator());

            var personCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < personCount; i++)
            {
                var line = Console.ReadLine()
                    .Split()
                    .ToArray();

                var person = new Person(line[0],int.Parse(line[1]));

                nameComparator.Add(person);
                ageComparator.Add(person);
            }
            
            foreach (var person in nameComparator)
            {
                Console.WriteLine(person);
            }

            foreach (var person in ageComparator)
            {
                Console.WriteLine(person);
            }
        }
    }
}
