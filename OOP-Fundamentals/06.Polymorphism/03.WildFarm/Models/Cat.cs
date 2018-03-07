using System;
using System.Collections.Generic;
using System.Text;

public class Cat:Feline
{
    public Cat(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion, breed)
    {
    }

    public override string ProduceSound()
    {
        return "Meow";
    }
    public override void Eat(string type, int amount)
    {
        if (type.Equals("Meat")||type.Equals("Vegetable"))
        {
            this.FoodEaten += amount;
            this.Weight += (0.3 * amount);
        }
        else
        {
            throw new ArgumentException($"Cat does not eat {type}!");
        }
    }
}

