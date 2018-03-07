using System;
using System.Collections.Generic;
using System.Text;

public class Tiger:Feline
{
    public Tiger(string name, double weight, string livingRegion, string breed) 
        : base(name, weight, livingRegion, breed)
    {
    }

    public override string ProduceSound()
    {
        return "ROAR!!!";
    }

    public override void Eat(string type, int amount)
    {
        if (type.Equals("Meat"))
        {
            this.FoodEaten += amount;
            this.Weight += (1.0 * amount);
        }
        else
        {
            throw new ArgumentException($"Tiger does not eat {type}!");
        }
    }
}

