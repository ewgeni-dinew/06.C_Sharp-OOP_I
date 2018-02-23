using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    public string Name { get; private set; }
    public Company Company { get; set; }
    public List<Pokemon> Pokemons { get; set; }
    public List<Parent> Parents { get; set; }
    public List<Child> Children { get; set; }
    public Car Car { get; set; }

    public Person(string name)
    {
        this.Name = name;
        Pokemons = new List<Pokemon>();
        Parents = new List<Parent>();
        Children = new List<Child>();
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        builder.AppendLine(this.Name);
        builder.AppendLine("Company:");

        if (this.Company != null)
            builder.AppendLine($"{Company.Name} {Company.Department} {Company.Salary:f2}");

        builder.AppendLine("Car:");

        if (this.Car != null)
            builder.AppendLine($"{Car.Model} {Car.Speed}");

        builder.AppendLine("Pokemon:");

        foreach (var pokemon in Pokemons)
            builder.AppendLine($"{pokemon.Name} {pokemon.Type}");

        builder.AppendLine("Parents:");

        foreach (var parent in Parents)
            builder.AppendLine($"{parent.Name} {parent.Birth}");

        builder.AppendLine("Children:");

        foreach (var child in Children)
            builder.AppendLine($"{child.Name} {child.Birth}");

        return builder.ToString();

    }
}

