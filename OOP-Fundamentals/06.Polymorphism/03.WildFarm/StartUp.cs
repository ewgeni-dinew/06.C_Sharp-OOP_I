using System;
using System.Collections.Generic;

public class StartUp
{
    static void Main()
    {
        var animalList = new List<Animal>();

        while (true)
        {
            var input = Console.ReadLine();

            if (input.Equals("End"))
            {
                break;
            }
            
            var animal=GetAnimalInfo(input.Split());

            input = Console.ReadLine();

            Console.WriteLine(animal.ProduceSound());

            try
            {
                TryFeedAnimal(animal, input.Split());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            animalList.Add(animal);
        }

        foreach (var animal in animalList)
        {
            Console.WriteLine(animal.ToString());
        }
    }

    private static void TryFeedAnimal(Animal animal, string[] args)
    {
        var foodType = args[0];
        var amount = int.Parse(args[1]);

        animal.Eat(foodType,amount);
    }

    private static Animal GetAnimalInfo(string[] args)
    {
        var type = args[0];
        var name = args[1];
        var weight = double.Parse(args[2]);
        Animal animal=null;
        int wingSize;
        string livingRegion, breed;

        switch (type)
        {
            case "Cat":
                livingRegion = args[3];
                breed = args[4];
                animal = new Cat(name,weight,livingRegion,breed);
                break;
            case "Tiger":
                livingRegion = args[3];
                breed = args[4];
                animal = new Tiger(name, weight, livingRegion, breed);
                break;
            case "Dog":
                livingRegion = args[3];
                animal = new Dog(name,weight,livingRegion);
                break;
            case "Mouse":
                livingRegion = args[3];
                animal = new Mouse(name,weight,livingRegion);
                break;
            case "Owl":
                wingSize = int.Parse(args[3]);
                animal = new Owl(name,weight,wingSize);
                break;
            case "Hen":
                wingSize = int.Parse(args[3]);
                animal = new Hen(name,weight,wingSize);
                break;
        }

        return animal;
    }
}

