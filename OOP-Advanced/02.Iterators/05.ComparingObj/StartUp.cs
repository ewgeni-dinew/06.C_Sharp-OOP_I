using System;
using System.Collections.Generic;
using System.Linq;

namespace App
{
    class StartUp
    {
        static void Main()
        {
            var persons = new List<Person>();

            while (true)
            {
                var line = Console.ReadLine()
                    .Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (line[0].Equals("END"))
                    break;

                var person = new Person(line[0], int.Parse(line[1]), line[2]);
                persons.Add(person);
            }

            var elementAt = int.Parse(Console.ReadLine()) - 1;
            var obj = persons[elementAt];
            var equalPeople = 0;

            foreach (var item in persons)
            {
                if (obj.CompareTo(item)==0)
                {
                    equalPeople++;
                }
            }

            if (equalPeople==1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalPeople} {persons.Count-equalPeople} {persons.Count}");
            }
        }
    }
}
