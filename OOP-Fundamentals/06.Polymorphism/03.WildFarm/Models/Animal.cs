using System;
using System.Collections.Generic;
using System.Text;

public abstract class Animal
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public int FoodEaten { get; set; }

    public Animal(string name,double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.FoodEaten = 0;
    }

    public abstract string ProduceSound();

    public abstract void Eat(string type,int amount);

    public override string ToString()
    {
        return $"{this.GetType().Name} ";
    }
}

