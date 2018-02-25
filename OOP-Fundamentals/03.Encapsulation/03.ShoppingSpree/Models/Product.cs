using System;
using System.Collections.Generic;
using System.Text;

public class Product
{
    private string name;
    private decimal cost;

    public Product(string name,decimal money)
    {
        this.name = name;
        this.cost = money;
    }

    public decimal Cost
    {
        get { return cost; }
        set
        {
            if (value<0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            cost = value; }
    }
    
    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value; }
    }

}

