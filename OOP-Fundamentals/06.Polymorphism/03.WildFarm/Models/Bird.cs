using System;
using System.Collections.Generic;
using System.Text;

public abstract class Bird:Animal
{
    public double WingSize { get; set; }

    public Bird(string name, double weight,double wingSize) 
        : base(name, weight)
    {
        this.WingSize = wingSize;
    }
    public override string ToString()
    {
        return base.ToString() + $"[{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
    }
}

