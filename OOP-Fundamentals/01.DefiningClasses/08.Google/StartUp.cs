using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Google
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var inputLine = Console.ReadLine();

            var personList = new List<Person>();

            while (inputLine!="End")
            {
                var array = inputLine.Split();
                var name = array[0];
                var command = array[1];

                var currentPerson=personList.FirstOrDefault(p=>p.Name.Equals(name));
                Object currentObj;

                if (!personList.Any(p=>p.Name.Equals(name)))
                {
                    currentPerson = new Person(name);
                }

                switch (command.ToLower())
                {
                    case "company":
                        currentObj = new Company(array[2],array[3],decimal.Parse(array[4]));
                        currentPerson.Company = (Company)currentObj;
                        break;

                    case "pokemon":
                        currentObj = new Pokemon(array[2],array[3]);
                        currentPerson.Pokemons.Add((Pokemon)currentObj);
                        break;

                    case "parents":
                        currentObj = new Parent(array[2], array[3]);
                        currentPerson.Parents.Add((Parent)currentObj);
                        break;

                    case "children":
                        currentObj = new Child(array[2], array[3]);
                        currentPerson.Children.Add((Child)currentObj);
                        break;

                    case "car":
                        currentObj = new Car(array[2],array[3]);
                        currentPerson.Car = (Car)currentObj;
                        break;
                }

                personList.Add(currentPerson);

                inputLine = Console.ReadLine();
            }

            var filterName = Console.ReadLine();

            var person = personList.FirstOrDefault(p => p.Name.Equals(filterName));

            Console.WriteLine(person.ToString());
        }
    }
}
