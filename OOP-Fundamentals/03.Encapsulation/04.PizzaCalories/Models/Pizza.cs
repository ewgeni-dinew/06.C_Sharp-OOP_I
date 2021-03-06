﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> topppings;

    public Pizza()
    {

    }
    public Pizza(string name, Dough dough):this()
    {
        this.Name = name;
        this.Dough = dough;
        this.Toppings = new List<Topping>();
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (value.Length<1||value.Length>15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            name = value;
        }
    }

    public Dough Dough
    {
        get { return dough; }
        set { dough = value; }
    }

    public List<Topping> Toppings
    {
        get { return topppings; }
        set { topppings = value; }
    }

    public double GetTotalCalories()
    {
        return this.Dough.GetDoughCalories() + this.Toppings.Select(t => t.GetToppingCalories()).Sum();
    }

    public void AddTopping(Topping topping)
    {
        if (this.Toppings.Count >= 10)
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        this.Toppings.Add(topping);
    }
}

