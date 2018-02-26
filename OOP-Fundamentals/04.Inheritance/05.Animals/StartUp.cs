using System;
using System.Collections.Generic;

public class StartUp
{
    static void Main(string[] args)
    {
        var animalList = new List<Animal>();

        
        
        while (true)
        {
            var animalType = Console.ReadLine();

            if (animalType.Equals("Beast!"))
                break;

            var tokens = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var name = tokens[0];
            var age = int.Parse(tokens[1]);
            var gender = Enum.Parse<GenderEnum>(tokens[2]);
            Animal animal;

            try
            {
                switch (animalType.ToLower())
                {
                    case "cat":
                        animal = new Cat(name, age, gender);
                        break;
                    case "dog":
                        animal = new Dog(name, age, gender);
                        break;
                    case "frog":
                        animal = new Frog(name, age, gender);
                        break;
                    case "tomcat":
                        animal = new Tomcat(name, age, gender);
                        break;
                    case "kitten":
                        animal = new Kitten(name, age, gender);
                        break;
                    default: throw new ArgumentException("Invalid input!");
                }
                animalList.Add(animal);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Invalid input!");
            }
            
        }
        foreach (var animal in animalList)
        {
            Console.WriteLine(animal.ToString());
        }
    }
}

