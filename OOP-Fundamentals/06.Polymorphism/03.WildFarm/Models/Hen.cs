using System;
using System.Collections.Generic;
using System.Text;

public class Hen:Bird
{
    public Hen(string name, double weight, double wingSize)
        : base(name, weight,wingSize)
    {

    }

    public override string ProduceSound()
    {
        return "Cluck";
    }

    public override void Eat(string type,int amount)
    {
        this.FoodEaten += amount;
        this.Weight += (0.35 * amount);
    }
}

