using System;

public class Launcher
{
    static void Main(string[] args)
    {
        try
        {
            var pizzaName = GetPizzaName();
            Pizza pizza;

            var dough = GetDough();
            pizza = new Pizza(pizzaName, dough);

            while (true)
            {
                var command = Console.ReadLine();

                if (command.Equals("END"))
                    break;

                var topping = GetTopping(command);

                pizza.AddTopping(topping);
            }
            Console.WriteLine($"{pizzaName} - {pizza.GetTotalCalories():f2} Calories.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }

    private static Topping GetTopping(string command)
    {
        var input = command
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var type = input[1].ToLower();
        var weight = double.Parse(input[2]);

        return new Topping(type,weight);
    }

    private static Dough GetDough()
    {
        var input = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var type = input[1].ToLower();
        var technique = input[2].ToLower();
        var weight = double.Parse(input[3]);

        return new Dough(type,technique,weight);
    }

    private static string GetPizzaName()
    {
        var inputPizza = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return inputPizza[1];
    }
}

