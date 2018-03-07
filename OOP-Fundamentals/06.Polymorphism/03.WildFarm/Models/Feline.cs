using System;
using System.Collections.Generic;
using System.Text;

public abstract class Feline : Mammal
{
    public string Breed { get; set; }

    public Feline(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion)
    {
        this.Breed = breed;
    }

    public override string ToString()
    {
        return base.ToString() + $"[{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}

