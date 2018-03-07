using System;
using System.Collections.Generic;
using System.Text;

public class Mouse:Mammal
{
    public Mouse(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
    {
    }

    public override string ProduceSound()
    {
        return "Squeak";
    }

    public override void Eat(string type, int amount)
    {
        if (type.Equals("Fruit") || type.Equals("Vegetable"))
        {
            this.FoodEaten += amount;
            this.Weight += (0.1 * amount);
        }
        else
        {
            throw new ArgumentException($"Mouse does not eat {type}!");
        }
    }

    public override string ToString()
    {
        return base.ToString() + $"[{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}

