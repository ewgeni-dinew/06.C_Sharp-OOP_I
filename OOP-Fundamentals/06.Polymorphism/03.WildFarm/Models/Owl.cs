using System;
using System.Collections.Generic;
using System.Text;

public class Owl:Bird
{
    public Owl(string name, double weight, double wingSize)
        : base(name, weight, wingSize)
    {
    }

    public override string ProduceSound()
    {
        return "Hoot Hoot";
    }
    public override void Eat(string type,int amount)
    {
        if (type.Equals("Meat"))
        {
            this.FoodEaten += amount;
            this.Weight += (0.25 * amount);
        }
        else
        {
            throw new ArgumentException($"Owl does not eat {type}!");
        }
    }
}

