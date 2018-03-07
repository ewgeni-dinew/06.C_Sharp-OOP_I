using System;
using System.Collections.Generic;
using System.Text;

public class Dog:Mammal
{
    public Dog(string name, double weight, string livingRegion) 
        : base(name, weight,livingRegion)
    {
    }

    public override string ProduceSound()
    {
        return "Woof!";
    }

    public override void Eat(string type, int amount)
    {
        if (type.Equals("Meat"))
        {
            this.FoodEaten += amount;
            this.Weight += (0.4 * amount);
        }
        else
        {
            throw new ArgumentException($"Dog does not eat {type}!");
        }
    }

    public override string ToString()
    {
        return base.ToString() + $"[{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}

